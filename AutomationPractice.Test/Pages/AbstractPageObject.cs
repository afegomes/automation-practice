using OpenQA.Selenium;

namespace AutomationPractice.Test.Pages
{
    public abstract class AbstractPageObject : IPageObject
    {
        protected readonly IWebDriver _driver;

        public AbstractPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public abstract bool IsReady();
    }
}