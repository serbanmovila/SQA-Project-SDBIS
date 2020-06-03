using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SQA_Centric.RegisterTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SQA_Centric.PageObjects
{
    class RegisterPage
    {
        private IWebDriver driver;

        public RegisterPage(IWebDriver browser)
        {
            driver = browser;
        }

        By logregBy = By.CssSelector("#top-links > ul > li.dropdown");
        IWebElement logregDropdown => driver.FindElement(logregBy);

        By registerBy = By.CssSelector("#top-links > ul > li.dropdown.open > ul > li:nth-child(1) > a");
        IWebElement registerBtn => driver.FindElement(registerBy);

        public void NavigateToRegisterPage(IWebDriver driver)
        {
            logregDropdown.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(registerBy));
            registerBtn.Click();
        }

        private IWebElement firstName => driver.FindElement(By.Id("input-firstname"));
        private IWebElement lastName => driver.FindElement(By.Id("input-lastname"));
        private IWebElement email => driver.FindElement(By.Id("input-email"));
        private IWebElement telephone => driver.FindElement(By.Id("input-telephone"));
        private IWebElement fax => driver.FindElement(By.Id("input-fax"));
        private IWebElement company => driver.FindElement(By.Id("input-company"));
        private IWebElement address1 => driver.FindElement(By.Id("input-address-1"));
        private IWebElement address2 => driver.FindElement(By.Id("input-address-2"));
        private IWebElement city => driver.FindElement(By.Id("input-city"));
        private IWebElement postCode => driver.FindElement(By.Id("input-postcode"));
        private IWebElement country => driver.FindElement(By.Id("input-country"));
        private IWebElement regionState => driver.FindElement(By.Id("input-zone"));
        private IWebElement password => driver.FindElement(By.Id("input-password"));
        private IWebElement passwordConfirm => driver.FindElement(By.Id("input-confirm"));
        private IWebElement subscribeYes => driver.FindElement(By.CssSelector("#content > form > fieldset:nth-child(4) > div > div > label:nth-child(1) > input[type=radio]"));
        private IWebElement subscribeNo => driver.FindElement(By.CssSelector("#content > form > fieldset:nth-child(4) > div > div > label:nth-child(2) > input[type=radio]"));
        private IWebElement privacyPolicy => driver.FindElement(By.CssSelector("#content > form > div > div > input[type=checkbox]:nth-child(2)"));
        private IWebElement confirmBtn => driver.FindElement(By.CssSelector("#content > form > div > div > input.btn.btn-primary"));

        public void RegisterApplication(RegisterBO registerBO)
        {
            if (registerBO.firstName != null)
            {
                firstName.Clear();
                firstName.SendKeys(registerBO.firstName);
            }

            if (registerBO.lastName != null)
            {
                lastName.Clear();
                lastName.SendKeys(registerBO.lastName);
            }

            if (registerBO.email != null)
            {
                email.Clear();
                email.SendKeys(registerBO.email);
            }

            if (registerBO.telephone != null)
            {
                telephone.Clear();
                telephone.SendKeys(registerBO.company);
            }

            if (registerBO.fax != null)
            {
                fax.Clear();
                fax.SendKeys(registerBO.company);
            }

            if (registerBO.company != null)
            {
                company.Clear();
                company.SendKeys(registerBO.company);
            }

            if (registerBO.address1 != null)
            {
                address1.Clear();
                address1.SendKeys(registerBO.address1);
            }

            if (registerBO.address2 != null)
            {
                address2.Clear();
                address2.SendKeys(registerBO.address2);
            }

            if (registerBO.city != null)
            {
                city.Clear();
                city.SendKeys(registerBO.city);
            }

            if (registerBO.postCode != null)
            {
                postCode.Clear();
                postCode.SendKeys(registerBO.postCode);
            }

            if (registerBO.country != null)
            {
                var select = new SelectElement(country);
                select.SelectByText(registerBO.country);
            }

            if (registerBO.regionState != null)
            {
                //waiting for regionState text to be available
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='" + registerBO.regionState + "']")));

                var select = new SelectElement(regionState);
                select.SelectByText(registerBO.regionState);
            }

            if (registerBO.password != null)
            {
                password.Clear();
                password.SendKeys(registerBO.password);
            }

            if (registerBO.passwordConfirm != null)
            {
                passwordConfirm.Clear();
                passwordConfirm.SendKeys(registerBO.passwordConfirm);
            }

            if (registerBO.subscribe == true)
            {
                subscribeYes.Click();
            }
            else
            {
                subscribeNo.Click();
            }

            if (registerBO.agreePrivacyPolicy == true)
            {
                privacyPolicy.Click();
            }

            confirmBtn.Click();
        }
    }
}
