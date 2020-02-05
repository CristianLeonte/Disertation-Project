using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Hotels.HotelsManagement
{
    public class HotelFacilitiesPage : BaseModel
    {
        [FindsBy(How=How.XPath, Using ="//*[@id=\"FACILITIES\"]/div/div/div[1]/label/div")]
        public IWebElement SelectAllButton { get; set; }
    }
}