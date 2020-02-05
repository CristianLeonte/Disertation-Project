using Framework.CustomMethods;
using Framework.Utils;
using Models.Common;
using Models.Hotels.HotelsManagement;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Threading;

namespace Models.Hotels.RoomsManagement
{
    public class AddRoomGeneralPage : BaseModel
    {
        public RoomAmenitiesPage RoomAmenitiesPage { get; set; }

        public AddRoomGeneralPage()
        {
            RoomAmenitiesPage = new RoomAmenitiesPage();
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/h3")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"content\"]/form/div/ul/li/a")]
        public IList<IWebElement> AddRoomSections { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"s2id_autogen1\"]/a")]
        public IWebElement RoomType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"select2-drop\"]/div/input")]
        public IWebElement RoomTypeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"s2id_autogen3\"]/a")]
        public IWebElement HotelName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"select2-drop\"]/div/input")]
        public IWebElement HotelNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body")]
        public IWebElement RoomDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[6]/div/input")]
        public IWebElement PriceInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[7]/div/input")]
        public IWebElement QuantityInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[8]/div/input")]
        public IWebElement MinimumStayInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[9]/div/input")]
        public IWebElement MaxAdultsInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[10]/div/input")]
        public IWebElement MaxChildrenInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[11]/div/input")]
        public IWebElement NrOfExtraBedsInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"GENERAL\"]/div[12]/div/input")]
        public IWebElement ExtraBedChargesInput { get; set; }

        [FindsBy(How = How.Id, Using = "add")]
        public IWebElement AddRoomButton { get; set; }

        [FindsBy(How = How.Id, Using = "update")]
        public IWebElement UpdateRoomButton { get; set; }


        public string Add_New_Room()
        {

            AddHotelGeneralPage addHotelGeneralPage = new AddHotelGeneralPage();
            var hotelName = addHotelGeneralPage.Add_New_Hotel();

            MainMenu mainMenu = new MainMenu();
            //mainMenu.HotelsButton.Clicks();

            //mainMenu.HotelsOptions[1].Clicks();

            RoomsPage roomsPage = new RoomsPage();
            roomsPage.AddRoomButton.ClickNavigator();

            var roomType = "Superior Park View";

            AddRoomGeneralPage addRoomGeneralPage = new AddRoomGeneralPage();

            addRoomGeneralPage.RoomType.Clicks();
            addRoomGeneralPage.RoomTypeInput.SendText(roomType);

            Actions actions = new Actions(Driver.MyDriver);
            actions.SendKeys(Keys.Enter).Build().Perform();
            actions.SendKeys(Keys.Escape).Build().Perform();

            addRoomGeneralPage.HotelName.Clicks();
            addRoomGeneralPage.HotelNameInput.SendText(hotelName);
            actions.SendKeys(Keys.Enter).Build().Perform();
            actions.SendKeys(Keys.Escape).Build().Perform();

            Thread.Sleep(5000);
            string winHandleBefore = Driver.MyDriver.CurrentWindowHandle;
            Driver.MyDriver.SwitchTo().Frame(Driver.MyDriver.FindElement(By.XPath("//*[@id=\"cke_1_contents\"]/iframe")));
            addRoomGeneralPage.RoomDescription.SendText("Lorem ipsum");

            Driver.MyDriver.SwitchTo().Window(winHandleBefore);

            addRoomGeneralPage.PriceInput.SendText("200");
            addRoomGeneralPage.QuantityInput.SendText("2");
            addRoomGeneralPage.MinimumStayInput.SendText("1");
            addRoomGeneralPage.MaxAdultsInput.SendText("4");
            addRoomGeneralPage.MaxChildrenInput.SendText("2");
            addRoomGeneralPage.NrOfExtraBedsInput.SendText("2");
            addRoomGeneralPage.ExtraBedChargesInput.SendText("50");

            addRoomGeneralPage.AddRoomSections[1].Clicks();

            RoomAmenitiesPage roomAmenitiesPage = new RoomAmenitiesPage();
            roomAmenitiesPage.SelectAllButton.Clicks();

            addRoomGeneralPage.AddRoomSections[0].Clicks();
            addRoomGeneralPage.AddRoomButton.Clicks();

            roomsPage.SearchRoomButton.Clicks();
            roomsPage.SearchRoomInput.SendText(hotelName);
            roomsPage.SearchRoomGoButton.Clicks();

            Thread.Sleep(1000);
            Assert.AreEqual(roomType, roomsPage.RoomType.GetText());
            Assert.AreEqual(hotelName, roomsPage.HotelName.GetText());

            roomsPage.SearchRoomResetButton.Clicks();

            return hotelName;
        }
        public virtual string Edit_Room(string hotelName)
        {
            RoomsPage roomsPage = new RoomsPage();

            roomsPage.SearchRoomButton.Clicks();
            roomsPage.SearchRoomInput.SendText(hotelName);
            roomsPage.SearchRoomGoButton.Clicks();

            Thread.Sleep(1000);
            roomsPage.EditRoomButton.Clicks();

            AddRoomGeneralPage addRoomGeneralPage = new AddRoomGeneralPage();

            var roomTypeEdited = "Presidential Suite";
            addRoomGeneralPage.RoomType.Clicks();
            addRoomGeneralPage.RoomTypeInput.SendText(roomTypeEdited);

            Actions actions = new Actions(Driver.MyDriver);
            actions.SendKeys(Keys.Enter).Build().Perform();
            actions.SendKeys(Keys.Escape).Build().Perform();


            Thread.Sleep(2000);
            string winHandleBefore = Driver.MyDriver.CurrentWindowHandle;
            Driver.MyDriver.SwitchTo().Frame(Driver.MyDriver.FindElement(By.XPath("//*[@id=\"cke_1_contents\"]/iframe")));
            addRoomGeneralPage.RoomDescription.SendText("Lorem ipsum edited");

            Driver.MyDriver.SwitchTo().Window(winHandleBefore);

            addRoomGeneralPage.PriceInput.SendText("250");
            addRoomGeneralPage.QuantityInput.SendText("3");
            addRoomGeneralPage.MinimumStayInput.SendText("1");
            addRoomGeneralPage.MaxAdultsInput.SendText("4");
            addRoomGeneralPage.MaxChildrenInput.SendText("2");
            addRoomGeneralPage.NrOfExtraBedsInput.SendText("2");
            addRoomGeneralPage.ExtraBedChargesInput.SendText("50");

            addRoomGeneralPage.UpdateRoomButton.Clicks();

            roomsPage.SearchRoomButton.Clicks();
            roomsPage.SearchRoomInput.SendText(hotelName);
            roomsPage.SearchRoomGoButton.Clicks();


            Assert.AreEqual(roomTypeEdited, roomsPage.RoomType.GetText());
            Assert.AreEqual(hotelName, roomsPage.HotelName.GetText());

            roomsPage.SearchRoomResetButton.Clicks();

            return hotelName;
        }
        public void Delete_Room(string hotelName)
        {
            RoomsPage roomsPage = new RoomsPage();

            roomsPage.SearchRoomButton.Clicks();
            roomsPage.SearchRoomInput.SendText(hotelName);
            roomsPage.SearchRoomGoButton.Clicks();

            Thread.Sleep(1000);

            roomsPage.DeleteRoomButton.Clicks();

            Driver.MyDriver.SwitchTo().Alert().Accept();

            roomsPage.SearchRoomButton.Clicks();
            roomsPage.SearchRoomInput.SendText(hotelName);
            roomsPage.SearchRoomGoButton.Clicks();

            Thread.Sleep(1000);
            Assert.AreEqual("Entries not found.", Driver.MyDriver.FindElement(By.CssSelector("[colspan]")).Text);
        }
    }


}