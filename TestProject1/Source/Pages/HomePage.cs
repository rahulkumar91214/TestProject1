using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.Drivers;

namespace TestProject1.Source.Pages
{
    public class HomePage : Driver
    {
        IWebDriver _webdriver;

        [FindsBy(How = How.Name, Using = "user-name")]
        private IWebElement _userName;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement _password;

        [FindsBy(How = How.Name, Using = "login-button")]
        private IWebElement _loginbtn;

        [FindsBy(How = How.CssSelector, Using = "div[class='app_logo']")]
        private IWebElement _applogo;

        [FindsBy(How = How.ClassName, Using = "product_sort_container")]
        private IWebElement _pricefilters;
     
        public HomePage()
        {
            PageFactory.InitElements(driver: _driver, page: this);
        }
        

        public string Login(string username, string password)
        {
            HomePage hp = new HomePage();
            _driver.Manage().Window.Maximize();
            _userName.SendKeys(username);
            _password.SendKeys(password);
            _loginbtn.Click();
            string actualText =_applogo.Text;
          
            return actualText;
        }

        public IList<IWebElement> VerifyPriceFilterDropdownValues()
        {
            IWebElement allOptions = _pricefilters;
            SelectElement selectElement = new SelectElement(allOptions);
            IList<IWebElement> listOfOptions = selectElement.Options;
            for (int i = 0; i < listOfOptions.Count; i++)
            {
                String value = listOfOptions.ElementAt(i).Text;
                Console.WriteLine(value);
            }

            return listOfOptions;
        }
    }
}
