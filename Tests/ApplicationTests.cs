using System.Threading;
using Framework.CustomMethods;
using Framework.Utils;
using Models.CartPage;
using Models.CheckoutPage;
using Models.Common;
using Models.DashboardPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Tests
{
    public class ApplicationTests<TWebDriver> : TestBase<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public DashboardPage DashboardPage => new DashboardPage();
        public Header Header => new Header();
        public CartPage CartPage => new CartPage();
        public CheckoutPage CheckoutPage => new CheckoutPage();


        [Test]
        public void Login_Application_Success()
        {
            Assert.AreEqual("Products", DashboardPage.PageTitle.GetText());

            LoginPage.Logout();

            Assert.True(LoginPage.BotPicture.Displayed);
        }

        [Test]
        public void Login_Application_Fail()
        {
            Assert.AreEqual("Productss", DashboardPage.PageTitle.GetText());

            LoginPage.Logout();

            Assert.True(LoginPage.BotPicture.Displayed);
        }

        [Test]
        public void Place_Order()
        {
            DashboardPage.ProductsFilterDropdown.Clicks();

            Thread.Sleep(1000);

            Actions actions = new Actions(Driver.MyDriver);

            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(200);
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(200);
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(200);
            actions.SendKeys(Keys.Enter).Build().Perform();

            Thread.Sleep(1000);

            DashboardPage.BtnAddToCart[0].Clicks();

            Thread.Sleep(1000);

            Header.BtnCheckoutCart.ClickNavigator();

            Thread.Sleep(1000);

            CartPage.BtnCheckout.ClickNavigator();

            Thread.Sleep(1000);

            CheckoutPage.PersonalInformationPage.TxtFirstName.SendText("Cristian");

            Thread.Sleep(500);
            CheckoutPage.PersonalInformationPage.TxtLastName.SendText("Leonte");

            Thread.Sleep(500);
            CheckoutPage.PersonalInformationPage.TxtPostalCode.SendText("002233");

            Thread.Sleep(500);

            CheckoutPage.PersonalInformationPage.BtnContinue.ClickNavigator();

            Thread.Sleep(1000);

            CheckoutPage.OverviewPage.BtnFinish.ClickNavigator();

            Thread.Sleep(1000);

            Assert.AreEqual("THANK YOU FOR YOUR ORDER", CheckoutPage.ConfirmationPage.TxtOrderConfirmation.GetText());

            LoginPage.Logout();

            Thread.Sleep(1000);

            Assert.True(LoginPage.BotPicture.Displayed);
        }

        [Test]
        public void Place_Order_Without_Filling_Personal_Information()
        {
            DashboardPage.ProductsFilterDropdown.Clicks();

            Thread.Sleep(1000);

            Actions actions = new Actions(Driver.MyDriver);

            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(200);
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(200);
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(200);
            actions.SendKeys(Keys.Enter).Build().Perform();

            Thread.Sleep(1000);

            DashboardPage.BtnAddToCart[0].Clicks();

            Thread.Sleep(1000);

            Header.BtnCheckoutCart.ClickNavigator();

            Thread.Sleep(1000);

            CartPage.BtnCheckout.ClickNavigator();

            Thread.Sleep(1000);

            CheckoutPage.PersonalInformationPage.BtnContinue.Clicks();
            Assert.True(CheckoutPage.PersonalInformationPage.ErrorMessage.GetText().Contains("Error: First Name is required"));

            Thread.Sleep(1000);

            CheckoutPage.PersonalInformationPage.TxtFirstName.SendText("Cristian");

            CheckoutPage.PersonalInformationPage.BtnContinue.Clicks();
            Assert.True(CheckoutPage.PersonalInformationPage.ErrorMessage.GetText().Contains("Error: Last Name is required"));

            Thread.Sleep(1000);

            CheckoutPage.PersonalInformationPage.TxtLastName.SendText("Leonte");

            CheckoutPage.PersonalInformationPage.BtnContinue.Clicks();
            Assert.True(CheckoutPage.PersonalInformationPage.ErrorMessage.GetText().Contains("Error: Postal Code is required"));

            Thread.Sleep(1000);

            LoginPage.Logout();

            Thread.Sleep(1000);

            Assert.True(LoginPage.BotPicture.Displayed);
        }

        [Test]
        public void Remove_Item_From_Cart()
        {
            DashboardPage.ProductsFilterDropdown.Clicks();

            Thread.Sleep(1000);

            Actions actions = new Actions(Driver.MyDriver);

            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(200);
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(200);
            actions.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(200);
            actions.SendKeys(Keys.Enter).Build().Perform();

            Thread.Sleep(1000);

            DashboardPage.BtnAddToCart[0].Clicks();

            Thread.Sleep(100);

            DashboardPage.BtnAddToCart[1].Clicks();

            Thread.Sleep(1000);

            Header.BtnCheckoutCart.ClickNavigator();

            Thread.Sleep(1000);

            Assert.AreEqual(2, CartPage.ProductName.Count);

            CartPage.BtnRemoveProduct[1].Clicks();

            Thread.Sleep(1000);

            Assert.AreEqual(1, CartPage.ProductName.Count);

            CartPage.BtnCheckout.ClickNavigator();

            Thread.Sleep(1000);

            CheckoutPage.PersonalInformationPage.TxtFirstName.SendText("Cristian");

            Thread.Sleep(500);
            CheckoutPage.PersonalInformationPage.TxtLastName.SendText("Leonte");

            Thread.Sleep(500);
            CheckoutPage.PersonalInformationPage.TxtPostalCode.SendText("002233");

            Thread.Sleep(500);

            CheckoutPage.PersonalInformationPage.BtnContinue.ClickNavigator();

            Thread.Sleep(1000);

            CheckoutPage.OverviewPage.BtnFinish.ClickNavigator();

            Thread.Sleep(1000);

            Assert.AreEqual("THANK YOU FOR YOUR ORDER", CheckoutPage.ConfirmationPage.TxtOrderConfirmation.GetText());

           LoginPage.Logout();

            Thread.Sleep(1000);

            Assert.True(LoginPage.BotPicture.Displayed);
        }

    }
}