using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using PortfolioWebsite.BlazorUI.Utils.Mappers;

namespace PortfolioWebsite.BlazorUI.Utils.Serializers.Json
{
    public class JsonDatetimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.ToDateTime() ?? default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToFormattedDate());
        }
    }

    public class JsonNullableDatetimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.ToDateTime() ?? default;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToFormattedDate());
        }
    }
}
