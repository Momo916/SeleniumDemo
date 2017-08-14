using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System.Threading;
using UIAF;

namespace SeleniumTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testcase.ClickInputText();
            Testcase.ClickSearchBtn();
        }
    }

    class PhysicalModel
    {
        public static IWebDriver driver = new InternetExplorerDriver();
        
        public static Actions action;
        public static Actions Action
        {
            get
            {
                action = new Actions(driver);
                return action;
            }
        }

        private static IWebElement input;
        public static IWebElement Input
        {
            get
            {
                input = driver.FindElement(By.Id("kw"));
                return input;
            }
        }
        private static IWebElement mSearchBtn;
        public static IWebElement SearchBtn
        {
            get
            {
                mSearchBtn = driver.FindElement(By.CssSelector("input[type='submit']"));
                return mSearchBtn;
            }
        }
    }

    class Testcase
    {
        public static IWebDriver myDriver = PhysicalModel.driver;
        public static void ClickInputText()
        {
            try
            {
                myDriver.Navigate().GoToUrl("www.baidu.com");
                Thread.Sleep(2000);
                myDriver.Manage().Window.Maximize();
                Thread.Sleep(2000);
                PhysicalModel.Input.Click();
                PhysicalModel.Input.SendKeys("selenium");
                Thread.Sleep(2000);
                Global.Type("{Enter}");
                Thread.Sleep(20000);
                myDriver.Navigate().Back();

                ////IWebElement iframe = null;
                ////myDriver.SwitchTo().Frame(iframe);
                ////myDriver.SwitchTo().DefaultContent();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void ClickSearchBtn()
        {
            try
            {
                myDriver.Navigate().GoToUrl("www.baidu.com");
                Thread.Sleep(2000);
                myDriver.Manage().Window.Maximize();
                Thread.Sleep(2000);
                PhysicalModel.SearchBtn.Click();
                Thread.Sleep(2000);
                PhysicalModel.Action.ContextClick(PhysicalModel.Input).Perform();
                //PhysicalModel.Action.DoubleClick(PhysicalModel.Input).Perform();
                //PhysicalModel.Action.MoveToElement(PhysicalModel.Input).Perform();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void lianxi()
        {
            myDriver.Manage().Window.Maximize();
        }
    }
}
