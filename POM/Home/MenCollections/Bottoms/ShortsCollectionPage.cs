using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class MenShortsCollectionPage : Navigator
    {
        String pageTitle = "Shorts";
        String itemsSelector = ".item.product.product-item";
        public void AddShortsToCart(String itemname, String size, String color)
        {
           
                VerifyPageOpen(pageTitle);
                ItemAnalyzer.AddToCartByHover(itemname, size, color, itemsSelector, true);
        } 
    

    }
}
