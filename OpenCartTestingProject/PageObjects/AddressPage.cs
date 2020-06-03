using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestingProject.PageObjects
{
    class AddressPage
    {
        private IWebDriver driver;

        public AddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By addressBook = By.CssSelector("#column-right > div > a:nth-child(4)");
        private IWebElement addressBookBtn => driver.FindElement(addressBook);

        private By edit = By.CssSelector("#content > div.table-responsive > table > tbody > tr > td.text-right > a.btn.btn-info");
        private IWebElement editBtn => driver.FindElement(edit);
        public void NavigateToAddressPage(IWebDriver driver)
        {
            addressBookBtn.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(edit));
            editBtn.Click();

        }
    }
}
