using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class MenPage : Navigator
    {
        #region MenLocators
        private By navLocator = By.Id("ui-id-5");
        private String pageTitle = "Men";
        private By menLumaLocator = By.CssSelector(".block-promo.mens-main");
        private By menTeeLocator = By.CssSelector(".block-promo.mens-t-shirts");
        private By menPantsLocator = By.CssSelector(".block-promo.mens-pants");
        private By menShortsLocator = By.CssSelector(".block-promo.mens-category-shorts");
        private By lumaTeeLocator = By.CssSelector(".block-promo.mens-category-tees");
        private By menHoodiesLocator = By.CssSelector(".block-promo.mens-category-hoodies");
        #endregion

        #region MenMethods
        public bool LumaPerformanceCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("MenLumaPerformanceCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement performanceCollectionLink = WaitForElement(driver, menLumaLocator);
                    Click(performanceCollectionLink, "Open Performance Collections");
                    LumaPerformanceFabricCollectionPage newLumaYogaCollectionPage = new LumaPerformanceFabricCollectionPage();
                    return newLumaYogaCollectionPage.AddFabricItemToCart(itemname, size, color);
                }
                catch (Exception ex)
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
        public bool TeeCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("MenTeeCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement teeCollectionLink = WaitForElement(driver, menTeeLocator);
                    Click(teeCollectionLink, "Open Tee Collections");
                    MenTeesCollectionsPage menTeesCollectionPage = new MenTeesCollectionsPage();
                    return menTeesCollectionPage.AddTeeItemToCart(itemname, size, color);
                }
                catch (Exception ex)
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
        public bool PantCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("MenPantCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement pantsCollectionLink = WaitForElement(driver, menPantsLocator);
                    Click(pantsCollectionLink, "Open Pants Collections");
                    MenPantsCollectionPage pantsCollectionsPage = new MenPantsCollectionPage();
                    return pantsCollectionsPage.AddPantsToCart(itemname, size, color);
                }
                catch (Exception ex)
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
        public bool ShortCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("MenShortCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement shortsCollectionLink = WaitForElement(driver, menShortsLocator);
                    Click(shortsCollectionLink, "Open Shorts Collections");
                    MenShortsCollectionPage shortsCollectionsPage = new MenShortsCollectionPage();
                    return shortsCollectionsPage.AddShortsToCart(itemname, size, color);
                }
                catch (Exception ex)
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
        public bool LumaTees(String itemname, String size, String color)
        {
            Step = Test.CreateNode("MenLumaTeesCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement lumaTeeCollectionLink = WaitForElement(driver, lumaTeeLocator);
                    Click(lumaTeeCollectionLink, "Open Luma Tee Collections");
                    MenTeesCollectionsPage menTeesCollectionPage = new MenTeesCollectionsPage();
                    return menTeesCollectionPage.AddTeeItemToCart(itemname, size, color);
                }
                catch (Exception ex)
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
        public bool HoodiesAndSweatshirts(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Add a Hoodie Item From Men");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement hoodieCollectionLink = WaitForElement(driver, menHoodiesLocator);
                    Click(hoodieCollectionLink, "Open Hoodie Collections");
                    MenHoodiesAndSweatshirtsPage menHoodiesAndSweatshirtsCollectionPage = new MenHoodiesAndSweatshirtsPage();
                    return menHoodiesAndSweatshirtsCollectionPage.AddHoodieItemToCart(itemname, size, color);
                }
                catch (Exception ex)
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
        public bool HotSellers(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Hot Seller Item");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                try
                {
                    DeleteAd();
                    return ItemAnalyzer.AddToCartByHover(itemname, size, color, ".product-item", true);
                }
                catch (Exception ex)
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
