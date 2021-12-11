using Lesson4.SubServices.DataAccessServices;

namespace Lesson4
{
    public class CurrentWeatherService
    {
        private readonly IAccessToWeatherDataService _access;

        public CurrentWeatherService(IAccessToWeatherDataService access)
        {
            _access = access;
        }

        public void Run() => RunServices().ConfigureAwait(false);

        private async Task RunServices()
        {
           _access.URL = new("https://www.gismeteo.ru/weather-cherepovets-4285/");
           var responce = await _access.GetResponse().ConfigureAwait(false);
        }
    }
}
