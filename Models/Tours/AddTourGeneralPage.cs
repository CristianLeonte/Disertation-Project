using Framework.CustomMethods;
using Framework.Utils;
using Models.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Threading;

namespace Models.Tours
{
    public class AddTourGeneralPage : BaseModel
    {

        public TourContactPage TourContactPage { get; set; }
        public TourInclusionsPage TourInclusionsPage { get; set; }
        public TourExclusionsPage TourExclusionsPage { get; set; }

        public AddTourGeneralPage()
        {
            TourContactPage = new TourContactPage();
            TourInclusionsPage = new TourInclusionsPage();
            TourExclusionsPage = new TourExclusionsPage();
        }



        [FindsBy(How = How.CssSelector, Using = "#content > form > div > ul > li > a")]
        public IList<IWebElement> AddTourSections { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[2]/div/select")]
        public IWebElement TourStatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[3]/div/input")]
        public IWebElement TourName { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body")]
        public IWebElement TourDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[5]/div/table/tbody/tr[2]/td[2]/input")]
        public IWebElement TourAdultsQuantity { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[5]/div/table/tbody/tr[3]/td[2]/input")]
        public IWebElement TourAdultsPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[6]/div/select")]
        public IWebElement TourStars { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[7]/div/input")]
        public IWebElement TourHours { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[8]/div/input")]
        public IWebElement TourDays { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[9]/div/input")]
        public IWebElement TourNights { get; set; }

        [FindsBy(How = How.Id, Using = "s2id_autogen11")]
        public IWebElement TourTypeDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"select2-drop\"]/ul/li")]
        public IList<IWebElement> TourTypeDropdownOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"s2id_locationlist1\"]")]
        public IWebElement TourLocation1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"s2id_locationlist2\"]")]
        public IWebElement TourLocation2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"select2-drop\"]/div/input")]
        public IWebElement TourLocationInput { get; set; }

        [FindsBy(How = How.Id, Using = "add")]
        public IWebElement AddTourButton { get; set; }

        [FindsBy(How = How.Id, Using = "update")]
        public IWebElement UpdateTourButton { get; set; }


        public virtual string Add_New_Tour()
        {
            MainMenu mainMenu = new MainMenu();
            //mainMenu.ToursButton.Clicks();

            //mainMenu.ToursOptions[0].Clicks();

            ToursPage toursPage = new ToursPage();
            toursPage.AddTourButton.ClickNavigator();

            AddTourGeneralPage addTourGeneralPage = new AddTourGeneralPage();

            var tourName = "Test Hotel 123";
            addTourGeneralPage.TourName.SendText(tourName);
            Thread.Sleep(4000);
            string winHandleBefore = Driver.MyDriver.CurrentWindowHandle;
            Driver.MyDriver.SwitchTo().Frame(Driver.MyDriver.FindElement(By.XPath("//*[@id=\"cke_1_contents\"]/iframe")));
            addTourGeneralPage.TourDescription.SendText("Lorem ipsum");

            Driver.MyDriver.SwitchTo().Window(winHandleBefore);

            addTourGeneralPage.TourAdultsQuantity.SendText("4");
            addTourGeneralPage.TourAdultsPrice.SendText("300");
            addTourGeneralPage.TourStars.Clicks();
            Actions actions = new Actions(Driver.MyDriver);

            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            actions.SendKeys(Keys.Enter).Build().Perform();

            addTourGeneralPage.TourHours.SendText("20");
            addTourGeneralPage.TourDays.SendText("2");
            addTourGeneralPage.TourNights.SendText("2");

            addTourGeneralPage.TourTypeDropdown.Clicks();
            addTourGeneralPage.TourTypeDropdownOptions[2].Clicks();

            addTourGeneralPage.TourLocation1.Clicks();
            addTourGeneralPage.TourLocationInput.SendText("Copenhagen");
            Thread.Sleep(2000);
            actions.SendKeys(Keys.Enter).Build().Perform();
            actions.SendKeys(Keys.Escape).Build().Perform();

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.MyDriver;
            js.ExecuteScript("window.scrollTo(0, 0)");

            addTourGeneralPage.AddTourSections[1].Clicks();

            TourInclusionsPage tourInclusionsPage = new TourInclusionsPage();
            tourInclusionsPage.ChkSelectAll.Clicks();

            js.ExecuteScript("window.scrollTo(0, 0)");

            addTourGeneralPage.AddTourSections[2].Clicks();

            TourExclusionsPage tourExclusionsPage = new TourExclusionsPage();
            tourExclusionsPage.ChkSelectAll[1].Clicks();

            js.ExecuteScript("window.scrollTo(0, 0)");

            addTourGeneralPage.AddTourSections[5].Clicks();


            TourContactPage tourContactPage = new TourContactPage();
            tourContactPage.TourOperatorEmailAddress.SendText("testEmail@hotel.com");
            tourContactPage.TourOperatorWebsite.SendText("https://www.google.com");
            tourContactPage.TourOperatorPhone.SendText("0123456789");
            tourContactPage.TourOperatorAddress.SendText("Testing street");

            addTourGeneralPage.AddTourSections[0].Clicks();

            js.ExecuteScript("arguments[0].scrollIntoView(true);", addTourGeneralPage.AddTourButton);
            addTourGeneralPage.AddTourButton.Clicks();

            toursPage.SearchTourButton.Clicks();
            toursPage.SearchTourInput.SendText(tourName);
            toursPage.SearchTourGoButton.Clicks();

            Assert.AreEqual(tourName, toursPage.TourName.GetText());

            toursPage.SearchTourResetButton.Clicks();

            return tourName;
        }
        public virtual string Edit_Tour(string tourName)
        {
            ToursPage toursPage = new ToursPage();

            toursPage.SearchTourButton.Clicks();
            toursPage.SearchTourInput.SendText(tourName);
            toursPage.SearchTourGoButton.Clicks();

            Thread.Sleep(1000);
            toursPage.EditTourButton.Clicks();

            AddTourGeneralPage addTourGeneralPage = new AddTourGeneralPage();

            var tourNameEdited = "Test Hotel 123";
            addTourGeneralPage.TourName.SendText(tourNameEdited);
            Thread.Sleep(4000);
            string winHandleBefore = Driver.MyDriver.CurrentWindowHandle;
            Driver.MyDriver.SwitchTo().Frame(Driver.MyDriver.FindElement(By.XPath("//*[@id=\"cke_1_contents\"]/iframe")));
            addTourGeneralPage.TourDescription.SendText("Lorem ipsum");

            Driver.MyDriver.SwitchTo().Window(winHandleBefore);

            addTourGeneralPage.TourHours.SendText("20");
            addTourGeneralPage.TourDays.SendText("2");
            addTourGeneralPage.TourNights.SendText("2");

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.MyDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", addTourGeneralPage.AddTourButton);

            addTourGeneralPage.UpdateTourButton.Clicks();

            toursPage.SearchTourButton.Clicks();
            toursPage.SearchTourInput.SendText(tourNameEdited);
            toursPage.SearchTourGoButton.Clicks();


            Assert.AreEqual(tourNameEdited, toursPage.TourName.GetText());

            toursPage.SearchTourResetButton.Clicks();

            return tourNameEdited;
        }
        public void Delete_Tour(string tourName)
        {

            ToursPage toursPage = new ToursPage();

            toursPage.SearchTourButton.Clicks();
            toursPage.SearchTourInput.SendText(tourName);
            toursPage.SearchTourGoButton.Clicks();

            Thread.Sleep(1000);

            toursPage.DeleteTourButton.Clicks();

            Driver.MyDriver.SwitchTo().Alert().Accept();

            toursPage.SearchTourButton.Clicks();
            toursPage.SearchTourInput.SendText(tourName);
            toursPage.SearchTourGoButton.Clicks();

            Thread.Sleep(1000);
            Assert.AreEqual("Entries not found.", Driver.MyDriver.FindElement(By.CssSelector("[colspan]")).Text);
        }
    }
}