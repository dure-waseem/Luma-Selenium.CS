using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class Navigator : BaseClass
    {
        #region NavigatorLocators
        private By pageLocator = By.ClassName("page-title");
        #endregion
        public bool VerifyPageOpen(String pageTitle)
        {
            try
            {
                IWebElement pageHeaderTextBox = WaitForElement(driver, pageLocator);
                String pageConfirmationText = pageHeaderTextBox.Text;
                Assert.AreEqual(pageTitle, pageConfirmationText);
                return true;

            }catch(Exception ex)
            {
                RaiseException(ex);
                return false;
            }
                
        }
        public bool InitializePage(By selector, String pageTitle)
        {
            driver.FindElement(selector).Click();
            bool pageStatus = VerifyPageOpen(pageTitle);
            HandleStatus(pageStatus, "Page Ready", "Page Does not exist");
            return pageStatus;
        }

    }
}
