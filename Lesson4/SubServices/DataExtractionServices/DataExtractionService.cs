using AngleSharp.Html.Parser;
using HtmlAgilityPack;

namespace Lesson4.SubServices.DataExtractionServices
{
    public sealed class DataExtractionService : IDataExtractionService
    {
        private readonly HtmlDocument _document = new();

        public IEnumerable<string> GetWeather(string html)
        {
            _document.LoadHtml(html);
            
            return _document.DocumentNode.SelectNodes("//span[contains(@class, 'unit unit_temperature_c')]")
                                         .Select(s => s.InnerText.Replace("&minus;", "-"));
        }
    }
}
