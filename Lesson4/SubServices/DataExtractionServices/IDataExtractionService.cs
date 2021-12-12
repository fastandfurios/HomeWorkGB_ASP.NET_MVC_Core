namespace Lesson4.SubServices.DataExtractionServices
{
    public interface IDataExtractionService
    {
        IEnumerable<string> GetWeather(string html);
    }
}
