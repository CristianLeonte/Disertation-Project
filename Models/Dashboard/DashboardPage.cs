using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Dashboard
{
    public class DashboardPage : BaseModel
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"inventory_filter_container\"]/div")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#inventory_filter_container > .product_sort_container")]
        public IWebElement ProductsFilterDropdown { get; set; }
    }
}