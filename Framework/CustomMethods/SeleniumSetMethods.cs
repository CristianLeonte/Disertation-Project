using System;
using System.Threading;
using Framework.Utils;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.CustomMethods
{
    public static class SeleniumSetMethods
    {

        private static ILog _log = LogManager.GetLogger(typeof(SeleniumSetMethods));

        public static void DefaultWait(IWebElement element)
        {
            var wait = new DefaultWait<IWebDriver>(Driver.MyDriver)
            {
                PollingInterval = TimeSpan.FromMilliseconds(300),
                Timeout = TimeSpan.FromSeconds(30)
            };
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));

            wait.Until(webDriver =>
            {
                try
                {
                    wait.Until(WaitUntilAvailable(element));
                    return true;
                }
                catch (StaleElementReferenceException e)
                {
                    _log.Error($"Following error is thrown {e}");
                }

                catch (NoSuchElementException e)
                {
                    _log.Error($"Following error is thrown {e}");
                }
                return false;
            });
        }

        public static Func<IWebDriver, bool> WaitUntilAvailable(IWebElement element)
        {
            return (driver) => IsAvailable(element);
        }

        public static bool IsAvailable(IWebElement element)
        {
            return element != null && element.Displayed && element.Enabled;
        }

        public static IWebElement Element(this IWebElement element)
        {
            DefaultWait(element);
            HighlightElement(element);
            return element;
        }

        /// <summary>
        /// Extended method for entering text in a control
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SendText(this IWebElement element, string value)
        {
            //GenericMethods.ExplicitWaitElementVisible(element);
            //clear the field
            Element(element).Clear();
            //enter the text
            Element(element).SendKeys(value);
        }

        /// <summary>
        /// Extended method to click into a button
        /// </summary>
        /// <param name="element"></param>
        public static void Clicks(this IWebElement element)
        {
            //GenericMethods.ExplicitWaitElementVisible(element);
            Element(element).Click();
        }

        public static void ClickNavigator(this IWebElement element)
        {
           // GenericMethods.ExplicitWaitElementVisible(element);
            Element(element).Click();
            Driver.MyDriver.WaitForPageLoad();
        }

        public static void HighlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver.MyDriver;
            jse.ExecuteScript("arguments[0].style.border='2px solid green'", element);
        }

    }
}