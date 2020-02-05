using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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
    }
}