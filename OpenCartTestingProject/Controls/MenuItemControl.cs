using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestingProject.Controls
{
    class MenuItemControl
    {
        public IWebDriver driver;
        private WebDriverWait wait;

        public MenuItemControl(IWebDriver browser)
        {
            driver = browser;
        }

        private By shoppingCart = By.CssSelector("div[id = 'top-links'] ul li:nth-child(4) a");
        public IWebElement BtnShoppingCart => driver.FindElement(shoppingCart);

        public void NavigateToShoppingCart()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(shoppingCart));
            BtnShoppingCart.Click();
        }
    }
}
