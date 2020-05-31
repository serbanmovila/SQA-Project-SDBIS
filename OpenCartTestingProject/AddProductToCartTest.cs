using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCartTestingProject.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTestingProject
{
    [TestClass]
    public class AddProductToCartTest
    {
        private IWebDriver driver;
        private MenuItemControl menuItem;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://opencart.abstracta.us/");
            menuItem = new MenuItemControl(driver);
        }


        [TestMethod]
        public void AddProductToCart()
        {
            menuItem.NavigateToShoppingCart();

        }
    }
}
