using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class GearPage : Navigator
    {
        #region GearLocators
        By navLocator = By.Id("ui-id-6");
        String pageTitle = "Gear";

        #endregion

        #region GearMethods
        public void SpriteYogaCompanionKit(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.gear-main")).Click();
            SpriteYogaCompanionKitPage spriteYogaCompanionKitPage = new SpriteYogaCompanionKitPage();
            spriteYogaCompanionKitPage.AddYogaItemToCart(itemname, size, color);
        }
        public void FitnessItem(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.gear-fitnes")).Click();
            FitnessEquipmentsPage fitnessEquipmentsPage = new FitnessEquipmentsPage();
            fitnessEquipmentsPage.AddFitnessItemToCart(itemname, size, color);
        }
        public void PromoItem(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.gear-equipment")).Click();
            FitnessEquipmentsPage fitnessEquipmentsPage = new FitnessEquipmentsPage();
            fitnessEquipmentsPage.AddFitnessItemToCart(itemname, size, color);
        }
        public void BagItem(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.gear-category-bags")).Click();
            BagsPage bagsPage = new BagsPage();
            bagsPage.AddBagItemToCart(itemname, size, color);
        }
        public void GymItem(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.gear-category-equipment")).Click();
            FitnessEquipmentsPage fitnessEquipmentsPage = new FitnessEquipmentsPage();
            fitnessEquipmentsPage.AddFitnessItemToCart(itemname, size, color);
        }
        public void WatchItem(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.gear-category-watches")).Click();
            WatchesPage watchesPage = new WatchesPage();
            watchesPage.AddWatchItemToCart(itemname, size, color);
        }
        public void HotSellers(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            ItemAnalyzer.AddToCartByHover(itemname, size, color, ".product-item", false);
        }
        #endregion



    }
}
