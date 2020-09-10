using LightFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LightFramework.Base
{
    public class TestInitialize : Base
    {
        public TestInitialize() : base() {}


        public void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Open Browser
            OpenBrowser(Settings.IsRemoteDriver);
        }
        private void OpenBrowser(string  IsRemoteDriver)
        {
            switch(IsRemoteDriver)
            {
                case "Y": OpenRemoteBrowser(GetBrowserOption(Settings.BrowserType)); break;
                case "N": OpenDriverBrowser(Settings.BrowserType); break;
            }
        }

        private void OpenRemoteBrowser(DriverOptions driverOptions)
        {    
            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:
                    //ToDo: Set the Desired capabilities
                    driverOptions = new InternetExplorerOptions();
                    break;
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalCapability(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                    break;
            }
            Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), driverOptions.ToCapabilities());
        }

        public DriverOptions GetBrowserOption(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    return new InternetExplorerOptions();
                case BrowserType.FireFox:
                    return new FirefoxOptions();
                case BrowserType.Chrome:
                    return new ChromeOptions();
                default:
                    return new ChromeOptions();
            }
        }

        private void OpenDriverBrowser(BrowserType browserType)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            switch (browserType)
            {
                case BrowserType.Chrome: Driver = new ChromeDriver(chromeOptions) ; break;
                case BrowserType.FireFox: Driver = new FirefoxDriver(); break;    
            }
        }
    }
}
