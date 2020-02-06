using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.CheckoutPage
{
    public class OverviewPage : BaseModel
    {
        [FindsBy(How = How.CssSelector, Using = ".subheader")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".summary_quantity")]
        public IList<IWebElement> ProductQuantity { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inventory_item_name")]
        public IList<IWebElement> ProductName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inventory_item_price")]
        public IList<IWebElement> ProductPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".summary_info .summary_value_label:nth-of-type(2)")]
        public IWebElement TxtPaymentInformation { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".summary_info .summary_value_label:nth-of-type(4)")]
        public IWebElement TxtShippingInformation { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".summary_total_label")]
        public IWebElement TxtTotalPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn_secondary.cart_cancel_link")]
        public IWebElement BtnCancel { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn_action.cart_button")]
        public IWebElement BtnFinish { get; set; }
    }
}
