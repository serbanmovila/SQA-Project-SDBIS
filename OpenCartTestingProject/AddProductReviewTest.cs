﻿using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCartTestingProject.Controls;
using OpenCartTestingProject.PageObjects.HomePage;
using OpenCartTestingProject.PageObjects.ProductListPage;
using OpenCartTestingProject.PageObjects.ProductPage;
using OpenCartTestingProject.PageObjects.ProductPage.AddProductReview;
using OpenCartTestingProject.PageObjects.ProductPage.AddProductReview.InputData;
using OpenCartTestingProject.PageObjects.ProductPage.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTestingProject
{
    [TestClass]
    public class AddProductReviewTest
    {
        private IWebDriver driver;

        private HomePage homePage;
        private ProductListPage productListPage;
        private ProductPage productPage;
        private AddProductNewReview AddProductNewReview;
        private AddProductNewReviewBO addProductNewReviewBO = new AddProductNewReviewBO();

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/");
            homePage = new HomePage(driver);
            productListPage = homePage.NavigateToTabletsProductList(driver);
            productPage = productListPage.NavigateToProductPage(driver);
            AddProductNewReview = productPage.OpenReviewTab(driver);
        }

        [TestMethod]
        public void AddReviewSuccessfully()
        {
            AddProductNewReview.CreateReviewSuccess( addProductNewReviewBO);
            String expectedResult = "Thank you for your review. It has been submitted to the webmaster for approval.";
            Assert.AreEqual(expectedResult, AddProductNewReview.SuccessfullyUpdated);
        }

        [TestMethod]
        public void AddReviewWithError()
        {
            AddProductNewReview.CreateReviewWithError(addProductNewReviewBO);

            String expectedResult = "Warning: Review Text must be between 25 and 1000 characters!";

            Assert.AreEqual(expectedResult, AddProductNewReview.ErrorUpdatedText);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
