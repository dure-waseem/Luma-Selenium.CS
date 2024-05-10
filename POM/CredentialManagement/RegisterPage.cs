using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Luma_Selenium
{
    public class RegisterPage : CredentialManager
    {
        #region RegistrationPageLocators
        private By createAccountButton= By.CssSelector(".action.create.primary");
        private By firstnameTextbox= By.Name("firstname");
        private By lastnameTextbox = By.Name("lastname");
        private By emailTextbox = By.Name("email");
        private By passwordTextbox = By.Name("password");
        private By passwordConfirmationTextbox = By.Name("password_confirmation");
        private By successMessageArea = By.CssSelector(".messages");
        #endregion

        #region RegistrationPageMethods
        public bool Register(String firstname, String lastName, String email, String password)
        {
            Step = Test.CreateNode("RegistrationPage");
            try
            {
                IWebElement signInButton = WaitForElement(driver, signInAnchor);
                Click(signInButton, "Open Sign in Page");
                IWebElement createButton = WaitForElement(driver, createAccountButton);
                Click(createButton, "Open Registration Page");
                IWebElement firstNameBox = WaitForElement(driver, firstnameTextbox);
                Write(firstNameBox, firstname, "Enter first name");
                IWebElement lastNameBox = WaitForElement(driver, lastnameTextbox);
                Write(lastNameBox, lastName, "Enter last name");
                IWebElement emailBox = WaitForElement(driver, emailTextbox);
                Write(emailBox, email, "Enter email");
                IWebElement passwordBox = WaitForElement(driver, passwordTextbox);
                Write(passwordBox, password, "Enter password");
                IWebElement passwordConfirmationBox = WaitForElement(driver, passwordConfirmationTextbox);
                Write(passwordConfirmationBox, password, "Enter password again");
                IWebElement submit = WaitForElement(driver, submitButton);
                Click(submit, "Register Button Clicked");
                IWebElement notificationBox = WaitForElement(driver, successMessageArea);
                String informationMessage = notificationBox.Text;
                Assert.AreEqual(informationMessage, "Thank you for registering with Main Website Store.", "Account Registration Failed");
                return true;

            } catch (Exception ex)
            {
                RaiseException(ex);
                return false;
            }
            
        }
        #endregion
    }
}
