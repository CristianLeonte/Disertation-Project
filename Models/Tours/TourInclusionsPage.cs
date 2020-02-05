using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Tours
{
    public class TourInclusionsPage : BaseModel
    {
        [FindsBy(How = How.Id, Using = "select_all")]
        public IWebElement ChkSelectAll { get; set; }
    }
}