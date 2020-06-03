using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCartTestingProject.LoginTest;
using OpenCartTestingProject.PageObjects;
using OpenCartTestingProject.PageObjects;

namespace OpenCartTestingProject.ChangeAddressFieldsTest
{
    [TestClass]
    public class ChangeAddressFieldsTest
    {
        private ChromeOptions options;
        private IWebDriver driver;
        private ChangeAddressPage changeAddressPage;

        [TestInitialize]
        public void setUp()
        {
            options = new ChromeOptions();
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://opencart.abstracta.us");

            var loginPage = new LoginPage(driver);
            loginPage.NavigateToLoginPage(driver);

            LoginBO loginBO = new LoginBO();
            loginPage.LoginApplication(loginBO);

            var myAccountPage = new MyAccountPage(driver);
            myAccountPage.NavigateToMyAccountPage(driver);

            var addressPage = new AddressPage(driver);
            addressPage.NavigateToAddressPage(driver);

            changeAddressPage = new ChangeAddressPage(driver);

        }
        [TestMethod]
        public void ChangeAddressFirstName()
        {
            ChangeAddressBO changeAddressBO = new ChangeAddressBO();
            changeAddressPage.ChangeAddress(changeAddressBO);

            var expectedResult = "https://opencart.abstracta.us/index.php?route=account/address";
            var actualResult = driver.Url;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ChangeAddressFirstNameNULL()
        {
            ChangeAddressBO changeAddressBO = new ChangeAddressBO();
            changeAddressBO.firstName = "";
            changeAddressPage.ChangeAddress(changeAddressBO);

            var expectedResult = "https://opencart.abstracta.us/index.php?route=account/address/edit&address_id=5803";
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
