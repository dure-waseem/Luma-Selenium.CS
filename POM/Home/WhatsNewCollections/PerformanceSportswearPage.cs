using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class PerformanceSportswearPage : Navigator
    {
        #region performanceLocators
        String pageTitle = "Performance Sportswear New";
        String itemsSelector = ".product-item";
        #endregion
        #region performaceMethods
        public bool AddSportswearItemToCart(String itemname, String size, String color)
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
