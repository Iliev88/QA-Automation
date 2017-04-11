using OpenQA.Selenium;
using SeleniumDesignPatternsDemo.Models;
using System.Collections.Generic;

namespace DesignPattern.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver)
            :base(driver)
        {
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
        }

        public void FillRegistrationForm(RegistrateUser user)
        {
            Type(FirstName, user.FirstName);
            Type(LastName, user.LastName);
            ClickOnElements(MartialStatus, user.MartialStatus);
            ClickOnElements(Hobbies, user.Hobbies);
            CountryOption.SelectByText(user.Country);
            MonthOption.SelectByText(user.BirthMonth);
            DayOption.SelectByText(user.BirthDay);
            YearOption.SelectByText(user.BirthYear);
            Type(Phone, user.Phone);
            Type(UserName, user.UserName);
            Type(Email, user.Email);
            UploadButton.Click();
            Driver.SwitchTo().ActiveElement().SendKeys(user.Picture);
            Type(Description, user.Description);
            Type(Password, user.Password);
            Type(ConfirmPassword, user.ConfirmPassword);
            SubmitButton.Click();
        }

        private void ClickOnElements(List<IWebElement> elements, string conditions)
        {
            var choices = conditions.Split();

            for (int i = 0; i < choices.Length; i++)
            {
                if (choices[i].Equals("true"))
                {
                    elements[i].Click();
                }
            }
        }

        private void Type(IWebElement element, string text)
        {
            element.Click();
            if (!text.Equals("String.Empty"))
            {
                element.SendKeys(text);
            }
        }


    }
}
