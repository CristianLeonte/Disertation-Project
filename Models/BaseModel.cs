using Framework.Utils;
using SeleniumExtras.PageObjects;

namespace Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            PageFactory.InitElements(Driver.MyDriver, this);
        }
    }
}