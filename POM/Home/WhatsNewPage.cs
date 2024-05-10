using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class WhatsNewPage : Navigator
    {
        #region WhatsNewPageLocators
        private By navLocator = By.Id("ui-id-3");
        private String pageTitle = "What's New";
        private By yogaCollectionLocator = By.CssSelector(".block-promo.new-main");
        private By sportswearCollectionLocator = By.CssSelector(".block-promo.new-performance");
        private By ecoCollectionLocator = By.CssSelector(".block-promo.new-eco");
        #endregion

        #region WhatsNewPageMethods
        public bool NewYogaCollections(String itemname, String size, String color)
        {
            Step = Test.CreateNode("YogaCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement yogaCollectionLink = WaitForElement(driver, yogaCollectionLocator);
                    Click(yogaCollectionLink, "Open Yoga Collections");
                    NewYogaCollectionsPage newYogaCollectionPage = new NewYogaCollectionsPage();
                    return newYogaCollectionPage.AddYogaItemToCart(itemname, size, color);
                } catch(Exception ex)
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
        public bool PerformanceSportswear(String itemname, String size, String color)
        {
            Step = Test.CreateNode("PerformanceSportsCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement sportswearCollectionLink = WaitForElement(driver, sportswearCollectionLocator);
                    Click(sportswearCollectionLink, "Open Sportswear Collections");
                    PerformanceSportswearPage performanceSportswearPage = new PerformanceSportswearPage();
                    return performanceSportswearPage.AddSportswearItemToCart(itemname, size, color);
                }
                catch(Exception ex)
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

        public bool EcoCollectionNew(String itemname, String size, String color)
        {
            Step = Test.CreateNode("EcoCollection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                try
                {
                    DeleteAd();
                    IWebElement ecoCollectionLink = WaitForElement(driver, ecoCollectionLocator);
                    Click(ecoCollectionLink, "Open Eco Collections");
                    EcoCollectionsPage ecoCollectionNew = new EcoCollectionsPage();
                    return ecoCollectionNew.AddEcoCollectionItemToCart(itemname, size, color);
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

        public bool LumaLatest(String itemname, String size, String color)
        {
            Step = Test.CreateNode("LumaLatestCollection");
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
