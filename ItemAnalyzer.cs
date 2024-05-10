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
        private static void ManageCartUpdateCost(IWebElement target, string newQuantity)
        {
            String initialPrice = driver.FindElement(By.ClassName("price-wrapper")).Text;
            float initialPriceAsFloat = ConvertStringToFloat(initialPrice);
            IWebElement quantityBox = target.FindElement(By.CssSelector(".details-qty.qty"));
            IWebElement inputBox = quantityBox.FindElement(By.TagName("input"));
            String initialQuantity = inputBox.GetAttribute("data-item-qty");
            IWebElement pricePerItemBox = target.FindElement(By.ClassName("product-item-pricing"));
            String pricePerItemString = pricePerItemBox.FindElement(By.ClassName("price-container")).Text;
            float pricePerItem = ConvertStringToFloat(pricePerItemString);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value = '';", inputBox);
            inputBox.SendKeys(newQuantity);
            quantityBox.FindElement(By.ClassName("update-cart-item")).Click();
            Thread.Sleep(5000);
            String finalPrice = driver.FindElement(By.ClassName("price-wrapper")).Text;
            float finalPriceAsFloat = ConvertStringToFloat(finalPrice);
            float difference = ConvertStringToFloat(newQuantity) - ConvertStringToFloat(initialQuantity);
            float finalDifference = pricePerItem * difference;
            float targetPrice = finalDifference + initialPriceAsFloat;
            Assert.AreEqual(finalPriceAsFloat, targetPrice, "Invalid Additions");
        }
        public static void UpdateQuantityInCartMenu(String productName, string newQuantity)
        {
            Thread.Sleep(2000);
            OpenCartMenu();
            IWebElement target = FindElementByName(".item.product.product-item", ".product-item-name", productName);

            if (target != null)
            {
                ManageCartUpdateCost(target, newQuantity);
            }

        }
        public static void DeleteItemFromCartMenu(String productName)
        {
            Thread.Sleep(2000);
            OpenCartMenu();
            IWebElement target = FindElementByName(".item.product.product-item", ".product-item-name", productName);

            if (target != null)
            {
                String initialPrice = driver.FindElement(By.ClassName("price-wrapper")).Text;
                float initialPriceAsFloat = ConvertStringToFloat(initialPrice);
                IWebElement quantityBox = target.FindElement(By.CssSelector(".details-qty.qty"));
                IWebElement inputBox = quantityBox.FindElement(By.TagName("input"));
                String quantity = inputBox.GetAttribute("data-item-qty");
                IWebElement pricePerItemBox = target.FindElement(By.ClassName("product-item-pricing"));
                String pricePerItemString = pricePerItemBox.FindElement(By.ClassName("price-container")).Text;
                float pricePerItem = ConvertStringToFloat(pricePerItemString);
                IWebElement deleteButton = target.FindElement(By.CssSelector(".action.delete"));
                deleteButton.Click();
                IWebElement okayButton = driver.FindElement(By.CssSelector(".action-primary.action-accept"));
                okayButton.Click();
                Thread.Sleep(10000);
                float difference = pricePerItem * ConvertStringToFloat(quantity);
                String finalPrice = driver.FindElement(By.ClassName("price-wrapper")).Text;
                float finalPriceAsFloat = ConvertStringToFloat(finalPrice);
                float expectedPrice = initialPriceAsFloat - difference;
                Assert.AreEqual(finalPriceAsFloat, expectedPrice, "Wrong Cart Cost After Deletion");
            }
        }
        public static void UpdateItemInCartByEditMenu(String productName, String newQuantity,String itemSize, String itemColor, bool swatchOptions)
        {
            Thread.Sleep(2000);
            OpenCartMenu();
            IWebElement target = FindElementByName(".item.product.product-item", ".product-item-name", productName);
            if(target != null)
            {
                IWebElement editButton = target.FindElement(By.CssSelector(".action.edit"));
                editButton.Click();
                if (swatchOptions)
                {

                }
                IWebElement quantityBox = driver.FindElement(By.CssSelector(".input-text.qty"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].value = '';", quantityBox);
                quantityBox.SendKeys(newQuantity);
                IWebElement addToCartButton = driver.FindElement(By.CssSelector(".action.primary.tocart"));
                addToCartButton.Click();
                IWebElement notification = driver.FindElement(By.ClassName("messages"));
                String notificationText = notification.Text;
                String expectedText = productName + " was updated in your shopping cart.";
                Assert.AreEqual(notificationText, expectedText, "Could not update item");
            }
        }
        public static bool CheckoutPageByCartMenu()
        {
            Step = Test.CreateNode("Checkout Page");
            OpenCartMenu();
            IWebElement checkoutButton = WaitForElement(driver, checkoutButtonLocator);
            Click(checkoutButton, "Click on Checkout");
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
