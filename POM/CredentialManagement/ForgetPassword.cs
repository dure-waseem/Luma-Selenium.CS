using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class ForgetPasswordPage : CredentialManager
    {
        #region forgetPasswordPageLocators
        private By forgetPasswordAnchor = By.CssSelector(".action.remind");
        private By emailTextbox = By.Id("email_address");
        private By notifcationSelector = By.CssSelector(".message-success.success.message");
        #endregion

        #region forgetPasswordPageMethods
        public bool ForgetPassword(String email)
        {
            Step = Test.CreateNode("ForgetPage");
            try
            {
                IWebElement signInButton = WaitForElement(driver, signInAnchor);
                Click(signInButton, "Open Sign in Page");
                IWebElement forgetPassword = WaitForElement(driver, forgetPasswordAnchor);
                Click(forgetPassword, "Cloick Forget Password Button");
                IWebElement emailBox = WaitForElement(driver, emailTextbox);
                Write(emailBox, email, "Enter email");
                IWebElement submit = WaitForElement(driver, submitButton);
                Click(submit, "Click Submit Button");
                IWebElement notificationBox = WaitForElement(driver, notifcationSelector);
                string ForgetMsg = notificationBox.Text;
                String actualMessage = "If there is an account associated with " + email + " you will receive an email with a link to reset your password.";
                Assert.AreEqual(ForgetMsg, actualMessage, "Forget password not working");
                return true;
            }catch (Exception ex)
            {
                RaiseException(ex);
                return false;
            }
            
        }
        #endregion
    }
}
