namespace ManagerScannerLibrary.Interfaces
{
    public interface IManagerScannerService
    {
        Task<bool> SaveToJson(byte[] buffer);
        Task<bool> SaveToTxt(byte[] buffer);
        Task<bool> SaveToXml(byte[] buffer);
    }
}
