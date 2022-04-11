using ScannerLibrary.Interfaces;

namespace ScannerLibrary
{
    public sealed class ScannerService : IScannerService
    {
        public async Task<byte[]> ScanAsync(string fileName)
        {
            try
            {
                await using var fileStream = File.OpenRead(fileName);

                var buffer = new byte[fileStream.Length];

                await fileStream.ReadAsync(buffer: buffer, offset: 0, count: (int)fileStream.Length)
                                .ConfigureAwait(false);

                await Task.Delay(5000);

                return buffer;
            }
            finally{}
        }
    }
}