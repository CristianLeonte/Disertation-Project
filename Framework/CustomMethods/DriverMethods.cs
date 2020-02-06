using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Framework.CustomMethods
{
    public static class DriverMethods
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DriverMethods));

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
    }
}