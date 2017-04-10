using NUnit.Framework;

namespace DesignPattern.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertRegistrationPageIsOpen(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssesrtSuccessMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        public static void AssertNamesErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForNames.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForNames.Text);
        }

        public static void AssertMissingPhoneErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForMissingPhone.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForMissingPhone.Text);
        }

        public static void AssertHobbiesErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForHobbies.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForHobbies.Text);
        }

        public static void AssertUsernameErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForMissingUsername.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForMissingUsername.Text);
        }

        public static void AssertEmailErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForMissingEmail.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForMissingEmail.Text);
        }

        public static void AssertPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForMissingPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForMissingPassword.Text);
        }

        public static void AssertConfirmationPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForMissingConfirmationPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForMissingConfirmationPassword.Text);
        }
    }
}
