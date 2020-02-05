using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Tours
{
    public class TourExclusionsPage : BaseModel
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"select_all\"]")]
        public IList<IWebElement> ChkSelectAll { get; set; }
    }
}