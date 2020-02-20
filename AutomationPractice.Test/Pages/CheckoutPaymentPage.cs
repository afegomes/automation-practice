using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;

namespace AutomationPractice.Test.Pages
{
    public class CheckoutPaymentPage : AbstractPageObject
    {
        public CheckoutPaymentPage(IWebDriver driver) : base(driver)
        {
        }

        public OrderConfirmationPage ClickPayByBankwire()
        {
            _driver.FindElement(By.CssSelector("[title='Pay by bank wire'")).Click();

            var next = new OrderConfirmationPage(_driver);
            _driver.WaitFor(next);

            return next;
        }

        public override bool IsReady()
        {
            return _driver.CheckDisplayed(By.Id("total_price_container"));
        }
    }
}