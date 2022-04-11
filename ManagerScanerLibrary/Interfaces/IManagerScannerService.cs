using ScannerLibrary.Interfaces;

namespace ManagerScannerLibrary.Interfaces
{
    public interface IManagerScannerService
    {
        string SourceFileName { get; set; }
        string TargetFileName { get; set; }
        Task RunScanner();
        void SetupScan(IFormatScan setupScan);
    }
}
