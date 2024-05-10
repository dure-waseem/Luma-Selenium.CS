using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class WomenSalesPage : Navigator
    {
        String pageTitle = "Women Sale";
        String itemsSelector = ".product-item";
        public void AddWomenSaleItemToCart(String itemname, String size, String color)
        {
            VerifyPageOpen(pageTitle);
            ItemAnalyzer.AddToCartByHover(itemname, size, color, itemsSelector, true);
        } 

    }
}
