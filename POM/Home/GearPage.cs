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
        private By navLocator = By.Id("ui-id-6");
        private String pageTitle = "Gear";
        private By yogaKitLocator = By.CssSelector(".block-promo.gear-main");
        private By fitnessLocator = By.CssSelector(".block-promo.gear-fitnes");
        private By promoLocator = By.CssSelector(".block-promo.gear-equipment");
        private By bagLocator = By.CssSelector(".block-promo.gear-category-bags");
        private By gymItemLocator = By.CssSelector(".block-promo.gear-category-equipment");
        private By watchLocator = By.CssSelector(".block-promo.gear-category-watches");
        #endregion

        #region GearMethods
        public bool SpriteYogaCompanionKit(String itemname, String size, String color)
        {
            Step = Test.CreateNode("YogaCompanionKit");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement yogaKitCollectionLink = WaitForElement(driver, yogaKitLocator);
                    Click(yogaKitCollectionLink, "Open Yoga Kit Collections");
                    SpriteYogaCompanionKitPage spriteYogaCompanionKitPage = new SpriteYogaCompanionKitPage();
                    return spriteYogaCompanionKitPage.AddYogaItemToCart(itemname, size, color);
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
        public bool FitnessItem(String itemname, String size, String color)
        {
            Step = Test.CreateNode("FitnessItem");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement fitnessCollectionLink = WaitForElement(driver, fitnessLocator);
                    Click(fitnessCollectionLink, "Open Fitness Kit Collections");
                    FitnessEquipmentsPage fitnessEquipmentsPage = new FitnessEquipmentsPage();
                    return fitnessEquipmentsPage.AddFitnessItemToCart(itemname, size, color);
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
        public bool PromoItem(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Promo Item");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement promoCollectionLink = WaitForElement(driver, promoLocator);
                    Click(promoCollectionLink, "Open Promo Collections");
                    FitnessEquipmentsPage fitnessEquipmentsPage = new FitnessEquipmentsPage();
                    return fitnessEquipmentsPage.AddFitnessItemToCart(itemname, size, color);
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
        public bool BagItem(String itemname, String size, String color)
        {
            Step = Test.CreateNode("BagPage");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement bagCollectionLink = WaitForElement(driver, bagLocator);
                    Click(bagCollectionLink, "Open Bag Collections");
                    BagsPage bagsPage = new BagsPage();
                    return bagsPage.AddBagItemToCart(itemname, size, color);
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
        public bool GymItem(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Gym Item");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement gymCollectionLink = WaitForElement(driver, gymItemLocator);
                    Click(gymCollectionLink, "Open Bag Collections");
                    FitnessEquipmentsPage fitnessEquipmentsPage = new FitnessEquipmentsPage();
                    return fitnessEquipmentsPage.AddFitnessItemToCart(itemname, size, color);
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
        public bool WatchItem(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Watch Item");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement watchCollectionLink = WaitForElement(driver, watchLocator);
                    Click(watchCollectionLink, "Open Bag Collections");
                    WatchesPage watchesPage = new WatchesPage();
                    return watchesPage.AddWatchItemToCart(itemname, size, color);
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
            Step = Test.CreateNode("HotSellerGear");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                try
                {
                    DeleteAd();
                    return ItemAnalyzer.AddToCartByHover(itemname, size, color, ".product-item", false);
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
