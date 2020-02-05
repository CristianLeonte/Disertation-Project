using Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Framework.CustomMethods
{
    public class BrowserMethods<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public static void BrowserInstance()
        {
            if (typeof(TWebDriver) == typeof(ChromeDriver))
            {
                Driver.MyDriver = new ChromeDriver(SetChromeOptions());
                Driver.MyDriver.Manage().Window.Maximize();
            }
            else
            if (typeof(TWebDriver) == typeof(InternetExplorerDriver))
            {
                Driver.MyDriver = new InternetExplorerDriver();
                Driver.MyDriver.Manage().Window.Maximize();

            }
            else
            {
                Driver.MyDriver = new FirefoxDriver();
                Driver.MyDriver.Manage().Window.Maximize();

            }

        }

        private static ChromeOptions SetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArguments("--no-sandbox");
            options.AddArguments("--always-authorize-plugins");
            options.AddArguments("--disable-application-cache");
            options.AddArguments("--disable-session-crashed-bubble");
            options.AddArguments("--disable-infobars");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArguments("--incognito");
            //options.AddArguments("--window-size=1920,1080");
            // Maximize browser for Mac/Linux: options.AddArguments("--kiosk");
            //options.AddArguments("--start-maximized");
            //options.AddArguments("--start-fullscreen");        
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            return options;
        }
    }
}