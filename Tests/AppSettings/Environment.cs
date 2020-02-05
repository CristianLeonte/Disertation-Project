using System.Configuration;

namespace Tests.AppSettings
{
    public class Environment
    {
        public static string GetAppConfigKeyValue(string keyName)
        {
            return ConfigurationManager.AppSettings[keyName];
        }
        public Environment(string webConfigKey)
        {
            var webConfigValue = GetAppConfigKeyValue(webConfigKey);
            this.environmentURL = webConfigValue;
        }

        public string environmentURL { get; set; }
    }
}