using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class NewLumaYogaCollectionPage : Navigator
    {
        String pageTitle = "New Luma Yoga Collection";
        String itemsSelector = ".product-item";
        public bool AddYogaItemToCart(String itemname, String size, String color)
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
    

    }
}
