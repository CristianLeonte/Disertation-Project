using Framework.CustomMethods;
using Framework.Utils;
using Models.Authentication;
using Models.Common;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Framework.Logging;
using Tests.AppSettings;
using Logger = Framework.Logging.Logger;
using Screenshot = Framework.CustomMethods.Screenshot;

namespace Tests
{
    [TestFixture(typeof(ChromeDriver))]
    public class GlobalBase<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public ILogger Logger => new Logger();
        public LoginPage LoginPage { get; set; }

        public void Login(User demoUser)
        {
            LoginPage.TxtUsername.SendText(demoUser.Username);
            LoginPage.TxtPassword.SendText(demoUser.Password);
            LoginPage.BtnLogin.ClickNavigator();
        }

        public void Logout()
        {
           Header header = new Header();

           header.BtnMenu.Clicks();
           
           MainMenu mainMenu = new MainMenu();

           mainMenu.BtnLogout.ClickNavigator();
        }

        [SetUp]
        public virtual void SetUp()
        {
            BrowserMethods<TWebDriver>.BrowserInstance();
            Driver.MyDriver.Navigate().GoToUrl(Environments.TestEnvironment.environmentURL);

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

                    throw new Exception("### AT: " + error + "\nScreenshot file path: " + filePath + "\n");
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