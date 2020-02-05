using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Tours
{
    public class TourContactPage : BaseModel
    {
        [FindsBy(How= How.XPath, Using ="//*[@id=\"CONTACT\"]/div[1]/div/input")]
        public IWebElement TourOperatorEmailAddress { get; set; }

        [FindsBy(How= How.XPath, Using ="//*[@id=\"CONTACT\"]/div[2]/div/input")]
        public IWebElement TourOperatorWebsite { get; set; }

        [FindsBy(How= How.XPath, Using ="//*[@id=\"CONTACT\"]/div[3]/div/input")]
        public IWebElement TourOperatorPhone { get; set; }

        [FindsBy(How= How.XPath, Using ="//*[@id=\"CONTACT\"]/div[4]/div/input")]
        public IWebElement TourOperatorAddress { get; set; }
    }
}