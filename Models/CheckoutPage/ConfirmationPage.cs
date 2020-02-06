using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.CheckoutPage
{
    public class ConfirmationPage : BaseModel
    {
        [FindsBy(How = How.CssSelector, Using = ".subheader")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".complete-header")]
        public IWebElement TxtOrderConfirmation { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".pony_express")]
        public IWebElement ConfirmationPicture { get; set; }
    }
}
