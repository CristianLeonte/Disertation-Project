using System.Collections.Generic;
using System.Linq;
using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.CustomMethods
{
    public static class SeleniumGetMethods
    {
        /// <summary>
        /// Extended method for getting the text
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetValue(this IWebElement element)
        {
            GenericMethods.ExplicitWaitElementVisible(element);
            Driver.MyDriver.WaitForPageLoad();
            return element.GetAttribute("value");

        }

        public static string GetText(this IWebElement element)
        {	        
            GenericMethods.ExplicitWaitElementVisible(element);
            Driver.MyDriver.WaitForPageLoad();
            return element.Text;
        }


        public static int GetCount(this IList<IWebElement> list)
        {
            GenericMethods.ExplicitWaitElementVisible(list[0]);
            Driver.MyDriver.WaitForPageLoad();
            return list.Count;
        }

        /// <summary>
        /// Extended method for getting the text in a dropdown
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetTextFromDropDown(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault()?.Text;
        }
    }
}