using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQC.Interface
{
    public interface ILog
    {
        string Context { get; set; }
        void LogInfo(string logMessage);

        void LogDebug(string logMessage);

        void LogWarning(string logMessage);

        void LogError(string logMessage);

        void LogFatal(string logMessage);
    }
}
