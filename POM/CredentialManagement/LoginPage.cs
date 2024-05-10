using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;


namespace Luma_Selenium
{
    public class LoginPage : CredentialManager
    {
        #region LoginPageLoactors
        private By emailTextbox = By.Id("email");
        private By passwordTextbox= By.Id("pass");
        private By loginButton = By.Name("send");
        private By welcomeSelector = By.CssSelector(".greet.welcome");
        #endregion

        #region LoginPageMethods
        public bool Login(String email, String password, String fullname="")
        {
            Step = Test.CreateNode("LoginPage");
            try
            {
                IWebElement signInButton = WaitForElement(driver, signInAnchor);
                Click(signInButton, "Open Sign in Page");
                IWebElement emailBox = WaitForElement(driver, emailTextbox);
                IWebElement passwordBox = WaitForElement(driver, passwordTextbox);
                IWebElement login = WaitForElement(driver, loginButton);
                Write(emailBox, email, "Enter email");
                Write(passwordBox, password, "Enter password");
                Click(login, "Login Button Clicked");
                Thread.Sleep(2000);
                IWebElement welcomeArea = WaitForElement(driver, welcomeSelector);
                String welcomeMessage = welcomeArea.Text;
                String actualMessage = "Welcome, " + fullname + "!";
                Assert.AreEqual(welcomeMessage, actualMessage, "Login Failed");
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
