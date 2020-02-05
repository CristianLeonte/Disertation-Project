using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Hotels.RoomsManagement
{
    public class RoomsPage : BaseModel
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div[2]/div[1]")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div[2]/form/button")]
        public IWebElement AddRoomButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[3]/a")]
        public IWebElement RoomType { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[4]")]
        public IWebElement HotelName { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[11]/span/a[1]")]
        public IWebElement EditRoomButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[11]/span/a[2]")]
        public IWebElement DeleteRoomButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/div[1]/div[3]/a")]
        public IWebElement SearchRoomButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[3]/span[1]/input")]
        public IWebElement SearchRoomInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[3]/span[1]/span/a")]
        public IWebElement SearchRoomGoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[3]/span[1]/span/a[2]")]
        public IWebElement SearchRoomResetButton { get; set; }
    }
}