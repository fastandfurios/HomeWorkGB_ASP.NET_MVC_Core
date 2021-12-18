using System.Xml.Serialization;
using ManagerScannerLibrary.Interfaces;
using ScannerLibrary.Interfaces;

namespace ManagerScannerLibrary
{
    public class XmlFormat : IFormatScan
    {
        public async Task ScanAndSave(IScannerService device, string sourceFileName, string targetFileName)
        {
            await Task.Run(async () =>
            {
                await using var fs = File.Create(targetFileName);
                var xmlSerializer = new XmlSerializer(typeof(byte[]));
                var buffer = await device.ScanAsync(sourceFileName);
                xmlSerializer.Serialize(fs, buffer);
            });
        }
    }
}
