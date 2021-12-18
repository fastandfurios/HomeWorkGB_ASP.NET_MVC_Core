using ManagerScannerLibrary.Interfaces;
using ScannerLibrary.Interfaces;
using Serilog;

namespace ManagerScannerLibrary
{
    public sealed class ManagerScannerService : IManagerScannerService
    {
        private readonly IScannerService _scanner;
        private IFormatScan _setupScan;

        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }

        public ManagerScannerService(IScannerService scanner)
        {
            _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("logs/scan_logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public async Task RunScanner()
        {
            try
            {
                await _setupScan.ScanAndSave(_scanner, SourceFileName, TargetFileName);
            }
            catch (IOException ex)
            {
                Log.Error(ex, "{0}", ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                Log.Error(ex, "{0}", ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Error(ex, "{0}", ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                Log.Error(ex, "{0}", ex.Message);
                throw;
            }
            catch (ObjectDisposedException ex)
            {
                Log.Error(ex, "{0}", ex.Message);
                throw;
            }
        }
        
        public void SetupScan(IFormatScan setupScan) => _setupScan = setupScan;
    }
}