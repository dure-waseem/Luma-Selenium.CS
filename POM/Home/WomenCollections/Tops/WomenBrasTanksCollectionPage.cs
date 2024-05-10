using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class WomenBrasTanksCollection : Navigator
    {
        String pageTitle = "Bras & Tanks";
        String itemsSelector = ".item.product.product-item";
        public void AddBarsTanksItemToCart(String itemname, String size, String color)
        {
                VerifyPageOpen(pageTitle);
                ItemAnalyzer.AddToCartByHover(itemname, size, color, itemsSelector, true);
        } 
    

    }
}
