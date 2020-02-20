using AutomationPractice.Test.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPractice.Test.Pages
{
    public class CheckoutPersonalInformationPage : AbstractPageObject
    {
        public CheckoutPersonalInformationPage(IWebDriver driver) : base(driver)
        {
        }

        public CheckoutPersonalInformationPage TypeFirstName(string name)
        {
            _driver.FindElement(By.Id("customer_firstname")).SendKeys(name);
            return this;
        }

        public CheckoutPersonalInformationPage TypeLastName(string name)
        {
            _driver.FindElement(By.Id("customer_lastname")).SendKeys(name);

            return this;
        }

        public CheckoutPersonalInformationPage TypePassword(string password)
        {
            _driver.FindElement(By.Id("passwd")).SendKeys(password);

            return this;
        }

        public CheckoutPersonalInformationPage SelectBirthDay(int day)
        {
            var element = _driver.FindElement(By.Id("days"));

            new SelectElement(element).SelectByValue(day.ToString());

            return this;
        }

        public CheckoutPersonalInformationPage SelectBirthMonth(int month)
        {
            var element = _driver.FindElement(By.Id("months"));

            new SelectElement(element).SelectByValue(month.ToString());

            return this;
        }

        public CheckoutPersonalInformationPage SelectBirthYear(int year)
        {
            var element = _driver.FindElement(By.Id("years"));

            new SelectElement(element).SelectByValue(year.ToString());

            return this;
        }

        public CheckoutPersonalInformationPage TypeAddress(string address)
        {
            _driver.FindElement(By.Id("address1")).SendKeys(address);

            return this;
        }

        public CheckoutPersonalInformationPage TypeCity(string city)
        {
            _driver.FindElement(By.Id("city")).SendKeys(city);

            return this;
        }

        public CheckoutPersonalInformationPage SelectState(string state)
        {
            var element = _driver.FindElement(By.Id("id_state"));

            new SelectElement(element).SelectByText(state);

            return this;
        }

        public CheckoutPersonalInformationPage TypeZipCode(int zipCode)
        {
            _driver.FindElement(By.Id("postcode")).SendKeys(zipCode.ToString());

            return this;
        }

        public CheckoutPersonalInformationPage SelectCountry(string country)
        {
            var element = _driver.FindElement(By.Id("id_country"));

            new SelectElement(element).SelectByText(country);

            return this;
        }

        public CheckoutPersonalInformationPage TypeMobilePhone(string phone)
        {
            _driver.FindElement(By.Id("phone_mobile")).SendKeys(phone);

            return this;
        }

        public CheckoutAddressPage ClickRegister()
        {
            _driver.FindElement(By.Id("submitAccount")).Click();

            var next = new CheckoutAddressPage(_driver);
            _driver.WaitFor(next);

            return next;
        }

        public override bool IsReady()
        {
            return _driver.CheckDisplayed(By.Id("submitAccount"))
                && _driver.CheckEnabled(By.Id("submitAccount"));
        }
    }
}