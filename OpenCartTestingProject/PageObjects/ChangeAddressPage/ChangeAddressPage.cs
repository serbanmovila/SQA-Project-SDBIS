using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenCartTestingProject.ChangeAddressFieldsTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestingProject.PageObjects
{
    class ChangeAddressPage
    {
        private IWebDriver driver;

        public ChangeAddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement firstName => driver.FindElement(By.Id("input-firstname"));
        private IWebElement lastName => driver.FindElement(By.Id("input-lastname"));
        private IWebElement company => driver.FindElement(By.Id("input-company"));
        private IWebElement address1 => driver.FindElement(By.Id("input-address-1"));
        private IWebElement address2 => driver.FindElement(By.Id("input-address-2"));
        private IWebElement city => driver.FindElement(By.Id("input-city"));
        private IWebElement postCode => driver.FindElement(By.Id("input-postcode"));
        private IWebElement country => driver.FindElement(By.Id("input-country"));
        private IWebElement regionState => driver.FindElement(By.Id("input-zone"));
        private IWebElement defaultAddressYes => driver.FindElement(By.CssSelector("#content > form > fieldset > div:nth-child(10) > div > label:nth-child(1) > input[type=radio]"));
        private IWebElement defaultAddressNo => driver.FindElement(By.CssSelector("#content > form > fieldset > div:nth-child(10) > div > label:nth-child(2) > input[type=radio]"));
        private IWebElement saveBtn => driver.FindElement(By.CssSelector("#content > form > div > div.pull-right > input"));

        // changes only those fields that are not declared null
        public void ChangeAddress(ChangeAddressBO changeAddress)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("input-firstname")));

            if (changeAddress.firstName != null)
            {
                firstName.Clear();
                firstName.SendKeys(changeAddress.firstName);
            }

            if (changeAddress.lastName != null)
            {
                lastName.Clear();
                lastName.SendKeys(changeAddress.lastName);
            }

            if (changeAddress.company != null)
            {
                company.Clear();
                company.SendKeys(changeAddress.company);
            }

            if (changeAddress.address1 != null)
            {
                address1.Clear();
                address1.SendKeys(changeAddress.address1);
            }

            if (changeAddress.address2 != null)
            {
                address2.Clear();
                address2.SendKeys(changeAddress.address2);
            }

            if (changeAddress.city != null)
            {
                city.Clear();
                city.SendKeys(changeAddress.city);
            }

            if (changeAddress.postCode != null)
            {
                postCode.Clear();
                postCode.SendKeys(changeAddress.postCode);
            }

            if (changeAddress.country != null)
            {
                var select = new SelectElement(country);
                select.SelectByText(changeAddress.country);
            }

            if (changeAddress.regionState != null)
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("input-zone")));
                var select = new SelectElement(regionState);
                select.SelectByText(changeAddress.regionState);
            }

            if (changeAddress.defaultAddressYes == true)
            {
                defaultAddressYes.Click();
            }
            else
            {
                defaultAddressNo.Click();
            }

            saveBtn.Click();
        }
    }
}
