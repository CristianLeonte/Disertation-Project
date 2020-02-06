using Framework.Utils;
using OpenQA.Selenium;

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

    }
}