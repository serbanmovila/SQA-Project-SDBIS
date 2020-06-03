using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SQA_Centric.PageObjects;

namespace SQA_Centric.LoginTest
{
    [TestClass]
    public class LoginTest
    {
        private ChromeOptions options;
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void setUp()
        {
            options = new ChromeOptions();
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");

            driver = new ChromeDriver(options);
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us");
            loginPage.NavigateToLoginPage(driver);
        }

        [TestMethod]
        public void loginCorrectEmail()
        {
            LoginBO loginBO = new LoginBO();
            loginPage.LoginApplication(loginBO);

            var expectedResult = "My Account";
            var actualResult = driver.FindElement(By.CssSelector("#content > h2:nth-child(1)")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void loginIncorrectEmail()
        {
            LoginBO loginBO = new LoginBO();
            loginBO.email = "four@yahoo.com";
            loginPage.LoginApplication(loginBO);

            var expectedResult = "Returning Customer";
            var actualResult = driver.FindElement(By.CssSelector("#content > div > div:nth-child(2) > div > h2")).Text;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
