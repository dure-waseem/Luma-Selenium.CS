using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class EcoCollectionsPage : Navigator
    {
        #region ecoLocators
        String pageTitle = "Eco Collection New";
        String itemsSelector = ".product-item";
        #endregion
        #region ecoMethods
        public bool AddEcoCollectionItemToCart(String itemname, String size, String color)
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
