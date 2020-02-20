using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;

namespace AutomationPractice.Test.Pages
{
    public class CheckoutAddressPage : AbstractPageObject
    {
        public CheckoutAddressPage(IWebDriver driver) : base(driver)
        {
        }

        public CheckoutShippingPage ClickProceedToCheckout()
        {
            _driver.FindElement(By.Name("processAddress")).Click();

            var next = new CheckoutShippingPage(_driver);
            _driver.WaitFor(next);

            return next;
        }

        public override bool IsReady()
        {
            return _driver.CheckDisplayed(By.Id("address_invoice"));
        }
    }
}