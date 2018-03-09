using AQC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC
{
    public class Setting : ISetting
    {
        public string BaseUrl => System.Configuration.ConfigurationManager.AppSettings["BaseUrl"];

        public int ImplicitWaitInmilliseconds => int.Parse(System.Configuration.ConfigurationManager.AppSettings["ImplicitWaitInmilliseconds"]);

        public string UserName => System.Configuration.ConfigurationManager.AppSettings["UserName"];
        public string Password => System.Configuration.ConfigurationManager.AppSettings["Password"];
        public string ScreenshotFilePath => System.Configuration.ConfigurationManager.AppSettings["ScreenshotFilePath"];
        public string ConnectionString => System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        public string ReadSetting(string key)
        {
            return string.Empty;
        }
    }
}
