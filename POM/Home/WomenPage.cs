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
        public void WomenTeeCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.womens-t-shirts")).Click();
            WomenTeesCollectionsPage WomenteesCollectionsPage = new WomenTeesCollectionsPage();
            WomenteesCollectionsPage.AddTeeItemToCart(itemname, size, color);
        }

        public void WomenPantCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.womens-pants")).Click();
            WomenPantsCollectionPage PantsCollectionsPage = new WomenPantsCollectionPage();
            PantsCollectionsPage.AddPantsToCart(itemname, size, color);
        }

        public void ErinRecommendCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.womens-erin")).Click();
            ErinRecommendationPage erinRecommendationPage = new ErinRecommendationPage();
            erinRecommendationPage.AddErinItemToCart(itemname, size, color);
        }


        public void WomenLumaPantsCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.womens-category-pants")).Click();
            WomenPantsCollectionPage PantsCollectionsPage = new WomenPantsCollectionPage();
            PantsCollectionsPage.AddPantsToCart(itemname, size, color);
        }
        public void WomenShortsCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.womens-category-shorts")).Click();
            WomenShortsCollectionPage shortsCollectionsPage = new WomenShortsCollectionPage();
            shortsCollectionsPage.AddWomenShortsToCart(itemname, size, color);
        }

        public void WomenBrasTanksCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.womens-category-tanks")).Click();
            WomenBrasTanksCollection womenBrasandTanksCollectionPage = new WomenBrasTanksCollection();
            womenBrasandTanksCollectionPage.AddBarsTanksItemToCart(itemname, size, color);
        }

        public void HotSellers(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            ItemAnalyzer.AddToCartByHover(itemname, size, color, ".product-item", true);
        }
        #endregion



    }
}
