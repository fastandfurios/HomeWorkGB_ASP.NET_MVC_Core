using ManagerScannerLibrary;
using ScannerLibrary;

var scanner = new ScannerService();

var manager = new ManagerScannerService(scanner)
{
    SourceFileName = "Text.txt",
    TargetFileName = "Result.txt"
};
manager.SetupScan(new TxtFormat());
await manager.RunScanner().ConfigureAwait(false);

Console.ReadLine();