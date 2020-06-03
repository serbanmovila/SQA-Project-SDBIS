using OpenCartTestingProject.PageObjects.ShoppingCartPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace OpenCartTestingProject.PageObjects.ProductListPage
{
    class ProductListPage
    {
        //clasa pentru pagina cu lista de produse
        private IWebDriver driver;
        private WebDriverWait wait;

        public ProductListPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(addToCart));
        }

        private By products = By.CssSelector("div[id='content']>div:nth-child(3)>div");
        private IList<IWebElement> LstProducts => driver.FindElements(products);

        private By addToCart = By.CssSelector("div.button-group>button:first-child");
        private IWebElement BtnAddToCart(ShoppingCartBO shoppingCartBO) => LstProducts
            .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
            .FindElement(addToCart);

        private By successfullyAdded = By.CssSelector("div.alert-success");
        private IWebElement LblSuccessfullyAdded => driver.FindElement(successfullyAdded);
        public string SuccessfullyAddedText => LblSuccessfullyAdded.Text;
        private By openProductPage = By.CssSelector("div.caption>h4>a");
        private IWebElement BtnOpenProductPage() => driver.FindElement(openProductPage);


        public void AddToCartFirstProduct(ShoppingCartBO shoppingCartBO)
        {
            BtnAddToCart(shoppingCartBO).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(successfullyAdded));
            Thread.Sleep(1000);
        }
        public ProductPage.ProductPage NavigateToProductPage(IWebDriver driver)
        {
            BtnOpenProductPage().Click();

            return new ProductPage.ProductPage(driver);
        }
    }
}
