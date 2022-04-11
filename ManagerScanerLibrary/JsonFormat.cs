using System.Text.Json;
using ManagerScannerLibrary.Interfaces;
using ScannerLibrary.Interfaces;

namespace ManagerScannerLibrary
{
    public sealed class JsonFormat : IFormatScan
    {
        public async Task ScanAndSave(IScannerService device, string sourceFileName, string targetFileName)
        {
            await using var fs = File.Create(sourceFileName);
            await JsonSerializer.SerializeAsync(fs, device.ScanAsync(targetFileName));
        }
    }
}
