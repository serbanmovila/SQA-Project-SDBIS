using OpenCartTestingProject.PageObjects.ProductPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace OpenCartTestingProject.PageObjects.ProductPage
{
    class ProductPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private ProductPageBO productPageBO;

        public ProductPage(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private By actionsColumn = By.CssSelector("div.col-sm-4");
        private IList<IWebElement> LstActions => driver.FindElements(actionsColumn);

        private By quantity = By.CssSelector("input[name='quantity']");
        private IWebElement TxtQuantity(ProductPageBO productPageBO) => LstActions
            .FirstOrDefault(element => element.Text.Contains(productPageBO.ProductName))
            .FindElement(quantity);

        private By successfullyUpdated = By.CssSelector("div.alert-success");
        private IWebElement LblSuccessfullyUpdated => driver.FindElement(successfullyUpdated);
        public string SuccessfullyUpdatedText => LblSuccessfullyUpdated.Text;

        private By tabReview = By.CssSelector("a[href='#tab-review']");
        private IWebElement BtnTabReview => driver.FindElement(tabReview);

        private By addToWishList = By.CssSelector("button[data-original-title='Add to Wish List']");
        private IWebElement BtnAddToWishList => driver.FindElement(addToWishList);

        private By addToCart = By.CssSelector("div.button-group>button:first-child");
        private IWebElement BtnAddToCart(ProductPageBO productPageBO) => LstActions
            .FirstOrDefault(element => element.Text.Contains(productPageBO.ProductName))
            .FindElement(addToCart);

        private By wishListLabel = By.Id("wishlist-total");
        private IWebElement LblWishLabel => driver.FindElement(wishListLabel);

        public string SuccessfullyAddToWishList => LblWishLabel.Text;

        public void AddToCart()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(addToCart));
            BtnAddToCart(productPageBO).Click();
        }

        public void AddToWishList()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(addToWishList));
            BtnAddToWishList.Click();
        }

        public void OpenReviewTab()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(tabReview));
            BtnTabReview.Click();
        }
    }
}
