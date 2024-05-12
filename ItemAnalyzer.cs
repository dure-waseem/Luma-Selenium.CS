using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Luma_Selenium
{
    
    public class ItemAnalyzer : BaseClass
    {
        #region ItemAnalyzerLocators
        private static String itemNameLocator = ".product-item-name a";
        private static String scrollScript = "window.scrollTo(0, document.body.scrollHeight)";
        private static By itemBox = By.CssSelector(".product-item-details");
        private static By selectAll = By.TagName("*");
        private static String swatchOptionsSelector = "swatch-opt";
        private static By sizeSwatchLocator = By.CssSelector(".swatch-attribute.size");
        private static By ColorSwatchLocator = By.CssSelector(".swatch-attribute.color");
        private static By sizeOptionsLocator = By.CssSelector(".swatch-option.text");
        private static By colorOptionsLocator = By.CssSelector(".swatch-option.color");
        private static String colorAttribute = "option-label";
        private static By addToCartLocator = By.CssSelector(".action.tocart.primary");
        private static By successLocator = By.ClassName("message-success");
        private static By cartIconLocator = By.CssSelector(".action.showcart");
        private static By checkoutButtonLocator = By.CssSelector(".action.primary.checkout");
        private static By nextButtonLocator = By.CssSelector(".button.action.continue.primary");
        private static By pageTitleLocator = By.ClassName("page-title");
        private static By cartItemsLocator = By.ClassName("minicart-items");
        private static String cartMenuItemSelector = ".item.product.product-item";
        private static String cartMenuNameSelector = ".product-item-name";
        private static By priceLocator = By.ClassName("price-wrapper");
        private static By quantityBoxLocator = By.ClassName("details-qty");
        private static By quantityInputLocator = By.TagName("input");
        private static String inputBoxDataSelector = "data-item-qty";
        private static By pricePerItemBoxLocator = By.ClassName("product-item-pricing");
        private static By pricerPerItemValueLocator = By.ClassName("price-container");
        private static String clearScript = "arguments[0].value = '';";
        private static By updateButtonLocator = By.ClassName("update-cart-item");
        private static String quantitySelector = "data-item-qty";
        private static By deleteButtonLocator = By.CssSelector(".action.delete");
        private static By popupOkayLocator = By.CssSelector(".action-primary.action-accept");
        private static By editQuantityInputLocator = By.CssSelector(".input-text.qty");
        private static By editButtonLocator = By.CssSelector(".action.edit");
        private static By addToCartButtonLocator = By.CssSelector(".action.primary.tocart");
        private static By notificationLocator = By.ClassName("messages");
        #endregion
        #region ItemAnalyzerMethods
        private static IWebElement FindElementByName(String itemsSelector, String nameSelector, String productName)
        {
            IList<IWebElement> items = WaitForElements(driver, By.CssSelector(itemsSelector));
            IWebElement target = null;
            foreach (IWebElement parentElement in items)
            {
                try
                {
                    if (parentElement != null)
                    {
                        IWebElement element = WaitForParentElement(parentElement, By.CssSelector(nameSelector));
                        string itemText = element.Text;
                        if (itemText == productName)
                        {
                            target = parentElement;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }catch(Exception e)
                {
                    RaiseException(e);
                }
                
            }
            return target;
        }
        private static IWebElement FindElementByParentName(IWebElement parent, String itemsSelector, String nameSelector, String productName)
        {
            IList<IWebElement> items = WaitForParentElements(parent, By.CssSelector(itemsSelector));
            IWebElement target = null;
            foreach (IWebElement parentElement in items)
            {
                try
                {
                    if (parentElement != null)
                    {
                        IWebElement element = WaitForParentElement(parentElement, By.CssSelector(nameSelector));
                        string itemText = element.Text;
                        if (itemText == productName)
                        {
                            target = parentElement;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception e)
                {
                    RaiseException(e);
                }

            }
            return target;
        }
        public static bool AddToCartByHover(String productName, String size, String color, String itemsSelector, bool swatchExists)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(scrollScript);
            IWebElement target = FindElementByName(itemsSelector, itemNameLocator, productName);
            Console.WriteLine("Found the target");
            if(target != null)
            {
                if (swatchExists == true)
                {
                    try
                    {
                        IWebElement overallBox = WaitForParentElement(target, itemBox);
                        IList<IWebElement> childElements = WaitForParentElements(overallBox, selectAll);
                        IWebElement targetParent = null;
                        foreach (IWebElement element in childElements)
                        {
                            String childClass = element.GetAttribute("class");
                            if (childClass.StartsWith(swatchOptionsSelector))
                            {
                                targetParent = element;
                                break;
                            }
                        }
                        if(targetParent != null)
                        {
                            IWebElement targetSizeSwatch = WaitForParentElement(targetParent, sizeSwatchLocator);
                            IWebElement targetColorSwatch = WaitForParentElement(targetParent, ColorSwatchLocator);
                            IList<IWebElement> sizeOptions = WaitForParentElements(targetSizeSwatch, sizeOptionsLocator);
                            IList<IWebElement> colorOptions = WaitForParentElements(targetColorSwatch, colorOptionsLocator);
                            IWebElement targetSize = null, targetColor = null;
                            for (int i = 0; i < sizeOptions.Count; i++)
                            {
                                string itemSize = sizeOptions[i].Text;
                                if (itemSize == size)
                                {
                                    targetSize = sizeOptions[i];
                                }
                            }
                            for (int i = 0; i < colorOptions.Count; i++)
                            {
                                string itemColor = colorOptions[i].GetAttribute(colorAttribute);
                                if (itemColor == color)
                                {
                                    targetColor = colorOptions[i];
                                }
                            }
                            Click(targetSize, "Selected Target Size");
                            Click(targetColor, "Selected Target Color");
                        }
                        else
                        {
                            return false;
                        }
                        

                    }catch(Exception ex)
                    {
                        RaiseException(ex);
                    }
                }
                else { }
                try
                {
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(target).Perform();
                    IWebElement cartButton = WaitForParentElement(target, addToCartLocator);
                    Click(cartButton, "Clicked Add to Cart");
                    IWebElement successArea = WaitForElement(driver, successLocator);
                    String successText = successArea.Text;
                    String expectedText = "You added " + productName + " to your shopping cart.";
                    Assert.AreEqual(successText, expectedText, "Failed to Add to Cart");
                    return true;
                }
                catch(Exception ex ) 
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
        private static void OpenCartMenu()
        {
            IWebElement cartIcon = WaitForElement(driver, cartIconLocator);
            Click(cartIcon, "Opened Cart");
        }
        private static bool ManageCartUpdateCost(IWebElement target, string newQuantity)
        {
            try
            {
                IWebElement initialPriceBox = WaitForElement(driver, priceLocator);
                String initialPrice = initialPriceBox.Text;
                float initialPriceAsFloat = ConvertStringToFloat(initialPrice);
                Thread.Sleep(2000);
                IWebElement quantityBox = WaitForParentElement(target, quantityBoxLocator);
                IWebElement inputBox = WaitForParentElement(quantityBox, quantityInputLocator);
                String initialQuantity = inputBox.GetAttribute(inputBoxDataSelector);
                Console.WriteLine(initialQuantity);
                IWebElement pricePerItemBox = WaitForParentElement(target, pricePerItemBoxLocator);
                IWebElement pricePerItemValueBox = WaitForParentElement(pricePerItemBox, pricerPerItemValueLocator);
                String pricePerItemString = pricePerItemValueBox.Text;
                float pricePerItem = ConvertStringToFloat(pricePerItemString);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(clearScript, inputBox);
                Write(inputBox, newQuantity, "Update Item Quantity");
                IWebElement updateButton = WaitForParentElement(quantityBox, updateButtonLocator);
                Click(updateButton, "Update Quantity");
                Thread.Sleep(5000);
                IWebElement finalPriceBox = WaitForElement(driver, priceLocator);
                String finalPrice = finalPriceBox.Text;
                float finalPriceAsFloat = ConvertStringToFloat(finalPrice);
                float difference = ConvertStringToFloat(newQuantity) - ConvertStringToFloat(initialQuantity);
                float finalDifference = pricePerItem * difference;
                float targetPrice = finalDifference + initialPriceAsFloat;
                Assert.AreEqual(finalPriceAsFloat, targetPrice, "Invalid Additions");
                return true;
            }catch(Exception ex)
            {
                RaiseException(ex);
                return false;
            }
            
        }
        public static bool UpdateQuantityInCartMenu(String productName, string newQuantity)
        {
            Thread.Sleep(2000);
            Step = Test.CreateNode("Update Item Quantity In Cart");
            OpenCartMenu();
            Thread.Sleep(2000);
            IWebElement cart = WaitForElement(driver, cartItemsLocator);
            IWebElement target = FindElementByParentName(cart, cartMenuItemSelector, cartMenuNameSelector, productName);
            if (target != null)
            {
                Thread.Sleep(5000);
                return ManageCartUpdateCost(target, newQuantity);
            }
            else
            {
                return false;
            }

        }
        public static bool DeleteItemFromCartMenu(String productName)
        {
            Step = Test.CreateNode("Delete Cart Item");
            Thread.Sleep(2000);
            OpenCartMenu();
            Thread.Sleep(2000);
            IWebElement cart = WaitForElement(driver, cartItemsLocator);
            IWebElement target = FindElementByParentName(cart, cartMenuItemSelector, cartMenuNameSelector, productName);

            if (target != null)
            {
                IWebElement initialPriceBox = WaitForElement(driver, priceLocator);
                String initialPrice = initialPriceBox.Text;
                float initialPriceAsFloat = ConvertStringToFloat(initialPrice);
                Thread.Sleep(2000);
                IWebElement quantityBox = WaitForParentElement(target, quantityBoxLocator);
                IWebElement inputBox = WaitForParentElement(quantityBox, quantityInputLocator);
                String initialQuantity = inputBox.GetAttribute(inputBoxDataSelector);
                Console.WriteLine(initialQuantity);
                IWebElement pricePerItemBox = WaitForParentElement(target, pricePerItemBoxLocator);
                IWebElement pricePerItemValueBox = WaitForParentElement(pricePerItemBox, pricerPerItemValueLocator);
                String pricePerItemString = pricePerItemValueBox.Text;
                float pricePerItem = ConvertStringToFloat(pricePerItemString);
                String quantity = inputBox.GetAttribute(quantitySelector);
                IWebElement deleteButton = WaitForParentElement(target, deleteButtonLocator);
                Click(deleteButton, "Delete the Item");
                IWebElement okayButton = WaitForElement(driver, popupOkayLocator);
                Click(okayButton, "Confirm Deletion");
                Thread.Sleep(5000);
                float difference = pricePerItem * ConvertStringToFloat(quantity);
                IWebElement finalPriceBox = WaitForElement(driver, priceLocator);
                String finalPrice = finalPriceBox.Text;
                float finalPriceAsFloat = ConvertStringToFloat(finalPrice);
                float expectedPrice = initialPriceAsFloat - difference;
                Assert.AreEqual(finalPriceAsFloat, expectedPrice, "Wrong Cart Cost After Deletion");
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UpdateItemInCartByEditMenu(String productName, String newQuantity,String itemSize, String itemColor, bool swatchOptions)
        {
            Step = Test.CreateNode("Update Cart Item");
            Thread.Sleep(2000);
            OpenCartMenu();
            IWebElement cart = WaitForElement(driver, cartItemsLocator);
            IWebElement target = FindElementByParentName(cart, cartMenuItemSelector, cartMenuNameSelector, productName);
            if(target != null)
            {
                IWebElement editButton = WaitForParentElement(target, editButtonLocator);
                Click(editButton, "Click Edit Button");
                if (swatchOptions)
                {

                }
                IWebElement quantityBox = WaitForElement(driver, editQuantityInputLocator);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(clearScript, quantityBox);
                Write(quantityBox, newQuantity, "Enter Quantity");
                IWebElement addToCartButton = WaitForElement(driver, addToCartButtonLocator);
                Click(addToCartButton, "Add to Cart");
                IWebElement notification = WaitForElement(driver, notificationLocator);
                String notificationText = notification.Text;
                String expectedText = productName + " was updated in your shopping cart.";
                Assert.AreEqual(notificationText, expectedText, "Could not update item");
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckoutPageByCartMenu()
        {
            Step = Test.CreateNode("Checkout Page");
            OpenCartMenu();
            IWebElement checkoutButton = WaitForElement(driver, checkoutButtonLocator);
            Click(checkoutButton, "Click on Checkout");
            DeleteAd();
            ShippingPage shippingPage = new ShippingPage();
            bool shippingStatus = shippingPage.ShippingAddress();
            HandleStatus(shippingStatus, "Successfully Added Address", "Couldn't Add Address");
            if (shippingStatus)
            {
                bool methodStatus = shippingPage.ShippingMethods("Flat Rate");
                if (methodStatus)
                {
                    try
                    {
                        IWebElement nextButton = WaitForElement(driver, nextButtonLocator);
                        Click(nextButton, "Move on to next page");
                        ReviewAndPaymentsPage reviewAndPaymentsPage = new ReviewAndPaymentsPage();
                        bool reviewPaymentStatus = reviewAndPaymentsPage.placeOrder();
                        HandleStatus(reviewPaymentStatus, "Payment Success", "Payment Failed");
                        if (reviewPaymentStatus)
                        {
                            Thread.Sleep(10000);
                            IWebElement titleBox = WaitForElement(driver, pageTitleLocator);
                            String successPageHeader = titleBox.Text;
                            Assert.AreEqual(successPageHeader, "Thank you for your purchase!", "Unsuccessful Checkout");
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
                    }catch(Exception e)
                    {
                        RaiseException(e);
                        return false;
                    }
                    
                }
                else
                {
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
