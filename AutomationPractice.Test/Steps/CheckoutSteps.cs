using AutomationPractice.Test.Extensions;
using AutomationPractice.Test.Pages;
using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AutomationPractice.Test.Steps
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly IWebDriver _driver = new ChromeDriver();

        [Given(@"a '(.*)' category")]
        public void GivenACategory(string category)
        {
            new HomePage(_driver)
                .NavigateTo()
                .ClickLink(category);
        }

        [When(@"I add its products to my shopping cart")]
        public void WhenIAddItsProductsToMyShoppingCart()
        {
            var page = new BestSellersPage(_driver);
            _driver.WaitFor(page);

            page.ClickListViewSetting()
                .AddAllItemsToCart();
        }

        [Then(@"I should be able to check them out")]
        public void ThenIShouldBeAbleToCheckThemOut()
        {
            var info = new Faker();

            var page = new BestSellersPage(_driver);
            _driver.WaitFor(page);

            page.ClickCart()
                .ClickProceedToCheckout()
                .TypeEmailAddress(info.Internet.Email())
                .ClickCreateAccount()
                .TypeFirstName(info.Name.FirstName())
                .TypeLastName(info.Name.LastName())
                .TypePassword(info.Internet.Password())
                .SelectBirthDay(info.Random.Int(1, 28))
                .SelectBirthMonth(info.Random.Int(1, 12))
                .SelectBirthYear(info.Random.Int(1980, 2000))
                .TypeAddress(info.Address.FullAddress())
                .TypeCity(info.Address.City())
                .SelectState(info.Address.State())
                .TypeZipCode(info.Random.Int(0, 99999))
                .SelectCountry("United States")
                .TypeMobilePhone(info.Phone.PhoneNumber())
                .ClickRegister()
                .ClickProceedToCheckout()
                .ClickTermsOfServiceApproval()
                .ClickProceedToCheckout()
                .ClickPayByBankwire()
                .ClickConfirmOrder()
                .AssertMessage("Your order on My Store is complete.");
        }

        [Then(@"I should be able to keep a list of them")]
        public void ThenIShouldBeAbleToKeepAListOfThem()
        {
            var page = new BestSellersPage(_driver);
            _driver.WaitFor(page);

            page.ClickCart()
                .DownloadCart();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Dispose();
        }
    }
}