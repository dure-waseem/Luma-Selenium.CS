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
    public class ShippingPage : BaseClass
    {
        #region ShippingPageLocators
        private By addAddressLocator = By.CssSelector(".action.action-show-popup");
        private By firstnameLocator = By.Name("firstname");
        private By lastnameLocator = By.Name("lastname");
        private By companyLocator = By.Name("company");
        private By addressLocator = By.Name("street[0]");
        private By cityLocator = By.Name("city");
        private By regionLocator = By.Name("region_id");
        private By postcodeLocator = By.Name("postcode");
        private By telephoneLocator = By.Name("telephone");
        private By checkboxLocator = By.Id("shipping-save-in-address-book");
        private By submitLocator = By.CssSelector(".action.primary.action-save-address");
        private By shippingAddressLocator = By.ClassName("shipping-address-item");
        private By shipButtonLocator = By.CssSelector(".action.action-select-shipping-item");
        private By tableLocator = By.CssSelector(".table-checkout-shipping-method");
        private By tableRowLocator = By.TagName("tr");
        private By inputLocator = By.TagName("input");
        #endregion
        #region ShippingPageMethods
        public bool ShippingAddress()
        {
            try
            {
                IWebElement addShippingAddressButton = WaitForElement(driver, addAddressLocator);
                Click(addShippingAddressButton, "Add New Address");
                IWebElement firstName = WaitForElement(driver, firstnameLocator);
                Clear(firstName);
                Write(firstName, "Dure", "Enter first name");
                IWebElement lastName = WaitForElement(driver, lastnameLocator);
                Clear(lastName);
                Write(lastName, "Wahaj", "Enter last name");
                IWebElement company = WaitForElement(driver, companyLocator);
                Clear(company);
                Write(company, "Idhar Udhar", "Enter company name");
                IWebElement address = WaitForElement(driver, addressLocator);
                Clear(address);
                Write(address, "Ghar per", "Enter Address");
                IWebElement city = WaitForElement(driver, cityLocator);
                Clear(city);
                Write(city, "Shehar e Kachrachi", "Enter city name");
                IWebElement region = WaitForElement(driver, regionLocator);
                var select = new SelectElement(region);
                select.SelectByIndex(2);
                IWebElement postcode = WaitForElement(driver, postcodeLocator);
                Clear(postcode);
                Write(postcode, "75850", "Enter postcode");
                IWebElement telephone = WaitForElement(driver, telephoneLocator);
                Clear(telephone);
                Write(telephone, "0311-jab karo jab band", "Enter telephone number");
                IWebElement checkbox = WaitForElement(driver, checkboxLocator);
                Click(checkbox, "Check the box");
                IWebElement submitButton = WaitForElement(driver, submitLocator);
                Click(submitButton, "Click submit button");
                IList<IWebElement> shippingAddresses = WaitForElements(driver, shippingAddressLocator);
                IWebElement currentTarget = shippingAddresses[0];
                IWebElement shipButton = WaitForParentElement(currentTarget, shipButtonLocator);
                Click(shipButton, "Click Ship Button");
                return true;
            }catch(Exception ex)
            {
                RaiseException(ex);
                return false;
            }
            
        }

        public bool ShippingMethods(String shippingMethods)
        {
            IWebElement table = WaitForElement(driver, tableLocator);
            if(table != null)
            {
                IList<IWebElement> tableRows = WaitForParentElements(table, tableRowLocator);
                IWebElement selector = null;
                if (shippingMethods == "Table Rate")
                {
                    selector = WaitForParentElement(tableRows[0], inputLocator);
                }
                else
                {
                    selector = WaitForParentElement(tableRows[1], inputLocator);
                }
                Click(selector, shippingMethods);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        #endregion



    }
}
