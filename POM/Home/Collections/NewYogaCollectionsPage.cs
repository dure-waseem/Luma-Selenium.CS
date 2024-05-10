using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class NewYogaCollectionsPage : Navigator
    {
        #region YogaCollectionLocators
        String pageTitle = "New Luma Yoga Collection";
        String itemsSelector = ".item.product.product-item";
        #endregion

        #region YogaCollectionMethods
        public bool AddYogaItemToCart(String itemname, String size, String color)
        {

            bool pageStatus = VerifyPageOpen(pageTitle);
            if(pageStatus)
            {
                DeleteAd();
                try
                {
                    return ItemAnalyzer.AddToCartByHover(itemname, size, color, itemsSelector, true);
                }catch (Exception ex)
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
