using PortfolioWebsite.BlazorUI.Abstractions;
using STJ = System.Text.Json;

namespace PortfolioWebsite.BlazorUI.Utils.Serializers.Json
{
    public class JsonSerializer : IJsonSerializer
    {
        private readonly STJ.JsonSerializerOptions options;

        public JsonSerializer()
        {
            this.options = new STJ.JsonSerializerOptions 
            {
                PropertyNameCaseInsensitive = true,
                Converters = { 
                    new JsonDatetimeConverter(),
                    new JsonNullableDatetimeConverter(),
                    new STJ.Serialization.JsonStringEnumConverter(),
                } 
            };
        }

        public string Serialize<T>(T obj)
        {
            return STJ.JsonSerializer.Serialize<T>(obj, this.options);
        }

        public T Deserialize<T>(string json)
        {
            return STJ.JsonSerializer.Deserialize<T>(json, this.options);
        }
    }
}
