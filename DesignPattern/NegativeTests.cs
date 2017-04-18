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
using System.Configuration;
using NUnit.Framework.Interfaces;
using System.IO;

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
            var logFile = ConfigurationManager.AppSettings["Logs"] + "log" + ".txt";
            File.AppendAllText(logFile, TestContext.CurrentContext.Result.Outcome + " ... " +
                TestContext.CurrentContext.Test.FullName + " ... " +
                TestContext.CurrentContext.Test.Name + Environment.NewLine);

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var fileNameLog = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";

                if (File.Exists(fileNameLog))
                {
                    File.Delete(fileNameLog);
                }
                File.WriteAllText(fileNameLog, TestContext.CurrentContext.Test.FullName + " ... " + TestContext.CurrentContext.Result.FailCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                var fileNameScreenshot = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name;

                if (File.Exists(fileNameScreenshot))
                {
                    File.Delete(fileNameScreenshot);
                }
                screenshot.SaveAsFile(fileNameScreenshot + ".jpeg", ScreenshotImageFormat.Jpeg);
            }
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
        public void RegisterWithShortPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithShortPassword");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertPasswordErrorMessage("Minimum 8 characters required");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithUnmatchedPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithUnmatchedPasswords");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertConfirmationPasswordErrorMessage("Fields do not match");

        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastNameAndPhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutLastNameAndPhone");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");
            registrationPage.AssertMissingPhoneErrorMessage("This field is required");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastNameAndUsername()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutLastNameAndUsername");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");
            registrationPage.AssertUsernameErrorMessage("This field is required");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastNameAndEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutLastNameAndEmail");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");
            registrationPage.AssertEmailErrorMessage("This field is required");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastNameAndWrongEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutLastNameAndWrongEmail");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");
            registrationPage.AssertEmailErrorMessage("Invalid email address");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutHobbiesAndUsername()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutHobbiesAndUsername");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertHobbiesErrorMessage("This field is required");
            registrationPage.AssertUsernameErrorMessage("This field is required");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutUsernameAndPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutUsernameAndPassword");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertUsernameErrorMessage("This field is required");
            registrationPage.AssertPasswordErrorMessage("This field is required");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithNegativePhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithNegativePhone");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithNegativePhoneAndWrongEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithNegativePhoneAndWrongEmail");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("Minimum 10 Digits starting with Country Code");
            registrationPage.AssertEmailErrorMessage("Invalid email address");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithWrongEmailAndMismatchedPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithWrongEmailAndMismatchedPasswords");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmailErrorMessage("Invalid email address");
            registrationPage.AssertConfirmationPasswordErrorMessage("Fields do not match");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterWithWrongEmailAndMismatchedAndShortPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithWrongEmailAndMismatchedAndShortPasswords");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmailErrorMessage("Invalid email address");
            registrationPage.AssertPasswordErrorMessage("Minimum 8 characters required");
            registrationPage.AssertConfirmationPasswordErrorMessage("Fields do not match");
        }

        [Test]
        [Property("Negative Tests", 1)]
        [Author("Iliya Iliev")]
        public void RegisterAlreadyRegisteredUser()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterAlreadyRegisteredUser");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertAlreadyRegisteredUserErrorMessage("Error: Username already exists");
        }

    }
}
