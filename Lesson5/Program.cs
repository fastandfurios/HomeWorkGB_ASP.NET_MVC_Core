using ScannerLibrary;

var scanner = new ScannerService();
await scanner.ScanAsync("Text.txt");

Console.ReadLine();