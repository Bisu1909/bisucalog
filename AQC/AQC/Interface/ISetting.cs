using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    public interface ISetting
    {
        string BaseUrl { get; }
        int ImplicitWaitInmilliseconds { get; }
        string UserName { get;}
        string Password { get; }
        string ReadSetting(string key);
        string ScreenshotFilePath { get; }
        string ConnectionString { get; }
    }
}
