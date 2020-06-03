using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCartTestingProject.PageObjects;

namespace OpenCartTestingProject.RegisterTest
{
    [TestClass]
    public class RegisterTest
    {
        private ChromeOptions options;
        private IWebDriver driver;
        private RegisterPage registerPage;

        [TestInitialize]
        public void setUp()
        {
            options = new ChromeOptions();
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");

            driver = new ChromeDriver(options);
            registerPage = new RegisterPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us");
            registerPage.NavigateToRegisterPage(driver);
        }

        [TestMethod]
        public void registerCorrectly()
        {
            RegisterBO registerBO = new RegisterBO();
            registerPage.RegisterApplication(registerBO);

            var expectedResult = "http://opencart.abstracta.us/index.php?route=account/success";
            var actualResult = driver.Url;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void registerShortPassword()
        {
            RegisterBO registerBO = new RegisterBO();
            registerBO.password = "123";
            registerBO.passwordConfirm = "123";
            registerBO.email = "nine@yahoo.com";
            registerPage.RegisterApplication(registerBO);

            var expectedResult = "https://opencart.abstracta.us/index.php?route=account/register";
            var actualResult = driver.Url;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}

