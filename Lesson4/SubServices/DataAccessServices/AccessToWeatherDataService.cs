namespace Lesson4.SubServices.DataAccessServices
{
    public sealed class AccessToWeatherDataService : IAccessToWeatherDataService
    {
        private static readonly HttpClient _httpClient = new();
        private Uri? _url;

        public Uri URL { get => _url!; set => _url = value; }

        public async Task<string> GetResponse()
        {
            try
            {
                return await _httpClient.GetStringAsync(_url).ConfigureAwait(false);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (TaskCanceledException)
            {
                throw;
            }
        }
    }
}
