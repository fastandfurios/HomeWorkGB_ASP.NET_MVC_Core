namespace ManagerScannerLibrary.Interfaces
{
    public interface ILogger
    {
        Serilog.ILogger Log { get; }
    }
}
