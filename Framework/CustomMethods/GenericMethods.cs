using Framework.Utils;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Framework.CustomMethods
{
    public class GenericMethods
    {
        public static void ImplicitWaitElement(double seconds)
        {
            TimeSpan timeout = TimeSpan.FromSeconds(seconds);
            Driver.MyDriver.Manage().Timeouts().ImplicitWait.Add(timeout);
        }

        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                if (element.Displayed && element.Enabled)
                {// we need to call any method on the element in order to force Selenium to look it up
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                if (element.Enabled)
                {// we need to call any method on the element in order to force Selenium to look it up
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static void ExplicitWaitElementDisplayed(IWebElement element)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 15)
                {
                    //element not found, log the error
                    break;
                }
                if (IsElementDisplayed(element))
                {
                    //ok, we found the element
                    HighlightElement(element);
                    break;
                }
                Thread.Sleep(2000);
            }

        }
        public static void ExplicitWaitElementVisible(IWebElement element)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 15)
                {
                    //element not found, log the error
                    break;
                }
                if (IsElementPresent(element))
                {
                    //ok, we found the element
                    HighlightElement(element);
                    break;
                }
                Thread.Sleep(2000);
            }

        }

        public static void ExplicitWaitElementNotVisible(IWebElement element)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 15)
                {
                    //element found, log the error
                    break;
                }
                if (!IsElementPresent(element))
                {
                    //ok, we did not find the element anymore
                    break;
                }
                Thread.Sleep(2000);
            }

        }

        public static bool IsElementLoaded(IWebElement element)
        {
            try
            {
                if (element.Displayed && element.Enabled && element.Text != "loading...")
                {// we need to call any method on the element in order to force Selenium to look it up
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void ExplicitWaitElementLoaded(IWebElement element)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 15)
                {
                    //element not found, log the error
                    break;
                }
                if (IsElementLoaded(element))
                {
                    //ok, we found the element
                    HighlightElement(element);
                    break;
                }
                Thread.Sleep(3000);
            }

        }

        public static void HighlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver.MyDriver;
            jse.ExecuteScript("arguments[0].style.border='2px solid green'", element);
        }
    }
}