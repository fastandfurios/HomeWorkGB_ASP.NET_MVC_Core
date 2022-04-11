namespace Lesson4.SubServices.DataExtractionServices
{
    public interface IDataExtractionService
    {
        Task<IEnumerable<string>> GetWeatherAsync(string html);
    }
}
