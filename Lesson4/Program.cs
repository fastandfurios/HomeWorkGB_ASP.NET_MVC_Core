
using Lesson4;
using Lesson4.SubServices.DataAccessServices;
using Lesson4.SubServices.DataExtractionServices;

var accessDataSubService = ISingleton<AccessToWeatherDataService>.Instance;
var dataExtractionService = ISingleton<DataExtractionService>.Instance;

var currentWeatherService = new CurrentWeatherService(accessDataSubService!, dataExtractionService!);
currentWeatherService.Run();

Console.ReadLine();