using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCartTestingProject.Controls;
using OpenCartTestingProject.PageObjects.HomePage;
using OpenCartTestingProject.PageObjects.ProductListPage;
using OpenCartTestingProject.PageObjects.ProductPage;
using OpenCartTestingProject.PageObjects.ProductPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTestingProject
{
    [TestClass]
    public class AddProductToWishList
    {

        private IWebDriver driver;

        private HomePage homePage;
        private ProductListPage productListPage;
        private ProductPage productPage;

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
        public void AddToWishList()
        {            
            productPage.AddToWishList();

            String expectedResult = "Wish List (1)";

            Assert.AreEqual(expectedResult, productPage.SuccessfullyAddToWishList);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
