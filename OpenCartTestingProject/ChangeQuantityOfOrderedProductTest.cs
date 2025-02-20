﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCartTestingProject.Controls;
using OpenCartTestingProject.PageObjects.HomePage;
using OpenCartTestingProject.PageObjects.ProductListPage;
using OpenCartTestingProject.PageObjects.ShoppingCartPage;
using OpenCartTestingProject.PageObjects.ShoppingCartPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTestingProject
{
    [TestClass]
    public class ChangeQuantityOfOrderedProductTest
    {
        private ChromeOptions options;
        private IWebDriver driver;
        private MenuItemControl menuItem;
        private HomePage homePage;
        private ProductListPage productListPage;
        private ShoppingCartPage shoppingCartPage;
        private ShoppingCartBO shoppingCartBO = new ShoppingCartBO();

        [TestInitialize]
        public void TestInitialize()
        {
            options = new ChromeOptions();
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/");
            menuItem = new MenuItemControl(driver);
            homePage = new HomePage(driver);
            productListPage = homePage.NavigateToTabletsProductList(driver);
            productListPage.AddToCartFirstProduct(shoppingCartBO);
            shoppingCartPage = menuItem.NavigateToShoppingCart(driver);

        }

        [TestMethod]
        public void ChangeQuantity_CorrectValue()
        {
            shoppingCartPage.UpdateQuantity(shoppingCartBO);
            String expectedResult = "Success: You have modified your shopping cart!\r\n×";
            Assert.AreEqual(expectedResult, shoppingCartPage.SuccessfullyUpdatedText);
            Double expectedTotal = Math.Round(shoppingCartPage.CalculateLineTotal(shoppingCartBO),0);
            Double actualTotal = Math.Round(shoppingCartPage.GetTotal(shoppingCartBO),0);
            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod]
        public void ChangeQuantity_WrongValue()
        {
            shoppingCartPage.UpdateWrongQuantity(shoppingCartBO);
            String expectedResult = "Your shopping cart is empty!";
            Assert.AreEqual(expectedResult, shoppingCartPage.EmptyCartText);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
