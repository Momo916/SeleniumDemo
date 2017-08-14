using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ////Initialize a driver
            IWebDriver myDirver = new InternetExplorerDriver();
            //IWebDriver myDirver = new InternetExplorerDriver(@"C:\Users\v-junz\Desktop\SeleniumTraining-Demo\SeleniumTraining\SeleniumTraining\bin\Debug");

            ////Go to Url
            myDirver.Navigate().GoToUrl(@"https://df.onecloud.azure-test.net");
            Thread.Sleep(10000);

            ////Sign in
            Actions myActions = new Actions(myDirver);
            myActions.SendKeys("sqlltest@microsoft.com").Perform();
            myActions.SendKeys(Keys.Enter).Perform();
            Thread.Sleep(10000);

            ////Click Browse Icon
            WebDriverWait myWait = new WebDriverWait(myDirver, TimeSpan.FromSeconds(120));
            IWebElement browseIcon = myDirver.FindElement(By.CssSelector("button.fxs-sidebar-browse.fxs-has-hover"));
            myWait.Until(p => { return browseIcon.Displayed; });

            ////set border to element
            string JS_BORDER = "arguments[0].style.border='2.5px orange solid';";
            IJavaScriptExecutor myJsExecutor = (IJavaScriptExecutor)myDirver;
            myJsExecutor.ExecuteScript(JS_BORDER, browseIcon);

            browseIcon.Click();

        }
    }
}
