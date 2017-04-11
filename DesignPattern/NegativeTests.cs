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
        [Property("Priority", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastName()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutLastName");
            
            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");

        }

        
    }
}
