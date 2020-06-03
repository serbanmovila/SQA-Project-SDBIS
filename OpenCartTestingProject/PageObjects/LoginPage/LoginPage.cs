using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenCartTestingProject.LoginTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestingProject.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        By logregBy = By.CssSelector("#top-links > ul > li.dropdown");
        IWebElement logregDropdown => driver.FindElement(logregBy);

        By loginBy = By.CssSelector("#top-links > ul > li.dropdown.open > ul > li:nth-child(2) > a");
        IWebElement loginBtn => driver.FindElement(loginBy);

        public void NavigateToLoginPage(IWebDriver driver)
        {
            logregDropdown.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(loginBy));
            loginBtn.Click();
        }

        private By mail = By.Id("input-email");
        private IWebElement email => driver.FindElement(mail);

        private By pass = By.Id("input-password");
        private IWebElement password => driver.FindElement(pass);

        private By logClick = By.CssSelector("#content > div > div:nth-child(2) > div > form > input");
        private IWebElement loginClick => driver.FindElement(logClick);

        public void LoginApplication(LoginBO loginBO)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(mail));

            email.SendKeys(loginBO.email);
            password.SendKeys(loginBO.password);

            loginClick.Click();
        }
    }
}
