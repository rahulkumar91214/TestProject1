using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestProject1.Drivers;
using TestProject1.Source.Pages;

namespace TestProject1.Tests
{
    public class HomeTests : Driver
    {
        [Test]
        public void VerifyHomePage()
        {
            HomePage hp = new HomePage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var applogoText = hp.Login("standard_user", "secret_sauce");
            var expectedText = "Swag Labs";
            Assert.That(applogoText, Is.EqualTo(expectedText), "Expected text is displayed in the login page");
        }

        [Test]
        public void VerifyPriceFilterDropdownValues()
        {
            HomePage hp = new HomePage();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            hp.Login("standard_user", "secret_sauce");
            IList<IWebElement> listOfOptions = hp.VerifyPriceFilterDropdownValues();
            Assert.That(listOfOptions, Has.Count.EqualTo(4), "Expected text is displayed in the login page");
        }
    }
}
