using LightFramework.Base;
using LightFramework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    class DefaultPage : BasePage
    {

        public DefaultPage(IWebDriver driver)
        {
            Driver = driver;
        }

        private static By
            logInBtnBy = By.Id("loginLink"),
            registerBtnBy = By.Id("registerLink"),
            employeeListBy = By.LinkText("Employee List"),
            homeLinkBy = By.LinkText("Home");




        IWebElement logInBtn => Driver.FindElementBy(logInBtnBy);
        IWebElement registerBtn => Driver.FindElementBy(registerBtnBy);
        IWebElement employeeList => Driver.FindElementBy(employeeListBy);
        IWebElement homeLink => Driver.FindElementBy(homeLinkBy);


        public LogInPage ClickLogin()
        {
            logInBtn.Click();
            return new LogInPage(Driver);
        }

        public void ClickRegisterBtn()
        {
            registerBtn.Click();
        }

        public void ClickEmployeeList()
        {
            employeeList.Click();
        }

        public void ClickHome()
        {
            homeLink.Click();
        }

    }
}
