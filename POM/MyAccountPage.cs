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
        #region TrainingLocators
        By navLocator = By.Id("customer-name");
        String PageTitle = "My Account";
        String accountNewUrl = "https://magento.softwaretestingboard.com/customer/account/";

        #endregion

        #region TrainingMethods
        public void EditButtonPage(String newFirstName)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".action.switch")).Click();
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl(accountNewUrl);
            VerifyPageOpen(PageTitle);
            EditPage editPage = new EditPage();
            editPage.EditButton(newFirstName);
        }
        public void ManageAddressPage(String streetAddress)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".action.switch")).Click();
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl(accountNewUrl);
            VerifyPageOpen(PageTitle);
            ManageAddressPage manageAddressPage = new ManageAddressPage();
            manageAddressPage.ManageButton(streetAddress);






        }



        #endregion



    }
}
