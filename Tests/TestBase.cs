using Framework.CustomMethods;
using Framework.Utils;
using Models.Authentication;
using Models.Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
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

        public void Login(User demoUser)
        {
            LoginPage.TxtUsername.SendText(demoUser.Username);
            Thread.Sleep(500);
            LoginPage.TxtPassword.SendText(demoUser.Password);
            Thread.Sleep(500);
            LoginPage.BtnLogin.ClickNavigator();
            Thread.Sleep(500);
        }

        public void Logout()
        {
           Header header = new Header();

           header.BtnMenu.Clicks();
           Thread.Sleep(500);

            MainMenu mainMenu = new MainMenu();

           mainMenu.BtnLogout.ClickNavigator();
           Thread.Sleep(500);
        }

        [SetUp]
        public virtual void SetUp()
        {
            Logger = new Logger();

            BrowserMethods<TWebDriver>.BrowserInstance();
            Driver.MyDriver.Navigate().GoToUrl(Environments.TestEnvironment.EnvironmentUrl);

            LoginPage = new LoginPage();

            Login(Users.DemoUser);
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