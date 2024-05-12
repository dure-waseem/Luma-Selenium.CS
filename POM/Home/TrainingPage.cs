using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class TrainingPage : Navigator
    {
        #region TrainingLocators
        private By navLocator = By.Id("ui-id-7");
        private String pageTitle = "Training";
        private By erinRecommendedLocator = By.CssSelector(".block-promo.training-erin");
        private By trainingVideoLocator = By.CssSelector(".block-promo.training-on-demand");
        #endregion

        #region TrainingMethods
        public bool ErinRecommendCollection(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Erin Recommended Collection");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement erinCollectionLink = WaitForElement(driver, erinRecommendedLocator);
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

        public bool TrainingOnDemand(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Training Video");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement videoCollectionLink = WaitForElement(driver, trainingVideoLocator);
                    Click(videoCollectionLink, "Open Video Collections");
                    TrainingVideoPage trainingVideoPage = new TrainingVideoPage();
                    return trainingVideoPage.ViewTrainingVideo(itemname, size, color);
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
