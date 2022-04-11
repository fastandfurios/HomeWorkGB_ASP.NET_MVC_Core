namespace Lesson4.SubServices.DataAccessServices
{
    public interface IAccessToWeatherDataService
    {
        Uri URL { get; set; }
        Task<string> GetResponseAsync();
    }
}
