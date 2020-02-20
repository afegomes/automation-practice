using AutomationPractice.Test.Extensions;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;

namespace AutomationPractice.Test.Pages
{
    public class CartPage : AbstractPageObject
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public CheckoutSignInPage ClickProceedToCheckout()
        {
            _driver.FindElement(By.ClassName("standard-checkout")).Click();

            var next = new CheckoutSignInPage(_driver);
            _driver.WaitFor(next);

            return next;
        }

        public void DownloadCart()
        {
            var elements = _driver.FindElements(By.ClassName("cart_item"));

            var list = new List<dynamic>
            {
            };

            foreach (var e in elements)
            {
                var link = e.FindElement(By.ClassName("product-name")).FindElement(By.TagName("a"));

                var name = link.Text.Trim();
                var url = link.GetAttribute("href");
                var price = e.FindElement(By.ClassName("cart_total")).FindElement(By.ClassName("price")).Text.Trim();

                list.Add(new
                {
                    Name = name,
                    Price = price,
                    Url = url
                });
            }

            var cart = new JObject
            {
                ["items"] = JToken.FromObject(list)
            };

            using var outputFile = new StreamWriter("cart.txt");

            outputFile.Write(cart.ToString());
        }

        public override bool IsReady() => _driver.CheckDisplayed(By.Id("total_price"))
            && _driver.CheckEnabled(By.CssSelector("[title='Proceed to checkout']"));
    }
}