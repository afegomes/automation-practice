using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;

namespace AutomationPractice.Test.Pages
{
    public class OrderConfirmationPage : AbstractPageObject
    {
        public OrderConfirmationPage(IWebDriver driver) : base(driver)
        {
        }

        public OrderCompletePage ClickConfirmOrder()
        {
            _driver.FindElement(By.XPath("//*[@id='cart_navigation']/button")).Click();

            var next = new OrderCompletePage(_driver);
            _driver.WaitFor(next);

            return next;
        }

        public override bool IsReady()
        {
            return _driver.CheckDisplayed(By.XPath("//*[text()[contains(.,'You have chosen to pay by')]]"));
        }
    }
}