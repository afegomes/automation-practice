using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;

namespace AutomationPractice.Test.Pages
{
    public class ProductAddedOverlay : AbstractPageObject
    {
        public ProductAddedOverlay(IWebDriver driver) : base(driver)
        {
        }

        public void ClickContinueShopping()
        {
            _driver.FindElement(By.CssSelector("[title='Continue shopping']")).Click();
        }

        public override bool IsReady() =>
            _driver.CheckDisplayed(By.XPath("//*[text()[contains(.,'Product successfully added to your shopping cart')]]"))
                && _driver.CheckDisplayed(By.CssSelector("[title='Continue shopping']"))
                && _driver.CheckEnabled(By.CssSelector("[title='Continue shopping']"));
    }
}