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
        [Author("Iliya Iliev")]
        public void RegisterWithValidData()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { true, true, false },
                                           new List<bool> { false, false, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0897675645",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssesrtSuccessMessage("Thank you for your registration");

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

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutHobby()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { true, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0897675645",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertHobbiesErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutPhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithShortPhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "088",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("Minimum 10 Digits starting with Country Code");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithLongPhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "08845654267564357656675667",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("Minimum 10 Digits starting with Country Code");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutUsername()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0884565426",
                                           "",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertUsernameErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0884565426",
                                           "lichkata456",
                                           "",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmailErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithWrongEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0884565426",
                                           "lichkata456",
                                           "lichkata456@abv.",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmailErrorMessage("Invalid email address");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0884565426",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertPasswordErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutConfirmationPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0884565426",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertConfirmationPasswordErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithShortPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0884565426",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "1",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertPasswordErrorMessage("Minimum 8 characters required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithUnmatchedPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0884565426",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "1234567");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertConfirmationPasswordErrorMessage("Fields do not match");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastNameAndPhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");
            registrationPage.AssertMissingPhoneErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastNameAndUsername()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0877191899",
                                           "",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");
            registrationPage.AssertUsernameErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastNameAndEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0877191899",
                                           "lichkata456",
                                           "",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");
            registrationPage.AssertEmailErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutLastNameAndWrongEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0877191899",
                                           "lichkata456",
                                           "lichkata456@abv.",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");
            registrationPage.AssertEmailErrorMessage("Invalid email address");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutHobbiesAndUsername()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, true, true },
                                           new List<bool> { true, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0877191899",
                                           "",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertHobbiesErrorMessage("This field is required");
            registrationPage.AssertUsernameErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithoutUsernameAndPassword()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, true, true },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0877191899",
                                           "",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertUsernameErrorMessage("This field is required");
            registrationPage.AssertPasswordErrorMessage("This field is required");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithNegativePhone()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "-0878675645",
                                           "lichkata456",
                                           "lichkata456@abv.bg",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("Minimum 10 Digits starting with Country Code");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithNegativePhoneAndWrongEmail()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "-0878675645",
                                           "lichkata456",
                                           "lichkata456@abv.",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "12345678");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertMissingPhoneErrorMessage("Minimum 10 Digits starting with Country Code");
            registrationPage.AssertEmailErrorMessage("Invalid email address");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithWrongEmailAndMismatchedPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0878675645",
                                           "lichkata456",
                                           "lichkata456@abv.",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "12345678",
                                           "123456789");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);
            
            registrationPage.AssertEmailErrorMessage("Invalid email address");
            registrationPage.AssertConfirmationPasswordErrorMessage("Fields do not match");

        }

        [Test]
        [Property("Priority", 2)]
        [Author("Iliya Iliev")]
        public void RegisterWithWrongEmailAndMismatchedAndShortPasswords()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = new RegistrateUser("",
                "Iliya",
                                          "Iliev",
                                           new List<bool> { false, false, false },
                                           new List<bool> { false, true, true },
                                           "Bulgaria",
                                           "3",
                                           "17",
                                           "1987",
                                           "0878675645",
                                           "lichkata456",
                                           "lichkata456@abv.",
                                           @"C:\Users\Iliya\Desktop\photo.jpeg",
                                           "ALA BALA",
                                           "1234567",
                                           "123456789");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertEmailErrorMessage("Invalid email address");
            registrationPage.AssertPasswordErrorMessage("Minimum 8 characters required");
            registrationPage.AssertConfirmationPasswordErrorMessage("Fields do not match");

        }
    }
}
