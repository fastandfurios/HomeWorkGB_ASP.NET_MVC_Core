using ManagerScannerLibrary.Interfaces;
using ScannerLibrary.Interfaces;

namespace ManagerScannerLibrary
{
    public class TxtFormat : IFormatScan
    {
        public async Task ScanAndSave(IScannerService device, string sourceFileName, string targetFileName)
        {
            await using var fs = File.Create(targetFileName);
            var buffer = await device.ScanAsync(sourceFileName);
            await fs.WriteAsync(buffer);
        }
    }
}
