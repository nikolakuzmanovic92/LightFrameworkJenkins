using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LightFramework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        /* public static IWebElement FindElementBy(this IWebDriver driver, By elementBy)
         {
             try
             {
                 if (driver.FindElement(elementBy).IsElementPresent())
                 {
                     return driver.FindElement(elementBy);
                 }
             }
             catch (Exception e)
             {
                 throw new ElementNotVisibleException($"Element not found : {elementBy.ToString()}");
             }
             return null;
         }*/
        public static IWebElement FindElementBy(this IWebDriver driver, By elementBy, int timeoutInSeconds = 15)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(elementBy));
            }
            return driver.FindElement(elementBy);
        }

        public static bool IsElementPresent(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public static bool IsElementVisible(this IWebDriver driver, By elementBy, int timeoutInSeconds = 15)
        {
            if (timeoutInSeconds > 0)
            {
                try
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => drv.IsElementPresent(elementBy));

                }
                catch (WebDriverTimeoutException)
                {
                    return false;
                }

            }
            return driver.IsElementPresent(elementBy);
        }
    }
}
