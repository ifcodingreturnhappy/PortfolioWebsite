using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PortfolioWebsite.BlazorUI.Utils.Serializers.Json
{
    public class JsonDatetimeConverter : JsonConverter<DateTime>
    {
        private readonly string _format = "dd/MM/yyyy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (DateTime.TryParseExact(reader.GetString(), _format, null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            throw new JsonException($"Unable to convert \"{reader.GetString()}\" to DateTime.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }

}
