using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Hotels.RoomsManagement
{
    public class RoomAmenitiesPage : BaseModel
    {
        [FindsBy(How=How.XPath, Using ="//*[@id=\"AMENITIES\"]/div/div/div[1]/label/div")]
        public IWebElement SelectAllButton { get; set; }
    }
}