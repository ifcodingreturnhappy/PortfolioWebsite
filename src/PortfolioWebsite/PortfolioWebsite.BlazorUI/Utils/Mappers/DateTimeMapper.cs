using System;
using System.Text.Json;

namespace PortfolioWebsite.BlazorUI.Utils.Mappers
{
    public static class DateTimeMapper
    {
        public const string DateFormat = "dd/MM/yyyy";

        public static string ToFormattedDate(this DateTime dateTime)
        {
            return dateTime.ToString(DateFormat);
        }

        public static DateTime? ToDateTime(this Utf8JsonReader reader)
        {
            if (DateTime.TryParseExact(reader.GetString(), DateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                return date;
            }

            return default;
        }
    }
}
