using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Common
{
    public class MainMenu : BaseModel
    {
        [FindsBy(How = How.CssSelector, Using = ".bm-menu-wrap button")]
        public IWebElement BtnCloseMenu { get; set; }

        [FindsBy(How = How.Id, Using = "inventory_sidebar_link")]
        public IWebElement BtnAllItems { get; set; }

        [FindsBy(How = How.Id, Using = "about_sidebar_link")]
        public IWebElement BtnAbout { get; set; }

        [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
        public IWebElement BtnLogout { get; set; }

        [FindsBy(How = How.Id, Using = "reset_sidebar_link")]
        public IWebElement BtnResetAppState { get; set; }

    }
}