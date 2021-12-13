
using Lesson4;
using Lesson4.SubServices.DataAccessServices;
using Lesson4.SubServices.DataExtractionServices;

var accessDataSubService = ISingleton<AccessToWeatherDataService>.Instance;
var dataExtractionService = ISingleton<DataExtractionService>.Instance;

var currentWeatherService = new CurrentWeatherService(accessDataSubService!, dataExtractionService!);
var weather = await currentWeatherService.GetWeatherAsync();

int[] times = {0, 3, 6, 9, 12, 15, 18, 21};

Console.WriteLine($"Погода в Череповце на {DateTime.Now.Date:dd.MM.yyyy}\n");

foreach (var time in times)
{
    Console.Write("{0,5}°°", time);
}

Console.WriteLine();

foreach (var item in weather)
{
    Console.Write("{0,5}°C", item);
}

Console.ReadLine();