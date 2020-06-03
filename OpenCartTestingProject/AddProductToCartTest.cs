using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCartTestingProject.Controls;
using OpenCartTestingProject.PageObjects.HomePage;
using OpenCartTestingProject.PageObjects.ProductListPage;
using OpenCartTestingProject.PageObjects.ProductPage;
using OpenCartTestingProject.PageObjects.ProductPage.InputData;
using OpenCartTestingProject.PageObjects.ShoppingCartPage;
using OpenCartTestingProject.PageObjects.ShoppingCartPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTestingProject
{
    [TestClass]
    public class AddProductToCartTest
    {  
        private IWebDriver driver;
        private MenuItemControl menuItem;
        private HomePage homePage;
        private ProductListPage productListPage;
        private ShoppingCartPage shoppingCartPage;
        private ShoppingCartBO shoppingCartBO = new ShoppingCartBO();
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
            menuItem = new MenuItemControl(driver);
        }


        [TestMethod]
        public void AddProductToCart()
        {
            productListPage.AddToCartFirstProduct(shoppingCartBO);

            String expectedResult = "Success: You have added " + shoppingCartBO.ProductName + " to your shopping cart!\r\n×";
            Assert.AreEqual(expectedResult, productListPage.SuccessfullyAddedText);
        }

        [TestMethod]
        public void AddToCard_FromProductPage()
        {
            productPage = productListPage.NavigateToProductPage(driver);
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
