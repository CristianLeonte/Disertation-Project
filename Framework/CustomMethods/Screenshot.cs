using Framework.Logging;
using Framework.Utils;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;

namespace Framework.CustomMethods
{
    public class Screenshot
    {
        public Logger Logger;
        public static string TakeScreenshot(string filenamePrefix, string filenamePostfix)
        {
            filenamePrefix = filenamePrefix == string.Empty ? string.Empty : filenamePrefix + " ";
            filenamePostfix = filenamePostfix == string.Empty ? string.Empty : " " + filenamePostfix;

            var directoryPath = ConfigurationManager.AppSettings["PrintScreenFilePath"];

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var now = DateTime.Now;
            var fileNamePath = string.Format(
                "{0}\\{1}{2:00}.{3:00}.{4:00} {5:00};{6:00};{7:00}{8}.png",
                directoryPath,
                RemoveRestrictedFilenameChars(filenamePrefix),
                now.Year,
                now.Month,
                now.Day,
                now.Hour,
                now.Minute,
                now.Second,
                RemoveRestrictedFilenameChars(filenamePostfix));

            try
            {
                Logger.Write("Taking screenshot [" + fileNamePath + "]", Logger.LogType.Info);

                var screenshot = ((ITakesScreenshot)Driver.MyDriver).GetScreenshot();
                screenshot.SaveAsFile(fileNamePath, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return fileNamePath;
        }

        private static string RemoveRestrictedFilenameChars(string input)
        {
            var restrictedString =
                input.Replace(':', ' ')
                    .Replace('|', ' ')
                    .Replace('*', ' ')
                    .Replace('"', ' ')
                    .Replace('?', ' ')
                    .Replace('\\', ' ')
                    .Replace('/', ' ')
                    .Replace('<', ' ')
                    .Replace('>', ' ');
            //// .Replace(';', ' ')
            //// .Replace('=', ' ')
            //// .Replace(',', ' ')
            //// .Replace('[', ' ')
            //// .Replace(']', ' ')

            return restrictedString.Length <= 255 ? restrictedString : restrictedString.Substring(0, 255);
        }
    }
}