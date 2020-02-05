using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace Models.Common
{
    public class Header : BaseModel
    {
        [FindsBy(How = How.CssSelector, Using = ".bm-burger-button")]
        public IWebElement BtnMenu { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#shopping_cart_container > a > svg")]
        public IWebElement BtnCheckoutCart { get; set; }
    }
}