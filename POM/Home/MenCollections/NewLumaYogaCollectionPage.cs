using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class LumaPerformanceFabricCollectionPage : Navigator
    {
        String pageTitle = "New Luma Yoga Collection";
        String itemsSelector = ".product-item";
        public void AddFabricItemToCart(String itemname, String size, String color)
        {
            try
            {
                VerifyPageOpen(pageTitle);
                ItemAnalyzer.AddToCartByHover(itemname, size, color, itemsSelector, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The page doesnt exist");
            }
            
        } 
    

    }
}
