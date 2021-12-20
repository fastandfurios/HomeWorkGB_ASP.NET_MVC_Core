using ManagerScannerLibrary.Interfaces;
using ScannerLibrary.Interfaces;

namespace ManagerScannerLibrary
{
    public sealed class ManagerScannerService : IManagerScannerService
    {
        private readonly ILogger _logger;
        private readonly IScannerService _scanner;
        private IFormatScan _setupScan;

        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }

        public ManagerScannerService(IScannerService scanner, ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _scanner = scanner ?? throw new ArgumentNullException(nameof(scanner));
        }

        public async Task RunScanner()
        {
            try
            {
                await _setupScan.ScanAndSave(_scanner, SourceFileName, TargetFileName);
            }
            catch (IOException ex)
            {
                _logger.Log.Error(ex, "{0}", ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                _logger.Log.Error(ex, "{0}", ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.Log.Error(ex, "{0}", ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                _logger.Log.Error(ex, "{0}", ex.Message);
                throw;
            }
            catch (ObjectDisposedException ex)
            {
                _logger.Log.Error(ex, "{0}", ex.Message);
                throw;
            }
        }
        
        public void SetupScan(IFormatScan setupScan) => _setupScan = setupScan;
    }
}