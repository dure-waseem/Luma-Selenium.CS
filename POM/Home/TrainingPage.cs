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
        By navLocator = By.Id("ui-id-7");
        String pageTitle = "Training";

        #endregion

        #region TrainingMethods
        public void ErinRecommendCollection(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.training-erin")).Click();
            ErinRecommendationPage erinRecommendationPage = new ErinRecommendationPage();
            erinRecommendationPage.AddErinItemToCart(itemname, size, color);
        }

        public void TrainingOnDemand(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.training-on-demand")).Click();
            TrainingVideoPage trainingVideoPage = new TrainingVideoPage();
            trainingVideoPage.ViewTrainingVideo(itemname, size, color);
        }
        #endregion



    }
}
