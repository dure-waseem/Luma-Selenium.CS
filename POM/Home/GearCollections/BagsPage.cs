using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class BagsPage : Navigator
    {
        String pageTitle = "Bags";
        String itemsSelector = ".product-item";
        public void AddBagItemToCart(String itemname, String size, String color)
        {
            VerifyPageOpen(pageTitle);
            ItemAnalyzer.AddToCartByHover(itemname, size, color, itemsSelector, false);
        } 
    }
}
