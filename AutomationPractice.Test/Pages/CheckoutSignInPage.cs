using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;

namespace AutomationPractice.Test.Pages
{
    public class CheckoutSignInPage : AbstractPageObject
    {
        public CheckoutSignInPage(IWebDriver driver) : base(driver)
        {
        }

        public CheckoutSignInPage TypeEmailAddress(string address)
        {
            _driver.FindElement(By.Id("email_create")).SendKeys(address);

            return this;
        }

        public CheckoutPersonalInformationPage ClickCreateAccount()
        {
            _driver.FindElement(By.Name("SubmitCreate")).Click();

            var next = new CheckoutPersonalInformationPage(_driver);
            _driver.WaitFor(next);

            return next;
        }

        public override bool IsReady()
        {
            return _driver.CheckDisplayed(By.Id("login_form"));
        }
    }
}