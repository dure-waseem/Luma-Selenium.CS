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
        By navLocator = By.Id("ui-id-5");
        String pageTitle = "Men";

        #endregion

        #region MenMethods
        public void LumaPerformanceCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.mens-main")).Click();
            LumaPerformanceFabricCollectionPage newLumaYogaCollectionPage = new LumaPerformanceFabricCollectionPage();
            newLumaYogaCollectionPage.AddFabricItemToCart(itemname, size, color);
        }
        public void TeeCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.mens-t-shirts")).Click();
            MenTeesCollectionsPage menTeesCollectionPage = new MenTeesCollectionsPage();
            menTeesCollectionPage.AddTeeItemToCart(itemname, size, color);
        }
        public void PantCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.mens-pants")).Click();
            MenPantsCollectionPage pantsCollectionsPage = new MenPantsCollectionPage();
            pantsCollectionsPage.AddPantsToCart(itemname, size, color);
        }
        public void ShortCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.mens-category-shorts")).Click();
            MenShortsCollectionPage shortsCollectionsPage = new MenShortsCollectionPage();
            shortsCollectionsPage.AddShortsToCart(itemname, size, color);
        }
        public void LumaTees(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.mens-category-tees")).Click();
            MenTeesCollectionsPage menTeesCollectionPage = new MenTeesCollectionsPage();
            menTeesCollectionPage.AddTeeItemToCart(itemname, size, color);
        }
        public void HoodiesAndSweatshirts(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.mens-category-hoodies")).Click();
            MenHoodiesAndSweatshirtsPage menHoodiesAndSweatshirtsCollectionPage = new MenHoodiesAndSweatshirtsPage();
            menHoodiesAndSweatshirtsCollectionPage.AddHoodieItemToCart(itemname, size, color);
        }
        public void HotSellers(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            ItemAnalyzer.AddToCartByHover(itemname, size, color, ".product-item", true);
        }
        #endregion



    }
}
