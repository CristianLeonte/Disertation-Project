using Models.Hotels.RoomsManagement;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests
{
    public class RoomsTests<TWebDriver> : GlobalBase<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [Test]
        public void Add_Delete_Room()
        {
            AddRoomGeneralPage addRoomGeneralPage = new AddRoomGeneralPage();

            var room = addRoomGeneralPage.Add_New_Room();

            addRoomGeneralPage.Delete_Room(room);

            Logout();
            //Assert.True(LoginPage.UserPicture.Displayed);
        }

        [Test]
        public void Edit_Room_Details()
        {
            AddRoomGeneralPage addRoomGeneralPage = new AddRoomGeneralPage();

            var room = addRoomGeneralPage.Add_New_Room();

            var roomEdited = addRoomGeneralPage.Edit_Room(room);

            addRoomGeneralPage.Delete_Room(roomEdited);

            Logout();
            //Assert.True(LoginPage.UserPicture.Displayed);
        }
    }
}