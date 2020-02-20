using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;
using Xunit;

namespace AutomationPractice.Test.Pages
{
    public class OrderCompletePage : AbstractPageObject
    {
        public OrderCompletePage(IWebDriver driver) : base(driver)
        {
        }

        public void AssertMessage(string message)
        {
            var element = _driver.FindElement(By.XPath(string.Format("//*[text()[contains(.,'{0}')]]", message)));

            Assert.NotNull(element);
        }

        public override bool IsReady()
        {
            return _driver.CheckDisplayed(By.XPath("//*[text()[contains(.,'Your order on My Store is complete.')]]"));
        }
    }
}