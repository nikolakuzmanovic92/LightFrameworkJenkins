using LightFramework.Base;
using LightFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    class ManageUsersPage : HomePage
    {
        public ManageUsersPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        public void SetRoleToUser(string userName, string role)
        {
            try
            {
                IWebElement dropdown = Driver.FindElement(By.XPath("//td[contains(text(),'" + userName + "')]/following-sibling::td[2]/select[1]"));
                var selectElement = new SelectElement(dropdown);
                selectElement.SelectByValue(role);

                IWebElement assignBtn = Driver.FindElement(By.XPath("//td[contains(text(),'" + userName + "')]/following-sibling::td[3]/input"));
                assignBtn.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + " Catch error");  //TO-DO Depending on exception set error message (no such element..)
            }
        }


    }
}
