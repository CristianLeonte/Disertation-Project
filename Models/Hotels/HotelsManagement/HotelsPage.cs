using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Hotels
{
    public class HotelsPage : BaseModel
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div[2]/div[1]")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div[2]/form/button")]
        public IWebElement AddHotelButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[5]/a")]
        public IWebElement HotelName { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr/td[12]/span/a[2]")]
        public IWebElement EditHotelButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr/td[12]/span/a[3]")]
        public IWebElement DeleteHotelButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/div[1]/div[3]/a")]
        public IWebElement SearchHotelButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[3]/span[1]/input")]
        public IWebElement SearchHotelInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[3]/span[1]/span/a")]
        public IWebElement SearchHotelGoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[3]/span[1]/span/a[2]")]
        public IWebElement SearchHotelResetButton { get; set; }
    }
}