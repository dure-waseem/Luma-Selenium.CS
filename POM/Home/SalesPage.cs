using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class SalesPage : Navigator
    {
        #region SalesLocators
        By navLocator = By.Id("ui-id-8");
        String pageTitle = "Sale";

        #endregion

        #region SalesMethods
        public void WomenSales(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.sale-main")).Click();
            WomenSalesPage womenSalesPage = new WomenSalesPage();
            womenSalesPage.AddWomenSaleItemToCart(itemname, size, color);
        }
        public void MenSales(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.sale-mens")).Click();
            MenSalesPage MenSalesPage = new MenSalesPage();
            MenSalesPage.AddMenSaleItemToCart(itemname, size, color);
        }
        public void GearSteals(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.sale-women")).Click();
            GearPage gearPage = new GearPage();
            gearPage.PromoItem(itemname, size, color);
        }
        public void WomenTees(String itemname, String size, String color)
        {
            InitializePage(navLocator, pageTitle);
            driver.FindElement(By.CssSelector(".block-promo.sale-womens-t-shirts")).Click();
            WomenTeesCollectionsPage womenTeesCollectionsPage = new WomenTeesCollectionsPage();
            womenTeesCollectionsPage.AddTeeItemToCart(itemname, size, color);
        }
        
        #endregion



    }
}
