using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Threading;
using Framework.CustomMethods;
using Framework.Utils;
using Models.Common;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace Models.Hotels.HotelsManagement
{
    public class AddHotelGeneralPage : BaseModel
    {
        public HotelContactPage HotelContactPage { get; set; }
        public HotelFacilitiesPage HotelFacilitiesPage { get; set; }

        public AddHotelGeneralPage()
        {
            HotelContactPage = new HotelContactPage();
            HotelFacilitiesPage = new HotelFacilitiesPage();
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/h3")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/form/div/ul/li/a")]
        public IList<IWebElement> AddHotelSections { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[2]/div/select")]
        public IWebElement HotelStatus { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[3]/div/input")]
        public IWebElement HotelName { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body")]
        public IWebElement HotelDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[5]/div/select")]
        public IWebElement HotelStars { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[6]/div/select")]
        public IWebElement HotelType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"s2id_searching\"]/a/span[1]")]
        public IWebElement HotelLocation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"select2-drop\"]/div/input")]
        public IWebElement HotelLocationInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[9]/div[2]/input")]
        public IWebElement HotelDeposit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[10]/div[2]/input")]
        public IWebElement HotelVAT { get; set; }

        [FindsBy(How = How.Id, Using = "add")]
        public IWebElement AddHotelButton { get; set; }

        [FindsBy(How = How.Id, Using = "update")]
        public IWebElement UpdateHotelButton { get; set; }


        public virtual string Add_New_Hotel()
        {
            MainMenu mainMenu = new MainMenu();
            //mainMenu.HotelsButton.Clicks();

            //mainMenu.HotelsOptions[0].Clicks();

            HotelsPage hotelsPage = new HotelsPage();
            hotelsPage.AddHotelButton.ClickNavigator();

            AddHotelGeneralPage addHotelGeneralPage = new AddHotelGeneralPage();

            var hotelName = "Test Hotel 123";
            addHotelGeneralPage.HotelName.SendText(hotelName);
            Thread.Sleep(4000);
            string winHandleBefore = Driver.MyDriver.CurrentWindowHandle;
            Driver.MyDriver.SwitchTo().Frame(Driver.MyDriver.FindElement(By.XPath("//*[@id=\"cke_1_contents\"]/iframe")));
            addHotelGeneralPage.HotelDescription.SendText("Lorem ipsum");

            Driver.MyDriver.SwitchTo().Window(winHandleBefore);
            addHotelGeneralPage.HotelStars.Clicks();
            Actions actions = new Actions(Driver.MyDriver);

            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            actions.SendKeys(Keys.Enter).Build().Perform();

            addHotelGeneralPage.HotelType.Clicks();
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            actions.SendKeys(Keys.Enter).Build().Perform();

            addHotelGeneralPage.HotelLocation.Clicks();
            addHotelGeneralPage.HotelLocationInput.SendText("Copenhagen");
            Thread.Sleep(2000);
            actions.SendKeys(Keys.Enter).Build().Perform();
            actions.SendKeys(Keys.Escape).Build().Perform();

            addHotelGeneralPage.HotelDeposit.SendText("100");
            addHotelGeneralPage.HotelVAT.SendText("50");

            addHotelGeneralPage.AddHotelSections[1].Clicks();

            HotelFacilitiesPage hotelFacilitiesPage = new HotelFacilitiesPage();
            hotelFacilitiesPage.SelectAllButton.Clicks();

            addHotelGeneralPage.AddHotelSections[4].Clicks();

            HotelContactPage hotelContactPage = new HotelContactPage();
            hotelContactPage.HotelEmail.SendText("testEmail@hotel.com");
            hotelContactPage.HotelWebsite.SendText("https://www.google.com");
            hotelContactPage.HotelPhone.SendText("0123456789");

            addHotelGeneralPage.AddHotelSections[0].Clicks();
            addHotelGeneralPage.AddHotelButton.Clicks();

            hotelsPage.SearchHotelButton.Clicks();
            hotelsPage.SearchHotelInput.SendText(hotelName);
            hotelsPage.SearchHotelGoButton.Clicks();


            Assert.AreEqual(hotelName, hotelsPage.HotelName.GetText());

            hotelsPage.SearchHotelResetButton.Clicks();

            return hotelName;
        }
        public virtual string Edit_Hotel(string hotelName)
        {
            HotelsPage hotelsPage = new HotelsPage();

            hotelsPage.SearchHotelButton.Clicks();
            hotelsPage.SearchHotelInput.SendText(hotelName);
            hotelsPage.SearchHotelGoButton.Clicks();

            Thread.Sleep(1000);
            hotelsPage.EditHotelButton.Clicks();

            AddHotelGeneralPage addHotelGeneralPage = new AddHotelGeneralPage();

            var hotelNameEdited = "Test Hotel 123 Edited";
            addHotelGeneralPage.HotelName.SendText(hotelNameEdited);

            Thread.Sleep(2000);
            string winHandleBefore = Driver.MyDriver.CurrentWindowHandle;
            Driver.MyDriver.SwitchTo().Frame(Driver.MyDriver.FindElement(By.XPath("//*[@id=\"cke_1_contents\"]/iframe")));
            addHotelGeneralPage.HotelDescription.SendText("Lorem ipsum edited");

            Driver.MyDriver.SwitchTo().Window(winHandleBefore);

            addHotelGeneralPage.HotelDeposit.SendText("150");
            addHotelGeneralPage.HotelVAT.SendText("60");

            addHotelGeneralPage.UpdateHotelButton.Clicks();

            hotelsPage.SearchHotelButton.Clicks();
            hotelsPage.SearchHotelInput.SendText(hotelNameEdited);
            hotelsPage.SearchHotelGoButton.Clicks();


            Assert.AreEqual(hotelNameEdited, hotelsPage.HotelName.GetText());

            hotelsPage.SearchHotelResetButton.Clicks();

            return hotelNameEdited;
        }
        public void Delete_Hotel(string hotelName)
        {

            HotelsPage hotelsPage = new HotelsPage();

            hotelsPage.SearchHotelButton.Clicks();
            hotelsPage.SearchHotelInput.SendText(hotelName);
            hotelsPage.SearchHotelGoButton.Clicks();

            Thread.Sleep(1000);

            hotelsPage.DeleteHotelButton.Clicks();

            Driver.MyDriver.SwitchTo().Alert().Accept();

            hotelsPage.SearchHotelButton.Clicks();
            hotelsPage.SearchHotelInput.SendText(hotelName);
            hotelsPage.SearchHotelGoButton.Clicks();

            Thread.Sleep(1000);
            Assert.AreEqual("Entries not found.", Driver.MyDriver.FindElement(By.CssSelector("[colspan]")).Text);
        }
    }
}