using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class TrainingVideoPage : Navigator
    {
        private String pageTitle = "Video Download";
        private By videoLocator = By.CssSelector(".message.info.empty");
        public bool ViewTrainingVideo(String itemname, String size, String color)
        {
            bool pageLoadStatus = VerifyPageOpen(pageTitle);
            if (pageLoadStatus)
            {
                DeleteAd();
                try
                {
                    IWebElement emptyPage = WaitForElement(driver, videoLocator);
                    String emptyPageMessage = emptyPage.Text;
                    Assert.AreEqual(emptyPageMessage, "We can't find products matching the selection.", "The page has some videos");
                    return false;
                }
                catch (Exception ex)
                {
                    RaiseException(ex);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
