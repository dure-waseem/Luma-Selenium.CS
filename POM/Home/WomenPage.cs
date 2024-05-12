using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class WomenPage : Navigator
    {
        #region WomenLocators
        private By navLocator = By.Id("ui-id-4");
        private String pageTitle = "Women";
        private By lumaYogaLocator = By.CssSelector(".block-promo.womens-main");
        private By womenTeeLocator = By.CssSelector(".block-promo.womens-t-shirts");
        private By womenPantsLocator = By.CssSelector(".block-promo.womens-pants");
        private By womenErinLocator = By.CssSelector(".block-promo.womens-erin");
        private By womenLumaPantsLocator = By.CssSelector(".block-promo.womens-category-pants");
        private By womenShortsLocator = By.CssSelector(".block-promo.womens-category-shorts");
        private By womenTanksLocator = By.CssSelector(".block-promo.womens-category-tanks");
        #endregion

        #region WomenMethods
        public bool NewLumaYogaCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("NewLumaYogaCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement yogaCollectionLink = WaitForElement(driver, lumaYogaLocator);
                    Click(yogaCollectionLink, "Open Yoga Collections");
                    NewLumaYogaCollectionPage newLumaYogaCollectionPage = new NewLumaYogaCollectionPage();
                    return newLumaYogaCollectionPage.AddYogaItemToCart(itemname, size, color);
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
        public bool WomenTeeCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("WomenTeeCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement teeCollectionLink = WaitForElement(driver, womenTeeLocator);
                    Click(teeCollectionLink, "Open Tee Collections");
                    WomenTeesCollectionsPage WomenteesCollectionsPage = new WomenTeesCollectionsPage();
                    return WomenteesCollectionsPage.AddTeeItemToCart(itemname, size, color);
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

        public bool WomenPantCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("WomenPantCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement pantsCollectionLink = WaitForElement(driver, womenPantsLocator);
                    Click(pantsCollectionLink, "Open Pants Collections");
                    WomenPantsCollectionPage PantsCollectionsPage = new WomenPantsCollectionPage();
                    return PantsCollectionsPage.AddPantsToCart(itemname, size, color);
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

        public bool ErinRecommendCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Women Erin Recommendation");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement erinCollectionLink = WaitForElement(driver, womenErinLocator);
                    Click(erinCollectionLink, "Open Erin Recommended Collections");
                    ErinRecommendationPage erinRecommendationPage = new ErinRecommendationPage();
                    return erinRecommendationPage.AddErinItemToCart(itemname, size, color);
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


        public bool WomenLumaPantsCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Women Pants");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement pantsCollectionLink = WaitForElement(driver, womenLumaPantsLocator);
                    Click(pantsCollectionLink, "Open Women Pants Collections");
                    WomenPantsCollectionPage PantsCollectionsPage = new WomenPantsCollectionPage();
                    return PantsCollectionsPage.AddPantsToCart(itemname, size, color);
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
        public bool WomenShortsCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Women Shorts");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement shortsCollectionLink = WaitForElement(driver, womenShortsLocator);
                    Click(shortsCollectionLink, "Open Women Shorts Collections");
                    WomenShortsCollectionPage shortsCollectionsPage = new WomenShortsCollectionPage();
                    return shortsCollectionsPage.AddWomenShortsToCart(itemname, size, color);
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

        public bool WomenBrasTanksCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Women Bra/Tank");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement womenCollectionLink = WaitForElement(driver, womenTanksLocator);
                    Click(womenCollectionLink, "Open Women Shorts Collections");
                    WomenBrasTanksCollection womenBrasandTanksCollectionPage = new WomenBrasTanksCollection();
                    return womenBrasandTanksCollectionPage.AddBarsTanksItemToCart(itemname, size, color);
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

        public void HotSellers(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            ItemAnalyzer.AddToCartByHover(itemname, size, color, ".product-item", true);
        }
        #endregion



    }
}
