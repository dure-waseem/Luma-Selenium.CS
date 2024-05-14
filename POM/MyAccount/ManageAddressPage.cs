using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class ManageAddressPage : Navigator
    {
        #region addressPageLocators
        private String pageTitle = "Address Book";
        private String editNewUrl = "https://magento.softwaretestingboard.com/customer/address/";
        private String manageTitle = "Edit Address";
        private By actionBoxLocator = By.ClassName("box-actions");
        private By editActionLocator = By.CssSelector(".action.edit");
        private By addressBoxLocator = By.Id("street_1");
        private By saveButtonLocator = By.CssSelector(".action.save.primary");
        private By confirmationTextLocator = By.CssSelector(".message-success.success.message");
        #endregion

        #region addressPageMethods
        public bool ManageButton(String streetAddress)
        {
            Step = Test.CreateNode("Address Information Page");
            changeURL(editNewUrl);
            bool changeStatus = VerifyPageOpen(pageTitle);
            if (changeStatus)
            {
                try
                {
                    IWebElement parent = WaitForElement(driver, actionBoxLocator);
                    IWebElement child = WaitForParentElement(parent, editActionLocator);
                    Click(child, "Open Edit Menu");
                    bool addressPageChange = VerifyPageOpen(manageTitle);
                    if (addressPageChange)
                    {
                        IWebElement StreetAddressTextbox = WaitForElement(driver, addressBoxLocator);
                        Clear(StreetAddressTextbox);
                        Write(StreetAddressTextbox, streetAddress, "Enter new address");
                        IWebElement saveButton = WaitForElement(driver, saveButtonLocator);
                        Click(saveButton, "Click save");
                        IWebElement confirmationTextBox = WaitForElement(driver, confirmationTextLocator);
                        string editConfirmationText = confirmationTextBox.Text;
                        string expectedText = "You saved the address.";
                        Assert.AreEqual(expectedText, editConfirmationText);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception ex)
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
