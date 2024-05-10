using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Luma_Selenium
{
    public class ReviewAndPaymentsPage : BaseClass {

        #region ReviewPaymentLocators
        private By placeOrderButtonLocator = By.CssSelector(".action.primary.checkout");
        #endregion
        #region ReviewPaymentMethods

        public bool placeOrder()
        {
            try
            {
                IWebElement placeOrderButton = WaitForElement(driver, placeOrderButtonLocator);
                Thread.Sleep(2000);
                Click(placeOrderButton, "Place Order");
                return true;

            }catch(Exception ex)
            {
                RaiseException(ex);
                return false;
            }
            
        }
        #endregion



    }
}
