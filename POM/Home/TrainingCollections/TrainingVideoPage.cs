using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;

namespace Luma_Selenium
{
    public class TrainingVideoPage : Navigator
    {
        String pageTitle = "Video Download";
        public void ViewTrainingVideo(String itemname, String size, String color)
        {
            VerifyPageOpen(pageTitle);
            IWebElement emptyPage = driver.FindElement(By.CssSelector(".message.info.empty"));
            String emptyPageMessage = emptyPage.Text;
            Assert.AreEqual(emptyPageMessage, "We can't find products matching the selection.", "The page has some videos");
      


        }


    }
}
