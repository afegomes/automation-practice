using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;

namespace AutomationPractice.Test.Pages
{
    public class CheckoutShippingPage : AbstractPageObject
    {
        public CheckoutShippingPage(IWebDriver driver) : base(driver)
        {
        }

        public CheckoutShippingPage ClickTermsOfServiceApproval()
        {
            _driver.FindElement(By.Name("cgv")).Click();

            return this;
        }

        public CheckoutPaymentPage ClickProceedToCheckout()
        {
            _driver.FindElement(By.Name("processCarrier")).Click();

            var next = new CheckoutPaymentPage(_driver);
            _driver.WaitFor(next);

            return next;
        }

        public override bool IsReady()
        {
            return _driver.CheckDisplayed(By.ClassName("delivery_options"));
        }
    }
}