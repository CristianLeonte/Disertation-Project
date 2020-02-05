using Framework.CustomMethods;
using Models.Dashboard;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests
{
    public class LoginTests<TWebDriver> : GlobalBase<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [Test]
        public void Login_Application()
        {
            DashboardPage dashboardPage = new DashboardPage();

            Assert.AreEqual("Products", dashboardPage.PageTitle.GetText());

            Logout();

            Assert.True(LoginPage.BotPicture.Displayed);
        }

    }
}