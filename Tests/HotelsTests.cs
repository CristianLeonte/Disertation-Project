using Models.Hotels.HotelsManagement;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests
{
    public class HotelsTests<TWebDriver> : GlobalBase<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [Test]
        public void Add_Delete_Hotel()
        {
            AddHotelGeneralPage addHotelGeneralPage = new AddHotelGeneralPage();

            var hotelName = addHotelGeneralPage.Add_New_Hotel();

            addHotelGeneralPage.Delete_Hotel(hotelName);

            Logout();
            //Assert.True(LoginPage.UserPicture.Displayed);
        }

        [Test]
        public void Edit_Hotel_Details()
        {
            AddHotelGeneralPage addHotelGeneralPage = new AddHotelGeneralPage();

            var hotelName = addHotelGeneralPage.Add_New_Hotel();

            var hotelNameEdited = addHotelGeneralPage.Edit_Hotel(hotelName);

            addHotelGeneralPage.Delete_Hotel(hotelNameEdited);

            Logout();
            //Assert.True(LoginPage.UserPicture.Displayed);
        }
    }
}