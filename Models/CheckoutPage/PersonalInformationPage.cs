using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.CheckoutPage
{
    public class PersonalInformationPage : BaseModel
    {
        [FindsBy(How = How.CssSelector, Using = ".subheader")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.Id, Using = "first-name")]
        public IWebElement TxtFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "last-name")]
        public IWebElement TxtLastName { get; set; }

        [FindsBy(How = How.Id, Using = "postal-code")]
        public IWebElement TxtPostalCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn_secondary.cart_cancel_link")]
        public IWebElement BtnCancel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn_primary.cart_button")]
        public IWebElement BtnContinue { get; set; }

        [FindsBy(How = How.CssSelector, Using = "h3")]
        public IWebElement ErrorMessage { get; set; }
    }
}

