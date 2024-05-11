using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class ErinRecommendationPage : Navigator
    {
        #region erinRecommendedLocators
        String pageTitle = "Erin Recommends";
        String itemsSelector = ".product-item";
        #endregion
        #region erinRecommendedMethods
        public bool AddErinItemToCart(String itemname, String size, String color)
        {

            bool pageLoadStatus = VerifyPageOpen(pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    return ItemAnalyzer.AddToCartByHover(itemname, size, color, itemsSelector, true);
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
