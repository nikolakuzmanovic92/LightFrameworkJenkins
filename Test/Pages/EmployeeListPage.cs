using LightFramework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    class EmployeeListPage : HomePage
    {
        public EmployeeListPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }

        private static By
          createNewBy = By.LinkText("Create New");

        IWebElement createNew => Driver.FindElementBy(createNewBy);


        public Dictionary<string, string> GetDetails(string name)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string salary = Driver.FindElement(By.XPath("//td[contains(text(),'" + name + "')]/following-sibling::td[1]")).ToString();
            string duration = Driver.FindElement(By.XPath("//td[contains(text(),'" + name + "')]/following-sibling::td[2]")).ToString();
            string grade = Driver.FindElement(By.XPath("//td[contains(text(),'" + name + "')]/following-sibling::td[3]")).ToString();
            string email = Driver.FindElement(By.XPath("//td[contains(text(),'" + name + "')]/following-sibling::td[4]")).ToString();

            result["salary"] = salary;
            result["duration"] = duration;
            result["grade"] = grade;
            result["email"] = email;

            return result;
        }

    }
}
