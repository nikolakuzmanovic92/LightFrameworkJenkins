using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightFramework.Base
{
   public class Browser
    {
        private readonly IWebDriver Driver;

        public Browser(IWebDriver driver)
        {
            Driver = driver;
        }

        public BrowserType Type { get; set; }
    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
