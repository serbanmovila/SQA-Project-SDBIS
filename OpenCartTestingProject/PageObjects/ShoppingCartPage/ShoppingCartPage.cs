using OpenCartTestingProject.PageObjects.ShoppingCartPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace OpenCartTestingProject.PageObjects.ShoppingCartPage
{
    class ShoppingCartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ShoppingCartPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(quantity));
        }

        private By cartProducts = By.CssSelector("form tbody tr");
        private IList<IWebElement> LstCartProducts => driver.FindElements(cartProducts);

        private By productName = By.CssSelector("form tbody tr td:nth-child(2) a");
        private IWebElement LblProductName(ShoppingCartBO shoppingCartBO) => LstCartProducts
           .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
           .FindElement(productName);

        private By quantity = By.CssSelector("tbody input");
        private IWebElement TxtQuantity(ShoppingCartBO shoppingCartBO) => LstCartProducts
            .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
            .FindElement(quantity);

        private By update = By.CssSelector("button[data-original-title='Update']");
        private IWebElement BtnUpdate(ShoppingCartBO shoppingCartBO) => LstCartProducts
            .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
            .FindElement(update);

        private By remove = By.CssSelector("button[data-original-title='Remove']");
        private IWebElement BtnRemove(ShoppingCartBO shoppingCartBO) => LstCartProducts
            .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
            .FindElement(remove);

        private By unitPrice = By.CssSelector("form tbody tr td:nth-child(5)");
        private IWebElement LblPriceUnit(ShoppingCartBO shoppingCartBO) => LstCartProducts
            .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
            .FindElement(unitPrice);

        private By total = By.CssSelector("form tbody tr td:nth-child(6)");
        private IWebElement LblTotal(ShoppingCartBO shoppingCartBO) => LstCartProducts
            .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
            .FindElement(total);

        private By emptyCart = By.CssSelector("div[id=content] p");
        private IWebElement LblEmptyCart => driver.FindElement(emptyCart);
        public string EmptyCartText => LblEmptyCart.Text;

        private By successfullyUpdated = By.CssSelector("div.alert-success");
        private IWebElement LblSuccessfullyUpdated => driver.FindElement(successfullyUpdated);
        public string SuccessfullyUpdatedText => LblSuccessfullyUpdated.Text;
        
        public void UpdateQuantity(ShoppingCartBO shoppingCartBO)
        {
            TxtQuantity(shoppingCartBO).Clear();
            TxtQuantity(shoppingCartBO).SendKeys(shoppingCartBO.Quantity);
            BtnUpdate(shoppingCartBO).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(successfullyUpdated));
        }

        public void UpdateWrongQuantity(ShoppingCartBO shoppingCartBO)
        {
            TxtQuantity(shoppingCartBO).Clear();
            TxtQuantity(shoppingCartBO).SendKeys(shoppingCartBO.WrongQuantity);
            BtnUpdate(shoppingCartBO).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(emptyCart));
        }

        public void RemoveProduct(ShoppingCartBO shoppingCartBO)
        {
            BtnRemove(shoppingCartBO).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(emptyCart));
        }

        public Double CalculateLineTotal(ShoppingCartBO shoppingCartBO)
        {
            var priceUnit = Convert.ToDouble(LblPriceUnit(shoppingCartBO).Text.Remove(0, 1));
            var qty = Convert.ToDouble(TxtQuantity(shoppingCartBO).GetAttribute("value"));
            return priceUnit*qty;
        }

        public Double GetTotal(ShoppingCartBO shoppingCartBO)
        {
            return Convert.ToDouble(LblTotal(shoppingCartBO).Text.Remove(0, 1));
        }
    }
}
