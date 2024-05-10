using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Threading;

namespace Luma_Selenium
{
    public class BaseClass
    {
        #region baseVariables
        public static String driverURL = "https://magento.softwaretestingboard.com/";
        public static IWebDriver driver;
        public TestContext testContext;
        public static ExtentReports extentReports;
        public static ExtentTest Test;
        public static ExtentTest Step;
        public static ExtentTest SubStep;
        public static TimeSpan timeout = TimeSpan.FromSeconds(50);
        private static By adLocator = By.ClassName("ea-stickybox-hide");
        #endregion

        #region baseMethods
        public static string ExecutionBrowser { get; set; }
        public static void CreateReport(String filename)
        {
            extentReports = new ExtentReports();
            String dirpath = @filename;
            var sparkReporter = new ExtentSparkReporter(dirpath);
            extentReports.AttachReporter(sparkReporter);
        }
        public static void TakeScreenshot(Status status, string stepDetail)
        {
            string path = @"C:\ExtentReports\images" + DateTime.Now.ToString("yyyyMMHHmmss") + ".png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(path, screenshot.AsByteArray);
            Step.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path).Build());
        }
        public static void SeleniumInit(String browser)
        {

            if (browser == "Chrome")
            {
                driver = new ChromeDriver();
            }
            else
            {
                return;
            }
            driver.Manage().Window.Maximize();
            driver.Url = driverURL;
            DeleteAd();
        }
        public static void SeleniumExit()
        {
            driver.Close();
        }
        public static void DeleteAd()
        {
            try
            {
                IWebElement ad = WaitForElement(driver, adLocator);
                ad.Click();
            }catch (Exception ex)
            {
                Console.WriteLine("No Ad");
            }
        }
        #endregion
        public static float ConvertStringToFloat(String price)
        {
            String initialPrice = price.Replace("$", "");
            initialPrice = initialPrice.Replace(",", "");
            float initialPriceAsInteger = float.Parse(initialPrice);
            return initialPriceAsInteger;
        }
        public static IWebElement WaitForElement(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            try
            {
                return wait.Until(d =>
                {
                    IWebElement element = d.FindElement(locator);
                    if (element != null && element.Enabled)
                    {
                        return element;
                    }
                    return null;
                });
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element Was Not Found Even After the Wait");
                TakeScreenshot(Status.Fail, "Element Not Found");
                return null;
            }
        }
        public static IWebElement WaitForParentElement(IWebElement parentElement, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);

            try
            {
                return wait.Until(d =>
                {
                    IWebElement element = parentElement.FindElement(locator);
                    if (element != null && element.Enabled)
                    {
                        return element;
                    }
                    return null;
                });
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element Was Not Found Even After the Wait (Within Parent Element)");
                TakeScreenshot(Status.Fail, "Element Not Found Within Parent");
                return null;
            }
        }
        public static IList<IWebElement> WaitForElements(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            try
            {
                return wait.Until(d =>
                {
                    IList<IWebElement> element = driver.FindElements(locator);
                    if (element.Count > 0)
                    {
                        return element;
                    }
                    return null;
                });
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Elements were Not Found Even After the Wait");
                TakeScreenshot(Status.Fail, "Elements Not Found");
                
            }
            return null;
            
        }
        public static IList<IWebElement> WaitForParentElements(IWebElement parentElement, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            try
            {
                return wait.Until(d =>
                {
                    IList<IWebElement> element = parentElement.FindElements(locator);
                    if (element.Count > 0)
                    {
                        return element;
                    }
                    return null;
                });
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Elements were Not Found Even After the Wait");
                TakeScreenshot(Status.Fail, "Elements Not Found");

            }
            return null;

        }
        public static void Write(IWebElement element, String text, String stepDetail="N/A")
        {
            element.SendKeys(text);
            TakeScreenshot(Status.Pass, stepDetail);
        }
        public static void Clear(IWebElement element)
        {
            element.Clear();
        }
        public static void Click(IWebElement element, String stepDetail = "N/A")
        {
            element.Click();
            TakeScreenshot(Status.Pass, stepDetail);
        }
        public static void RaiseException (Exception e)
        {
            String exceptionString = e.ToString();
            int firstLineEndIndex = exceptionString.IndexOf("\n");
            string firstLine = exceptionString.Substring(0, firstLineEndIndex);
            Console.WriteLine(firstLine);
            TakeScreenshot(Status.Fail,firstLine);
        }
        public static void HandleStatus(bool status, string successMessage,  string failureMessage)
        {
            if (status)
            {
                TakeScreenshot(Status.Pass, successMessage);
            }
            else
            {
                TakeScreenshot(Status.Fail, failureMessage);
            }
        }
    }
}
