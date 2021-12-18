using ScannerLibrary.Interfaces;

namespace ManagerScannerLibrary.Interfaces
{
    public interface IFormatScan
    {
        Task ScanAndSave(IScannerService device, string sourceFileName, string targetFileName);
    }
}
