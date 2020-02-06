using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.CartPage
{
    public class CartPage : BaseModel
    {
        [FindsBy(How = How.CssSelector, Using = ".subheader")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".cart_quantity")]
        public IList<IWebElement> ProductQuantity { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inventory_item_name")]
        public IList<IWebElement> ProductName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inventory_item_price")]
        public IList<IWebElement> ProductPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn_secondary.cart_button")]
        public IList<IWebElement> BtnRemoveProduct { get; set; }

        [FindsBy(How=How.CssSelector, Using = ".cart_footer .btn_secondary")]
        public IWebElement BtnContinueShopping { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn_action.checkout_button")]
        public IWebElement BtnCheckout { get; set; }

    }
}