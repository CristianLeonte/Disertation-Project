namespace Models.CheckoutPage
{
    public class CheckoutPage : BaseModel
    {
        public PersonalInformationPage PersonalInformationPage => new PersonalInformationPage();

        public OverviewPage OverviewPage => new OverviewPage();

        public ConfirmationPage ConfirmationPage => new ConfirmationPage();
    }
}