using System.Configuration;

namespace Tests.AppSettings
{
    public class User
    {
        public static string GetAppConfigKeyValue(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName];
        }
        public User(string webConfigKey)
        {
            var webConfigValue = GetAppConfigKeyValue(webConfigKey).Split('|');
            this.Username = webConfigValue[0].Trim();
            this.Password = webConfigValue[1].Trim();
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}