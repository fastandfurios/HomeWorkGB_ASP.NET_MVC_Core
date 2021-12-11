
using Lesson4;
using Lesson4.SubServices.DataAccessServices;

var accessSubService = ISingleton<AccessToWeatherDataService>.Instance;

var currentWeatherService = new CurrentWeatherService(accessSubService!);
currentWeatherService.Run();

Console.ReadLine();