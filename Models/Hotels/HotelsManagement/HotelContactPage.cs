using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Hotels.HotelsManagement
{
    public class HotelContactPage : BaseModel
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"CONTACT\"]/div[1]/div/input")]
        public IWebElement HotelEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"CONTACT\"]/div[2]/div/input")]
        public IWebElement HotelWebsite { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"CONTACT\"]/div[3]/div/input")]
        public IWebElement HotelPhone { get; set; }
    }
}