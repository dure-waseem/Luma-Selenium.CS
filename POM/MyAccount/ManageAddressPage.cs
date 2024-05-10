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
        String pageTitle = "Address Book";
        String editNewUrl = "https://magento.softwaretestingboard.com/customer/address/";
        String manageTitle = "Edit Address";
        public void ManageButton(String streetAddress)
        {
            driver.Navigate().GoToUrl(editNewUrl);
            VerifyPageOpen(pageTitle);
            IWebElement parent = driver.FindElement(By.ClassName("box-actions"));
            IWebElement child = parent.FindElement(By.CssSelector(".action.edit"));
            child.Click();
            VerifyPageOpen(manageTitle);
            IWebElement StreetAddressTextbox = driver.FindElement(By.Id("street_1"));
            StreetAddressTextbox.Clear();
            StreetAddressTextbox.SendKeys(streetAddress);
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(".action.save.primary")).Click();
            Thread.Sleep(10000);
            string editConfirmationText = driver.FindElement(By.CssSelector(".message-success.success.message")).Text;
            string expectedText = "You saved the address.";
            Assert.AreEqual(expectedText, editConfirmationText);

        }

    }
}
