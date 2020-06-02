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

        private By estimateShipping = By.CssSelector("a[href='#collapse-shipping']");
        private IWebElement BtnEstimateShippingTaxes => driver.FindElement(estimateShipping);

        private By country = By.Id("input-country");
        private IWebElement DdlCountry => driver.FindElement(country);

        private By region =By.Id("input-zone");
        private IWebElement DdlRegion => driver.FindElement(region);

        private By postcode = By.Id("input-postcode");
        private IWebElement TxtPostcode => driver.FindElement(postcode);

        private By getQuotes = By.Id("button-quote");
        private IWebElement BtnGetQuotes => driver.FindElement(getQuotes);

        private By shippingMethod = By.CssSelector("input[name='shipping_method']:first-child");
        private IWebElement ChbShippingMethod => driver.FindElement(shippingMethod);

        private By errorCountry = By.CssSelector("select[id='input-country'] + div.text-danger");
        private IWebElement LblErrorCountry => driver.FindElement(errorCountry);
        public string ErrorCountryText => LblErrorCountry.Text;

        private By errorRegion = By.CssSelector("select[id='input-zone'] + div.text-danger");
        private IWebElement LblErrorRegion => driver.FindElement(errorRegion);
        public string ErrorRegionText => LblErrorRegion.Text;

        private By applyShipping = By.Id("button-shipping");
        private IWebElement BtnApplyShipping => driver.FindElement(applyShipping);

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

        public void EstimateShippingAndTaxes(ShoppingCartBO shoppingCartBO)
        {
            BtnEstimateShippingTaxes.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(country));
            var selectCountry = new SelectElement(DdlCountry);
            selectCountry.SelectByText(shoppingCartBO.Country);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var selectRegion = new SelectElement(DdlRegion);
            selectRegion.SelectByText(shoppingCartBO.Region);
            TxtPostcode.SendKeys(shoppingCartBO.Postcode);
            BtnGetQuotes.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(shippingMethod));
            ChbShippingMethod.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(applyShipping));
            BtnApplyShipping.Click();
        }

        public void EstimateShippingAndTaxes_WrongCountry(ShoppingCartBO shoppingCartBO)
        {
            BtnEstimateShippingTaxes.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(country));
            var selectCountry = new SelectElement(DdlCountry);
            selectCountry.SelectByText(shoppingCartBO.WrongCountry);
            BtnGetQuotes.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(errorCountry));
        }

        public void EstimateShippingAndTaxes_WrongRegion(ShoppingCartBO shoppingCartBO)
        {
            BtnEstimateShippingTaxes.Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(country));
            var selectCountry = new SelectElement(DdlCountry);
            selectCountry.SelectByText(shoppingCartBO.Country);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var selectRegion = new SelectElement(DdlRegion);
            selectRegion.SelectByText(shoppingCartBO.WrongRegion);
            BtnGetQuotes.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(errorRegion));
        }

    }
}
