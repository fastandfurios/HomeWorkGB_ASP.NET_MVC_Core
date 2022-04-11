namespace ScannerLibrary.Interfaces
{
    public interface IScannerService
    {
        Task<byte[]> ScanAsync(string fileName);
    }
}
