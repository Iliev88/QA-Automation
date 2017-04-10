using OpenQA.Selenium;

namespace DesignPattern.Pages.HomePage
{
    public partial class HomePage
    {
        public IWebElement RegistrationButton
        {
            get
            {
                return Driver.FindElement(By.PartialLinkText("Registration"));
            }
        }
    }
}
