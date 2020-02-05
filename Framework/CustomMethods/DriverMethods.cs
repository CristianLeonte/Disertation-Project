using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace Framework.CustomMethods
{
    public static class DriverMethods
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DriverMethods));

        public static string GetBrowserVersion(this IWebDriver driver)
        {
            string strBrowserVersion = null;
            ICapabilities capabilities = ((RemoteWebDriver)driver).Capabilities;

            string browserName = capabilities.GetCapability("browserName").ToString();

            switch (browserName)
            {
                case "chrome":
                    strBrowserVersion = capabilities.GetCapability("version").ToString();
                    break;
                case "firefox":
                    strBrowserVersion = capabilities.GetCapability("browserVersion").ToString();
                    break;
            }

            return strBrowserVersion;
        }

        public static bool AlertIsPresent(this IWebDriver driver)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                Log.Info("Alert with text: " + alert.Text);

                return true;
            }
            catch (NoAlertPresentException e)
            {
                Log.Info("No alert present!" + e);
                return false;
            }
        }

        public static void AcceptAlert(this IWebDriver driver)
        {
            IAlert alert = driver.SwitchTo().Alert();

            Log.Info("Alert with text: " + alert.Text);

            alert.Accept();
        }

        public static IWebElement WaitForPresence(this IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));

            Log.Info("Wait for element: " + locator + " to be Present");

            IWebElement element;

            try
            {
                element = wait.Until(d => d.FindElement(locator));
            }
            catch (Exception e)
            {
                throw new Exception("Element not present!", e);
            }

            return element;
        }

        [Obsolete]
        public static void WaitForNotPresent(this IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));

            Log.Info("Wait for element: " + locator + " NOT to be Present");

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void HighlightElement(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string script = @"arguments[0].style.outline='2px dashed yellow';";
            js.ExecuteScript(script, element);
        }

        public static void WaitForElementDisplay(this IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));

            wait.Until((d) =>
            {
                return element.Displayed;
            });
        }

        [Obsolete]
        public static void WaitForElementVisibility(this IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));

            List<IWebElement> elements = new List<IWebElement>();
            elements.Add(element);
            ReadOnlyCollection<IWebElement> list = new ReadOnlyCollection<IWebElement>(elements);

            Log.Info("Wait for element: " + element.GetAttribute("outerHTML") + " to be Visible");

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(list));
        }

        [Obsolete]
        public static void WaitForElementsVisibility(this IWebDriver driver, IList<IWebElement> elements)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));

            Log.Info("Wait for list of elements to be Visible");
            ReadOnlyCollection<IWebElement> list = new ReadOnlyCollection<IWebElement>(elements);

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(list));
        }

        [Obsolete]
        public static void WaitForElementStale(this IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            Log.Info("Wait for element: " + element.GetAttribute("outerHTML") + " to be Stale");

            wait.Until(ExpectedConditions.StalenessOf(element));
        }

        public static IList<IWebElement> WaitForListOfElementsToNotBeEmpty(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(120);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IList<IWebElement> list = fluentWait.Until((d) => d.FindElements(locator));

            fluentWait.Until((d) =>
            {
                return d.FindElements(locator).Count >= 1;
            });

            return list;
        }

        public static void WaitForPageLoad(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int timeoutInSeconds = 5;
            string pageState;

            if (js.ExecuteScript("return document.readyState").ToString().Equals("complete"))
            {
                return;
            }

            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                    pageState = js.ExecuteScript("return document.readyState").ToString();

                    if (pageState.Equals("complete"))
                    {
                        return;
                    }
                    else
                    {
                        WaitForPageLoad(driver);
                    }
                }
                catch (Exception e)
                {
                    Log.Error("Page was not completed loaded" + e);
                }
            }
        }

        public static void CheckPendingRequests(this IWebDriver driver)
        {
            int timeoutInSeconds = 5;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            try
            {
                for (int i = 0; i < timeoutInSeconds; i++)
                {
                    var numberOfAjaxConnections = js.ExecuteScript("return window.openHTTPs");

                    if (numberOfAjaxConnections != null)
                    {
                        var n = Convert.ToDouble(numberOfAjaxConnections);
                        Log.Info("[HTTPS Requests] Number of active calls: " + n);
                        if (n == 0) break;
                    }
                    else
                    {
                        // If it's not a number, the page might have been freshly loaded indicating the monkey
                        // patch is replaced or we haven't yet done the patch.
                        // MonkeyPatchXmlHttpRequest(driver);
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (ThreadInterruptedException e)
            {
                Log.Error(e);
            }
        }

        public static void MonkeyPatchXmlHttpRequest(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            try
            {
                var numberOfAjaxConnections = js.ExecuteScript("return window.openHTTPs");

                if (numberOfAjaxConnections != null)
                {
                    return;
                }
                string script = "  (function() {" +
                    "var oldOpen = XMLHttpRequest.prototype.open;" +
                    "window.openHTTPs = 0;" +
                    "XMLHttpRequest.prototype.open = function(method, url, async, user, pass) {" +
                    "window.openHTTPs++;" +
                    "this.addEventListener('readystatechange', function() {" +
                    "if(this.readyState == 4) {" +
                    "window.openHTTPs--;" +
                    "}" +
                    "}, false);" +
                    "oldOpen.call(this, method, url, async, user, pass);" +
                    "}" +
                    "})();";
                js.ExecuteScript(script);

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static void PressKeyInBrowser(this IWebDriver driver, string key)
        {
            Actions actions = new Actions(driver);

            Log.Info("Press key: " + key + " in browser");

            actions.SendKeys(key)
                .Build()
                .Perform();
        }

        public static void KillAllProcessesByName(string processName)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName(processName))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}