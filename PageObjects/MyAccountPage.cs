using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQA_Centric.PageObjects
{
    class MyAccountPage
    {
        private IWebDriver driver;

        public MyAccountPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By accDropdown = By.CssSelector("#top-links > ul > li.dropdown");
        private IWebElement accDropdownBtn => driver.FindElement(accDropdown);

        private By myAcc = By.CssSelector("#top-links > ul > li.dropdown.open > ul > li:nth-child(1)");
        private IWebElement myAccBtn => driver.FindElement(myAcc);

        public void NavigateToMyAccountPage(IWebDriver driver)
        {
            accDropdownBtn.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(myAcc));
            myAccBtn.Click();
        }
    }
}
