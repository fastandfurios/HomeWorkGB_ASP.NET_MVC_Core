using ScannerLibrary.Interfaces;

namespace ScannerLibrary
{
    public class ScannerService : IScannerService
    {
        public async Task<byte[]> ScanAsync(string fileName)
        {
            try
            {
                byte[] buffer;

                await using var fileStream = File.OpenRead(fileName);

                buffer = new byte[fileStream.Length];

                await fileStream.ReadAsync(buffer: buffer, offset: 0, count: (int)fileStream.Length)
                                .ConfigureAwait(false);
                return buffer;
            }
            catch (IOException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch (NotSupportedException)
            {
                throw;
            }
        }
    }
}