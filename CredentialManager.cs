using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class CredentialManager : BaseClass
    {
        #region CredentialManagerLocators
        public By signInAnchor = By.ClassName("authorization-link");
        public By submitButton = By.CssSelector(".action.submit.primary");
        #endregion
    }
}
