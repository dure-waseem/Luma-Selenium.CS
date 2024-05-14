using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class MyAccountPage : Navigator
    {
        #region AccountPageLocators
        private By navLocator = By.Id("customer-name");
        private String PageTitle = "My Account";
        private By accountPageLocator = By.CssSelector(".action.switch");
        private String accountNewUrl = "https://magento.softwaretestingboard.com/customer/account/";

        #endregion

        #region AccountPageMethods
        public bool EditButtonPage(String newFirstName)
        {
            Step = Test.CreateNode("Edit Account Information");
            IWebElement accountNav = WaitForElement(driver, accountPageLocator);
            Click(accountNav, "Open Account Page");
            changeURL(accountNewUrl);
            bool pageChangeStatus = VerifyPageOpen(PageTitle);
            if (pageChangeStatus)
            {
                EditPage editPage = new EditPage();
                return editPage.EditButton(newFirstName);
            }
            else
            {
                return false;
            }
        }
        public bool ManageAddressPage(String streetAddress)
        {
            Step = Test.CreateNode("Edit Addres Information");
            IWebElement accountNav = WaitForElement(driver, accountPageLocator);
            Click(accountNav, "Open Account Page");
            changeURL(accountNewUrl);
            bool pageChangeStatus = VerifyPageOpen(PageTitle);
            if (pageChangeStatus)
            {
                ManageAddressPage manageAddressPage = new ManageAddressPage();
                return manageAddressPage.ManageButton(streetAddress);
            }
            else
            {
                return false;
            }
            
        }
        #endregion
    }
}
