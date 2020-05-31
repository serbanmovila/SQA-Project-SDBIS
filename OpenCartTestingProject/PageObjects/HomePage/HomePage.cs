using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCartTestingProject.PageObjects.ProductListPage;

namespace OpenCartTestingProject.PageObjects.HomePage
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        private By tablets = By.CssSelector("ul.nav>li:nth-child(4)");
        private IWebElement BtnTablets => driver.FindElement(tablets);

        public ProductListPage.ProductListPage NavigateToTabletsProductList(IWebDriver driver)
        {
            BtnTablets.Click();
            return new ProductListPage.ProductListPage(driver);
        }
    }
}
