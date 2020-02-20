using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;

namespace AutomationPractice.Test.Pages
{
    public class HomePage : AbstractPageObject
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public HomePage NavigateTo()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/");
            _driver.WaitFor(this);

            return this;
        }

        public void ClickLink(string text)
        {
            _driver.FindElement(By.LinkText(text)).Click();
        }

        public override bool IsReady() => _driver.CheckDisplayed(By.ClassName("homeslider-description"));
    }
}