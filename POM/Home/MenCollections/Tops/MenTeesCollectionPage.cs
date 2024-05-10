using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class MenTeesCollectionsPage : Navigator
    {
        String pageTitle = "Tees";
        String itemsSelector = ".item.product.product-item";
        public void AddTeeItemToCart(String itemname, String size, String color)
        {
                VerifyPageOpen(pageTitle);
                ItemAnalyzer.AddToCartByHover(itemname, size, color, itemsSelector, true);
        } 
    

    }
}
