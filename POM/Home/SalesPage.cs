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
        private By navLocator = By.Id("ui-id-8");
        private String pageTitle = "Sale";
        private By womenSalesLocator = By.CssSelector(".block-promo.sale-main");
        private By menSalesLocator = By.CssSelector(".block-promo.sale-mens");
        private By gearStealsLocator = By.CssSelector(".block-promo.sale-women");
        private By womenTeeLocator = By.CssSelector(".block-promo.sale-womens-t-shirts");

        #endregion

        #region SalesMethods
        public bool WomenSales(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Women Sales Item");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement womenSalesCollectionLink = WaitForElement(driver, womenSalesLocator);
                    Click(womenSalesCollectionLink, "Open Women Sales Collections");
                    WomenSalesPage womenSalesPage = new WomenSalesPage();
                    return womenSalesPage.AddWomenSaleItemToCart(itemname, size, color);
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
        public bool MenSales(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Men Sales Item");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement menSalesCollectionLink = WaitForElement(driver, menSalesLocator);
                    Click(menSalesCollectionLink, "Open Men Sales Collections");
                    MenSalesPage MenSalesPage = new MenSalesPage();
                    return MenSalesPage.AddMenSaleItemToCart(itemname, size, color);
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
        public bool GearSteals(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Gear Steals Item");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement gearStealsCollectionLink = WaitForElement(driver, gearStealsLocator);
                    Click(gearStealsCollectionLink, "Open Gear Steals Collections");
                    GearPage gearPage = new GearPage();
                    return gearPage.PromoItem(itemname, size, color);
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
        public bool WomenTees(String itemname, String size, String color)
        {
            Step = Test.CreateNode("Gear Steals Item");
            bool pageLoadStatus = InitializePage(navLocator, pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement teeCollectionLink = WaitForElement(driver, womenTeeLocator);
                    Click(teeCollectionLink, "Open Women Tee Collections");
                    WomenTeesCollectionsPage womenTeesCollectionsPage = new WomenTeesCollectionsPage();
                    return womenTeesCollectionsPage.AddTeeItemToCart(itemname, size, color);
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
