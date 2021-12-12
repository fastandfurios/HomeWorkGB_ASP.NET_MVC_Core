using Lesson4.SubServices.DataAccessServices;
using Lesson4.SubServices.DataExtractionServices;

namespace Lesson4
{
    public class CurrentWeatherService
    {
        private readonly IAccessToWeatherDataService _accessService;
        private readonly IDataExtractionService _extractionService;

        public CurrentWeatherService(IAccessToWeatherDataService access, IDataExtractionService extractionService)
        {
            _accessService = access;
            _extractionService = extractionService;
        }

        public void Run() => RunServices().ConfigureAwait(false);

        private async Task RunServices()
        {
            _accessService.URL = new("https://www.gismeteo.ru/weather-cherepovets-4285/");
            var responce = await _accessService.GetResponse().ConfigureAwait(false);
            _extractionService.GetWeather(responce);
        }
    }
}
