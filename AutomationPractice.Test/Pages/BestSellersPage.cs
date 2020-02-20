using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;

namespace AutomationPractice.Test.Pages
{
    public class BestSellersPage : AbstractPageObject
    {
        public BestSellersPage(IWebDriver driver) : base(driver)
        {
        }

        public BestSellersPage ClickListViewSetting()
        {
            _driver.FindElement(By.LinkText("List")).Click();

            return new BestSellersPage(_driver);
        }

        public void AddAllItemsToCart()
        {
            var items = _driver.FindElements(By.ClassName("ajax_add_to_cart_button"));

            foreach (var item in items)
            {
                _driver.WaitFor(item);

                item.Click();

                var next = new ProductAddedOverlay(_driver);
                _driver.WaitFor(next);

                next.ClickContinueShopping();
            }
        }

        public CartPage ClickCart()
        {
            _driver.FindElement(By.CssSelector("[title='View my shopping cart'")).Click();

            var next = new CartPage(_driver);
            _driver.WaitFor(next);

            return next;
        }

        public override bool IsReady() => _driver.CheckDisplayed(By.ClassName("product-count"));
    }
}