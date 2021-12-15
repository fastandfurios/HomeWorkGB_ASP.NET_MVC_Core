using ManagerScannerLibrary.Interfaces;

namespace ManagerScannerLibrary
{
    public class ManagerScannerService : IManagerScannerService
    {
        public Task<bool> SaveToJson(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveToTxt(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveToXml(byte[] buffer)
        {
            throw new NotImplementedException();
        }
    }
}