namespace BookShop.DataProcessor.ImportDto
{
    using Newtonsoft.Json;

    public class ImportBookIdDTO
    {
        [JsonProperty("Id")]
        public int? BookId { get; set; }
    }
}
