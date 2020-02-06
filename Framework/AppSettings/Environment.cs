using System.Configuration;

namespace Framework.AppSettings
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
            EnvironmentUrl = webConfigValue;
        }

        public string EnvironmentUrl { get; set; }
    }
}