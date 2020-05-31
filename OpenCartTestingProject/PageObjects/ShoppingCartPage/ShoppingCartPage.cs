using OpenCartTestingProject.PageObjects.ShoppingCartPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestingProject.PageObjects.ShoppingCartPage
{
    class ShoppingCartPage
    {
        private IWebDriver driver;

        public ShoppingCartPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By cartProducts = By.CssSelector("form tbody tr");
        private IList<IWebElement> LstCartProducts => driver.FindElements(cartProducts);

        private By productName = By.CssSelector("form tbody tr td:nth-child(2) a");
        private IWebElement LblProductName(ShoppingCartBO shoppingCartBO) => LstCartProducts
           .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
           .FindElement(productName);

        private By quantity = By.CssSelector("input[name='quantity[96435]']");
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
        private IWebElement TxtPriceUnit(ShoppingCartBO shoppingCartBO) => LstCartProducts
            .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
            .FindElement(unitPrice);

        private By total = By.CssSelector("form tbody tr td:nth-child(6)");
        private IWebElement TxtTotal(ShoppingCartBO shoppingCartBO) => LstCartProducts
            .FirstOrDefault(element => element.Text.Contains(shoppingCartBO.ProductName))
            .FindElement(total);

        private By emptyCart = By.CssSelector("div[id=content] p");
        private IWebElement LblEmptyCart => driver.FindElement(emptyCart);
        private string EmptyCartText => LblEmptyCart.Text;

        private By successfullyUpdated = By.CssSelector("div.alert-success");
        private IWebElement LblSuccessfullyUpdated => driver.FindElement(successfullyUpdated);
        private string SuccessfullyUpdatedText => LblSuccessfullyUpdated.Text;
        

    }
}
