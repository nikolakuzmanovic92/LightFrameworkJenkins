using LightFramework.Base;
using LightFramework.Extensions;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Test.Pages
{
    class LogInPage : BasePage
    {

        public LogInPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private static By
           usernameBy = By.Id("UserName"),
           passwordBy = By.Id("Password"),
           logintBtnBy = By.XPath("//input[@class='btn btn-default']"),
           registerLinkBy = By.LinkText("Register as a new user");

        IWebElement username => Driver.FindElementBy(usernameBy);
        IWebElement password => Driver.FindElementBy(passwordBy);
        IWebElement logintBtn => Driver.FindElementBy(logintBtnBy);
        IWebElement registerLink => Driver.FindElementBy(registerLinkBy);



        public HomePage LogIn(string user = "", string pass = "")
        {
            if (user == "" || pass == "")
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\AdminCredentials.json");
                // or this: string path = AppDomain.CurrentDomain.BaseDirectory + "Resources\\AdminCredentials.json";

                Dictionary<string, string> credentialsJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
                username.SendKeys(credentialsJson["username"]);
                password.SendKeys(credentialsJson["password"]);
            }
            else
            {
                username.SendKeys(user);
                password.SendKeys(pass);
            }

            logintBtn.Click();
            return new HomePage(Driver);
        }


    }
}
