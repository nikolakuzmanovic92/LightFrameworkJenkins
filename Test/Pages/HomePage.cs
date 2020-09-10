using LightFramework.Base;
using LightFramework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        private static By
           logOffBy = By.LinkText("Log off"),
           managePageBy = By.LinkText("Hello admin!"),
           manageUsersBy = By.LinkText("Manage Users"),
           employeeDetailsBy = By.LinkText("Employee Details"),
           empolyeeListBy = By.LinkText("Employee List"),
           aboutBy = By.LinkText("About"),
           homeBy = By.LinkText("Home");


        IWebElement logOff => Driver.FindElementBy(logOffBy);
        IWebElement managePage => Driver.FindElementBy(managePageBy);
        IWebElement manageUsers => Driver.FindElementBy(manageUsersBy);
        IWebElement employeeDetails => Driver.FindElementBy(employeeDetailsBy);
        IWebElement empolyeeList => Driver.FindElementBy(empolyeeListBy);
        IWebElement about => Driver.FindElementBy(aboutBy);
        IWebElement home => Driver.FindElementBy(homeBy);


        public DefaultPage LogOff ()
        {
            logOff.Click();
            return new DefaultPage(Driver);
        }

        public ManageUsersPage ManageUsers()
        {
            manageUsers.Click();
            return new ManageUsersPage(Driver);
        }

        public bool CheckLoginSuccessfull()
        {
            return logOff.IsElementPresent();

        }


    }
}
