using Models.Hotels.HotelsManagement;
using Models.Tours;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests
{
    public class ToursTests<TWebDriver> : GlobalBase<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [Test]
        public void Add_Delete_Tour()
        {
            AddTourGeneralPage addTourGeneralPage = new AddTourGeneralPage();

            var tourName = addTourGeneralPage.Add_New_Tour();

            addTourGeneralPage.Delete_Tour(tourName);

            Logout();
            //Assert.True(LoginPage.UserPicture.Displayed);
        }

        [Test]
        public void Edit_Tour_Details()
        {
            AddTourGeneralPage addTourGeneralPage = new AddTourGeneralPage();

            var tourName = addTourGeneralPage.Add_New_Tour();

            var tourNameEdited = addTourGeneralPage.Edit_Tour(tourName);

            addTourGeneralPage.Delete_Tour(tourNameEdited);

            Logout();
            //Assert.True(LoginPage.UserPicture.Displayed);
        }
    }
}