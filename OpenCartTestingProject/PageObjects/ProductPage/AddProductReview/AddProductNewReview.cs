using OpenCartTestingProject.PageObjects.ProductPage.AddProductReview.InputData;
using OpenCartTestingProject.PageObjects.ShoppingCartPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace OpenCartTestingProject.PageObjects.ProductPage.AddProductReview
{
    class AddProductNewReview
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        public AddProductNewReview(IWebDriver browser)
        {
            driver = browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(createReview));
        }

        private By name = By.Id("input-name");
        private IWebElement TxtName => driver.FindElement(name);

        private By review = By.Id("input-review");
        private IWebElement TxtReview => driver.FindElement(review);

        private By rating = By.XPath("//input[@name='rating']");
        private IList<IWebElement> LstRating => driver.FindElements(rating);

        private By createReview = By.Id("button-review");
        private IWebElement BtnCreateReview => driver.FindElement(createReview);

        private By successfullyUpdated = By.CssSelector("div.alert.alert-success");
        private IWebElement LblSuccessfullyUpdated => driver.FindElement(successfullyUpdated);

        public string SuccessfullyUpdated => LblSuccessfullyUpdated.Text;

        private By errorUpdate = By.CssSelector("div.alert.alert-danger");
        private IWebElement LblErrorUpdated => driver.FindElement(errorUpdate);

        public string ErrorUpdatedText => LblErrorUpdated.Text;


        public void CreateReviewSuccess(AddProductNewReviewBO addReviewBo)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(name));
            TxtName.SendKeys(addReviewBo.Name);
            TxtReview.SendKeys(addReviewBo.ReviewSuccess);
            LstRating[addReviewBo.Rating].Click();
            
            BtnCreateReview.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(successfullyUpdated));
        }

        public void CreateReviewWithError(AddProductNewReviewBO addReviewBo)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(name));
            TxtName.SendKeys(addReviewBo.Name);
            TxtReview.SendKeys(addReviewBo.ReviewError);
            LstRating[addReviewBo.Rating].Click();

            BtnCreateReview.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(errorUpdate));
        }
    }
}
