using AutomationPractice.Test.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractice.Test.Extensions
{
    public static class WebDriverExtensions
    {
        private static readonly IClock DefaultClock = new SystemClock();
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
        private static readonly TimeSpan DefaultPolling = TimeSpan.FromSeconds(1);

        public static void WaitFor(this IWebDriver driver, By by)
        {
            Wait(driver).Until(x =>
            {
                return CheckDisplayed(driver, by);
            });
        }

        public static void WaitFor(this IWebDriver driver, IWebElement element)
        {
            Wait(driver).Until(x =>
            {
                return element.Displayed && element.Enabled;
            });
        }

        public static void WaitFor(this IWebDriver driver, IPageObject next)
        {
            Wait(driver).Until(x =>
            {
                return next.IsReady();
            });
        }

        public static bool CheckDisplayed(this IWebDriver driver, By by)
        {
            try
            {
                var element = driver.FindElement(by);

                return element != null && element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool CheckEnabled(this IWebDriver driver, By by)
        {
            try
            {
                var element = driver.FindElement(by);

                return element != null && element.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private static WebDriverWait Wait(IWebDriver driver)
        {
            var wait = new WebDriverWait(DefaultClock, driver, DefaultTimeout, DefaultPolling);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            return wait;
        }
    }
}