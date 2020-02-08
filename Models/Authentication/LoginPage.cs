using Framework.AppSettings;
using Framework.CustomMethods;
using Models.Common;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Models.Authentication
{
    public class LoginPage : BaseModel
    {
        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement TxtUsername { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn_action")]
        public IWebElement BtnLogin { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".bot_column")]
        public IWebElement BotPicture { get; set; }

        public void Login(User demoUser)
        {
            TxtUsername.SendText(demoUser.Username);
            Thread.Sleep(500);
            TxtPassword.SendText(demoUser.Password);
            Thread.Sleep(500);
            BtnLogin.ClickNavigator();
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
    }
}