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
        String pageTitle = "Edit Account Information";
        String editNewUrl = "https://magento.softwaretestingboard.com/customer/account/edit/";

        public void EditButton(String newFirstName)
        {
            driver.Navigate().GoToUrl(editNewUrl);

            VerifyPageOpen(pageTitle);
            IWebElement nameTextbox = driver.FindElement(By.Id("firstname"));

            nameTextbox.Clear();
            nameTextbox.SendKeys(newFirstName);
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".action.save.primary")).Click();

            string editConfirmationText = driver.FindElement(By.CssSelector(".message-success.success.message")).Text;
            string expectedText = "You saved the account information.";
            Assert.AreEqual(expectedText, editConfirmationText);

        }


    }
}
