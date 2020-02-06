using System.Configuration;

namespace Framework.AppSettings
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
            Username = webConfigValue[0].Trim();
            Password = webConfigValue[1].Trim();
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}