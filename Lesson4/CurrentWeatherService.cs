using Lesson4.SubServices.DataAccessServices;
using Lesson4.SubServices.DataExtractionServices;

namespace Lesson4
{
    //Facade
    public class CurrentWeatherService
    {
        private readonly IAccessToWeatherDataService _accessService;
        private readonly IDataExtractionService _extractionService;

        public CurrentWeatherService(IAccessToWeatherDataService access, IDataExtractionService extractionService)
        {
            _accessService = access;
            _extractionService = extractionService;
        }

        public async Task<IEnumerable<string>> GetWeatherAsync()
        {
            _accessService.URL = new("https://www.gismeteo.ru/weather-cherepovets-4285/");
            var responce = await _accessService.GetResponseAsync().ConfigureAwait(false);
           return await _extractionService.GetWeatherAsync(responce).ConfigureAwait(false);
        }
    }
}
