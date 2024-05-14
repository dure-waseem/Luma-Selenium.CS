using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class EditPage : Navigator
    {
        #region editPageLocators
        private String pageTitle = "Edit Account Information";
        private String editNewUrl = "https://magento.softwaretestingboard.com/customer/account/edit/";
        private By nameTextboxLocator = By.Id("firstname");
        private By saveLocator = By.CssSelector(".action.save.primary");
        private By confirmationTextLocator = By.CssSelector(".message-success.success.message");
        #endregion

        #region editPageMethods
        public bool EditButton(String newFirstName)
        {
            Step = Test.CreateNode("Account Information Page");
            changeURL(editNewUrl);
            bool changeStatus = VerifyPageOpen(pageTitle);
            if (changeStatus)
            {
                try
                {
                    IWebElement nameTextbox = WaitForElement(driver, nameTextboxLocator);
                    Clear(nameTextbox);
                    Write(nameTextbox, newFirstName, "Rewrite First Name");
                    IWebElement saveButton = WaitForElement(driver, saveLocator);
                    Click(saveButton, "Click save");
                    IWebElement confirmationBox = WaitForElement(driver, confirmationTextLocator);
                    string editConfirmationText = confirmationBox.Text;
                    string expectedText = "You saved the account information.";
                    Assert.AreEqual(expectedText, editConfirmationText);
                    return true;
                }catch(Exception ex)
                {
                    RaiseException(ex);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        #endregion
    }
}
