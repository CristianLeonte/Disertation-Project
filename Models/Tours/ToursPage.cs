using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Models.Tours
{
    public class ToursPage : BaseModel
    {
        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div[2]/div[1]")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/div[2]/form/button")]
        public IWebElement AddTourButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr[1]/td[5]/a")]
        public IWebElement TourName { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr/td[11]/span/a[1]")]
        public IWebElement EditTourButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//table/tbody/tr/td[11]/span/a[2]")]
        public IWebElement DeleteTourButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/div[1]/div[3]/a")]
        public IWebElement SearchTourButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[3]/span[1]/input")]
        public IWebElement SearchTourInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[3]/span[1]/span/a")]
        public IWebElement SearchTourGoButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[3]/span[1]/span/a[2]")]
        public IWebElement SearchTourResetButton { get; set; }
    }
}