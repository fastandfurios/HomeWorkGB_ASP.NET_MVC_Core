using HtmlAgilityPack;

namespace Lesson4.SubServices.DataExtractionServices
{
    //Adapter
    public sealed class DataExtractionService : IDataExtractionService
    {
        private readonly HtmlDocument _document = new();

        /// <summary> Возвращает диапазон температуры от 00:00 часов до 21:00 часа с шагом в 03:00 часа из html содержимого </summary>
        /// <param name="html">строка с html содержимым</param>
        /// <returns>диапазон температур</returns>
        public async Task<IEnumerable<string>> GetWeatherAsync(string html)
        {
            try
            {
                return await Task.Run(() =>
                {
                    _document.LoadHtml(html);

                    return _document.DocumentNode.SelectNodes("//span[contains(@class, 'unit unit_temperature_c')]")
                        .Select(s => s.InnerText.Replace("&minus;", "-"))
                        .Skip(6);
                });
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }
    }
}
