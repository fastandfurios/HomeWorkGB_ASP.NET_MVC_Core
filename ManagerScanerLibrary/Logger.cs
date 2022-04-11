using Serilog;
using ILogger = ManagerScannerLibrary.Interfaces.ILogger;

namespace ManagerScannerLibrary
{
    public sealed class Logger : ILogger
    {
        public Serilog.ILogger Log =>
            new LoggerConfiguration()
                .WriteTo.File("logs/scan_log.txt")
                .CreateLogger();

        public Logger()
        {
        }
    }
}
