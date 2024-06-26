﻿using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Drawing;
using System.Threading;

namespace Luma_Selenium
{
    [TestClass]
    public class TestExecution : BaseClass
    {
        #region PageObjects
        static LoginPage loginPage;
        static RegisterPage registerPage;
        static ForgetPasswordPage forgetPage;
        static WhatsNewPage whatsNewPage;
        static WomenPage womenPage;
        static MenPage menPage;
        static GearPage gearPage;
        static TrainingPage trainingPage;
        static SalesPage salesPage;
        static MyAccountPage myAccountPage;
        #endregion

        #region Setups and Cleanups
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }
        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            loginPage = new LoginPage();
            registerPage = new RegisterPage();
            whatsNewPage = new WhatsNewPage();
            forgetPage = new ForgetPasswordPage();
            womenPage = new WomenPage();
            menPage = new MenPage();
            gearPage = new GearPage();
            trainingPage = new TrainingPage();
            salesPage = new SalesPage();
            myAccountPage = new MyAccountPage();
            string ResultFile = @"E:\Luma-Selenium\ExtentReports\TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
            CreateReport(ResultFile);
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            extentReports.Flush();
        }

        [TestInitialize()]
        public void TestInit()
        {
            BaseClass.SeleniumInit(ConfigurationManager.AppSettings["DeviceBrowser"].ToString());
            Test = extentReports.CreateTest(TestContext.TestName);
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            BaseClass.SeleniumExit();

        }
        #endregion

        #region TextExecutionCases
        [TestMethod]
        [TestCategory("Credential Managemnent")]
        [Description("Try to Register with new and existing accounts")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "RegistrationFunctionalitySuccess_TC01", DataAccessMethod.Sequential)]
        public void RegistrationFunctionalitySuccess_TC01()
        {
            String firstname = TestContext.DataRow["firstname"].ToString();
            String lastname = TestContext.DataRow["lastname"].ToString();
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            bool registrationStatus = registerPage.Register(firstname, lastname, email, password);
            HandleStatus(registrationStatus, successDescription, failureDescription);
        }

        [TestMethod]
        [TestCategory("Credential Managemnent")]
        [Description("Try to login using valid and invalid account")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginFunctionalitySuccess_TC02", DataAccessMethod.Sequential)]
        public void LoginFunctionalitySuccess_TC02()
        {
            String fullname = TestContext.DataRow["fullname"].ToString();
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, successDescription, failureDescription);
        }

        [TestMethod]
        [TestCategory("Credential Managemnent")]
        [Description("Try to emulate the forget password functionality")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "ForgetPasswordFunctionality_TC03", DataAccessMethod.Sequential)]
        public void ForgetPasswordFunctionality_TC03()
        {
            String email = TestContext.DataRow["email"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            bool forgetStatus = forgetPage.ForgetPassword(email);
            HandleStatus(forgetStatus, successDescription, failureDescription);
        }

        [TestMethod]
        [TestCategory("Whats New Collection")]
        [Description("Add yoga item to cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddYogaItemAndCheckout_TC04", DataAccessMethod.Sequential)]
        public void AddYogaItemAndCheckout_TC04()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = whatsNewPage.NewYogaCollections(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Whats New Collection")]
        [Description("Add sports wear to cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddPerformaceSportswearItemAndCheckout_TC05", DataAccessMethod.Sequential)]
        public void AddPerformaceSportswearItemAndCheckout_TC05()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = whatsNewPage.PerformanceSportswear(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
            
        }

        [TestMethod]
        [TestCategory("Whats New Collection")]
        [Description("Add eco collection to cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddEcoCollectionItemAndCheckout_TC06", DataAccessMethod.Sequential)]
        public void AddEcoCollectionItemAndCheckout_TC06()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
               
                bool addStatus = whatsNewPage.EcoCollectionNew(itemname, size, color); ;
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Whats New Collection")]
        [Description("Add luma collection to cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddLumaLatestItemAndCheckout_TC07", DataAccessMethod.Sequential)]
        public void AddLumaLatestItemAndCheckout_TC07()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = whatsNewPage.LumaLatest(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }

            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Women Collection")]
        [Description("Add luma Yoga collection to cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddNewLumaYogaItemAndCheckout_TC08", DataAccessMethod.Sequential)]
        public void AddNewLumaYogaItemAndCheckout_TC08()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.NewLumaYogaCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }


        [TestMethod]
        [TestCategory("Women Collection")]
        [Description("Add women tees to the cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddWomenTeeItemAndCheckout_TC09", DataAccessMethod.Sequential)]
        public void AddWomenTeeItemAndCheckout_TC09()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.WomenTeeCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Women Collection")]
        [Description("Add women pant to the cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddWomenPantItemAndCheckout_TC10", DataAccessMethod.Sequential)]
        public void AddWomenPantItemAndCheckout_TC10()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.WomenPantCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }


        [TestMethod]
        [TestCategory("Men Collection")]
        [Description("Add luma performance item to the cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddMenLumaPerformanceCollectionItemAndCheckout_TC11", DataAccessMethod.Sequential)]
        public void AddMenLumaPerformanceCollectionItemAndCheckout_TC11()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = menPage.LumaPerformanceCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Men Collection")]
        [Description("Add men tees to the cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddMenTeeCollectionItemAndCheckout_TC12", DataAccessMethod.Sequential)]
        public void AddMenTeeCollectionItemAndCheckout_TC12()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = menPage.TeeCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Men Collection")]
        [Description("Add men pant to the cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddMenPantCollectionItemAndCheckout_TC13", DataAccessMethod.Sequential)]
        public void AddMenPantCollectionItemAndCheckout_TC13()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = menPage.PantCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }


        [TestMethod]
        [TestCategory("Men Collection")]
        [Description("Add men shorts to the cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddMenShortCollectionItemAndCheckout_TC14", DataAccessMethod.Sequential)]
        public void AddMenShortCollectionItemAndCheckout_TC14()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = menPage.ShortCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Men Collection")]
        [Description("Add men tees to the cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddMenTeeCollectionItemAndCheckout_TC15", DataAccessMethod.Sequential)]
        public void AddMenTeeCollectionItemAndCheckout_TC15()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = menPage.LumaTees(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Women Collections Page")]
        [Description("Add a erin recommended item from women page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddWomenErinRecommendedItemAndCheckout_TC16", DataAccessMethod.Sequential)]
        public void AddWomenErinRecommendedItemAndCheckout_TC16()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.ErinRecommendCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Women Collections Page")]
        [Description("Add a pant item from women page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddWomenPantCollectionItemAndCheckout_TC17", DataAccessMethod.Sequential)]
        public void AddWomenPantCollectionItemAndCheckout_TC17()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.WomenLumaPantsCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }

        }

        [TestMethod]
        [TestCategory("Men Collections Page")]
        [Description("Add a hoodie item from men page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddMenHoodieItemAndCheckout_TC18", DataAccessMethod.Sequential)]
        public void AddMenHoodieItemAndCheckout_TC18()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = menPage.HoodiesAndSweatshirts(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Men Collections Page")]
        [Description("Add a hot seller item from men page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddMenHotSellersItemAndCheckout_TC19", DataAccessMethod.Sequential)]
        public void AddMenHotSellersItemAndCheckout_TC19()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = menPage.HotSellers(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Gear Collections Page")]
        [Description("Add a yoga item from gear page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddGearYogaKitItemAndCheckout_TC20", DataAccessMethod.Sequential)]
        public void AddGearYogaKitItemAndCheckout_TC20()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = gearPage.SpriteYogaCompanionKit(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Gear Collections Page")]
        [Description("Add a fitness item from gear page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddGearFitnessItemAndCheckout_TC21", DataAccessMethod.Sequential)]
        public void AddGearFitnessItemAndCheckout_TC21()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = gearPage.FitnessItem(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Gear Collections Page")]
        [Description("Add a promo item from gear page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddGearPromoItemAndCheckout_TC22", DataAccessMethod.Sequential)]
        public void AddGearPromoItemAndCheckout_TC22()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = gearPage.PromoItem(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Gear Collections Page")]
        [Description("Add a bag item from gear page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddGearBagItemAndCheckout_TC23", DataAccessMethod.Sequential)]
        public void AddGearBagItemAndCheckout_TC23()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = gearPage.BagItem(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }

        }

        [TestMethod]
        [TestCategory("Gear Collections Page")]
        [Description("Add a gym item from gear page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddGearGymItemAndCheckout_TC24", DataAccessMethod.Sequential)]
        public void AddGearGymItemAndCheckout_TC24()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = gearPage.GymItem(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }

        }

        [TestMethod]
        [TestCategory("Gear Collections Page")]
        [Description("Add a watch item from gear page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddGearWatchItemAndCheckout_TC25", DataAccessMethod.Sequential)]
        public void AddGearWatchItemAndCheckout_TC25()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = gearPage.WatchItem(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }

        }

        [TestMethod]
        [TestCategory("Gear Collections Page")]
        [Description("Add a hot seller item from gear page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddGearHotSellerItemAndCheckout_TC26", DataAccessMethod.Sequential)]
        public void AddGearHotSellerItemAndCheckout_TC26()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = gearPage.HotSellers(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Training Page")]
        [Description("Add a erin recommended item from training page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddTrainingErinRecommendedItemAndCheckout_TC27", DataAccessMethod.Sequential)]
        public void AddTrainingErinRecommendedItemAndCheckout_TC27()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = trainingPage.ErinRecommendCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }

        }

        [TestMethod]
        [TestCategory("Training Page")]
        [Description("Add an video from training page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddTrainingVideoAndCheckout_TC28", DataAccessMethod.Sequential)]
        public void AddTrainingVideoAndCheckout_TC28()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = trainingPage.TrainingOnDemand(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("There are no videos");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
           

        }

        [TestMethod]
        [TestCategory("Women Collections Page")]
        [Description("Add an item from shorts women page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddWomenShortsItemAndCheckout_TC29", DataAccessMethod.Sequential)]
        public void AddWomenShortsItemAndCheckout_TC29()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.WomenShortsCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }

        }

        [TestMethod]
        [TestCategory("Women Collections Page")]
        [Description("Add an item from bras and tanks women page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddWomenBrasTanksItemAndCheckout_TC30", DataAccessMethod.Sequential)]
        public void AddWomenBrasTanksItemAndCheckout_TC30()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.WomenBrasTanksCollection(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }

        }

        [TestMethod]
        [TestCategory("Sales Collections Page")]
        [Description("Add an item from women sales page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddSalesWomenItemAndCheckout_TC31", DataAccessMethod.Sequential)]
        public void AddSalesWomenItemAndCheckout_TC31()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = salesPage.WomenSales(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }

        }

        [TestMethod]
        [TestCategory("Sales Collections Page")]
        [Description("Add an item from men sales page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddSalesMenItemAndCheckout_TC32", DataAccessMethod.Sequential)]
        public void AddSalesMenItemAndCheckout_TC32()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = salesPage.MenSales(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Sales Collections Page")]
        [Description("Add an item from sales steals page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddSalesStealsItemAndCheckout_TC33", DataAccessMethod.Sequential)]
        public void AddSalesStealsItemAndCheckout_TC33()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = salesPage.GearSteals(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }

        }

        [TestMethod]
        [TestCategory("Sales Collections Page")]
        [Description("Add an item from women tees sales page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddSalesWomenTeesAndCheckout_TC34", DataAccessMethod.Sequential)]
        public void AddSalesWomenTeesAndCheckout_TC34()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = salesPage.WomenTees(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Women Collections Page")]
        [Description("Add an item from hot sellers women page to cart and proceed to checkout")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AddWomenHotSellersAndCheckout_TC35", DataAccessMethod.Sequential)]
        public void AddWomenHotSellersAndCheckout_TC35()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.HotSellers(itemname, size, color);
                HandleStatus(addStatus, successDescription, failureDescription);
                if (addStatus)
                {
                    bool itemBoughtStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemBoughtStatus, "Item Bought", "Failed to Buy Item");
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Checkout")]
        [Description("Update Item Quantity In Cart Hover")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "UpdateItemQuantityInCartAndHandleCosts_TC36", DataAccessMethod.Sequential)]
        public void UpdateItemQuantityInCartAndHandleCosts_TC36()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String quantity = TestContext.DataRow["quantity"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.WomenBrasTanksCollection(itemname, size, color);
                HandleStatus(addStatus, "Item Bought", "Failed to Buy Item");
                if (addStatus)
                {
                    bool itemUpdateStatus = ItemAnalyzer.UpdateQuantityInCartMenu(itemname, quantity);
                    HandleStatus(itemUpdateStatus, successDescription,  failureDescription);
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Checkout")]
        [Description("Delete Item Quantity In Cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "DeleteItemFromCartAndHandleCosts_TC37", DataAccessMethod.Sequential)]
        public void DeleteItemFromCartAndHandleCosts_TC37()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = womenPage.WomenBrasTanksCollection(itemname, size, color);
                HandleStatus(addStatus, "Item Bought", "Failed to Buy Item");
                if (addStatus)
                {
                    bool itemUpdateStatus = ItemAnalyzer.DeleteItemFromCartMenu(itemname);
                    HandleStatus(itemUpdateStatus, successDescription, failureDescription);
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Checkout")]
        [Description("Update Item Quantity In Cart")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "UpdateItemInCartMenu_TC38", DataAccessMethod.Sequential)]
        public void UpdateItemInCartMenu_TC38()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String quantity = TestContext.DataRow["quantity"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus;
                if (size != "" && color != "")
                {
                    addStatus = womenPage.WomenTeeCollection(itemname, size, color);
                }
                else
                {
                    addStatus = gearPage.BagItem(itemname, size, color);
                }
                HandleStatus(addStatus, "Item Bought", "Failed to Buy Item");
                if (addStatus)
                {
                    bool itemUpdateStatus = ItemAnalyzer.UpdateItemInCartByEditMenu(itemname, quantity, size, color, false);
                    HandleStatus(itemUpdateStatus, successDescription, failureDescription);
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("Checkout")]
        [Description("Open the cart and Go to checkout and complete payment")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "CheckoutCart_TC39", DataAccessMethod.Sequential)]
        public void CheckoutCart_TC39()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String itemname = TestContext.DataRow["itemname"].ToString();
            String size = TestContext.DataRow["size"].ToString();
            String color = TestContext.DataRow["color"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool addStatus = gearPage.BagItem(itemname, size, color);
                HandleStatus(addStatus, "Item Bought", "Failed to Buy Item");
                if (addStatus)
                {
                    bool itemUpdateStatus = ItemAnalyzer.CheckoutPageByCartMenu();
                    HandleStatus(itemUpdateStatus, successDescription, failureDescription);
                }
                else
                {
                    Console.WriteLine("Failed to Add Item to Cart");
                }
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("AccountInformation")]
        [Description("Update the first name in the Account Information")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "EditAccountInformation_TC40", DataAccessMethod.Sequential)]
        public void EditAccountInformation_TC40()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String newFirstName = TestContext.DataRow["newFirstName"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool editStatus = myAccountPage.EditButtonPage(newFirstName);
                HandleStatus(editStatus, successDescription, failureDescription);
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
        }

        [TestMethod]
        [TestCategory("AccountInformation")]
        [Description("Update the Street Address in the Account Information")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "EditAddressInformation_TC41", DataAccessMethod.Sequential)]
        public void EditAddressInformation_TC41()
        {
            String email = TestContext.DataRow["email"].ToString();
            String password = TestContext.DataRow["password"].ToString();
            String fullname = TestContext.DataRow["fullname"].ToString();
            String streetAddress = TestContext.DataRow["streetAddress"].ToString();
            String successDescription = TestContext.DataRow["successDescription"].ToString();
            String failureDescription = TestContext.DataRow["failureDescription"].ToString();
            bool loginStatus = loginPage.Login(email, password, fullname);
            HandleStatus(loginStatus, "Logged in Successfully", "Log in failed");
            if (loginStatus)
            {
                bool editStatus = myAccountPage.ManageAddressPage(streetAddress);
                HandleStatus(editStatus, successDescription, failureDescription);
            }
            else
            {
                Console.WriteLine("Login Failed!");
            }
            
        }
        #endregion
    }
}
