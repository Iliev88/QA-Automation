using DesignPattern.Models;
using DesignPattern.Pages.HomePage;
using DesignPattern.Pages.RegistrationPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumDesignPatternsDemo.Models;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    [TestFixture]
    public class TestClass
    {
        public IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

        [Test]
        [Author("Iliya Iliev")]
        public void NavigateToRegistrationPage()
        {
            var homePage = new HomePage(driver);
            var registrationPage = new RegistrationPage(driver);

            homePage.NavigateTo();
            homePage.RegistrationButton.Click();

            registrationPage.AssertRegistrationPageIsOpen("Registration");
        }


        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastName()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutLastName");
            
            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutHobby()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutHobby");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertHobbiesErrorMessage("This field is required");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutPhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutPhone");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("This field is required");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithShortPhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithShortPhone");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("Minimum 10 Digits starting with Country Code");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithLongPhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithLongPhone");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("Minimum 10 Digits starting with Country Code");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutUsername()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutUsername");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertUsernameErrorMessage("This field is required");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutEmail");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmailErrorMessage("This field is required");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithWrongEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithWrongEmail");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmailErrorMessage("Invalid email address");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutPassword");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertPasswordErrorMessage("This field is required");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutConfirmationPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutConfirmationPassword");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertConfirmationPasswordErrorMessage("This field is required");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithshortPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithShortPassword");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertPasswordErrorMessage("Minimum 8 characters required");

        }

    }
}
