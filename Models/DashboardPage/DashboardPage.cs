using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.DashboardPage
{
    public class DashboardPage : BaseModel
    {
        [FindsBy(How = How.CssSelector, Using = ".product_label")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".product_sort_container")]
        public IWebElement ProductsFilterDropdown { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inventory_item_name")]
        public IList<IWebElement> ProductName { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".inventory_item_price")]
        public IList<IWebElement> ProductPrice { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn_inventory.btn_primary")]
        public IList<IWebElement> BtnAddToCart { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn_inventory.btn_secondary")]
        public IList<IWebElement> BtnRemoveFromCart { get; set; }
    }
}