using Framework.CustomMethods;
using Framework.Utils;
using Models.Authentication;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Framework.AppSettings;
using Logger = Framework.Logging.Logger;
using Screenshot = Framework.CustomMethods.Screenshot;

namespace Tests
{
    [TestFixture(typeof(ChromeDriver))]
    public class TestBase<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public static Logger Logger { get; set; }

        public LoginPage LoginPage { get; set; }

        [SetUp]
        public virtual void SetUp()
        {
            Logger = new Logger();

            BrowserMethods<TWebDriver>.BrowserInstance();
            Driver.MyDriver.Navigate().GoToUrl(Environments.TestEnvironment.EnvironmentUrl);

            LoginPage = new LoginPage();

            LoginPage.Login(Users.DemoUser);
        }


        [TearDown]
        public virtual void TearDown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    var error = TestContext.CurrentContext.Result.Message;

                    var filePath = Screenshot.TakeScreenshot(String.Empty, string.Empty);

                    throw new Exception("" + error + "\nScreenshot file path: " + filePath + "\n");
                }
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }
            finally
            {
                Driver.MyDriver.Close();
                Driver.MyDriver.Quit();
            }
        }
        

    }
}