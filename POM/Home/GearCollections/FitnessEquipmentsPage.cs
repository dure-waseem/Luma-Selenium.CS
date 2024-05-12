using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class FitnessEquipmentsPage : Navigator
    {
        #region fitnessEquipLocators
        String pageTitle = "Fitness Equipment";
        String itemsSelector = ".product-item";
        #endregion
        #region fitnessEquipMethods
        public bool AddFitnessItemToCart(String itemname, String size, String color)
        {
            bool pageLoadStatus = VerifyPageOpen(pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    return ItemAnalyzer.AddToCartByHover(itemname, size, color, itemsSelector, false);
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
