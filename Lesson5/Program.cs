using ManagerScannerLibrary;
using ScannerLibrary;
using Autofac;
using ManagerScannerLibrary.Interfaces;
using ScannerLibrary.Interfaces;

var builder = new ContainerBuilder();
builder.RegisterType<ScannerService>().As<IScannerService>().SingleInstance();
builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
var container = builder.Build();

var manager = new ManagerScannerService(container.Resolve<IScannerService>(), container.Resolve<ILogger>())
{
    SourceFileName = "Text.txt",
    TargetFileName = "Result.txt"
};

manager.SetupScan(new TxtFormat());
await manager.RunScanner().ConfigureAwait(false);

Console.ReadLine();