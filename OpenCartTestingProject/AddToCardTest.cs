using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCartTestingProject.Controls;
using OpenCartTestingProject.PageObjects.HomePage;
using OpenCartTestingProject.PageObjects.ProductListPage;
using OpenCartTestingProject.PageObjects.ProductPage;
using OpenCartTestingProject.PageObjects.ProductPage.AddProductReview;
using OpenCartTestingProject.PageObjects.ProductPage.AddProductReview.InputData;
using OpenCartTestingProject.PageObjects.ProductPage.InputData;
using OpenCartTestingProject.PageObjects.ShoppingCartPage;
using OpenCartTestingProject.PageObjects.ShoppingCartPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTestingProject
{
    [TestClass]
    public class AddToCardTest
    {
        private IWebDriver driver;

        private HomePage homePage;
        private ProductListPage productListPage;
        private ProductPage productPage;
        private ProductPageBO productPageBO = new ProductPageBO();

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/");
            homePage = new HomePage(driver);
            productListPage = homePage.NavigateToTabletsProductList(driver);
            productPage = productListPage.NavigateToProductPage(driver);
        }

        [TestMethod]
        public void AddToCard()
        {
            productPage.AddToCart();

            String expectedResult = "Success: You have added " + productPageBO.ProductName + " to your shopping cart!\r\n×";
            
            Assert.AreEqual(expectedResult, productPage.SuccessfullyUpdatedText);
        }

         [TestCleanup]
         public void Cleanup()
        {
            driver.Quit();
        }
    }
}
