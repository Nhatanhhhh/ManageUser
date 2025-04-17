using System.Text.Json;
using System.Text.Json.Serialization;

namespace ManagerUser.Utils;

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var dateTimeString = reader.GetString();
        if (string.IsNullOrEmpty(dateTimeString))
        {
            throw new JsonException("The date time string is null or empty.");
        }
        return DateTime.Parse(dateTimeString);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));
    }
}

internal class JsonDateTimeConverter : JsonConverter<DateTime>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(DateTime) || typeToConvert == typeof(DateTime?);
    }

    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var dateTimeString = reader.GetString();
        if (string.IsNullOrEmpty(dateTimeString))
        {
            throw new JsonException("The date time string is null or empty.");
        }
        return DateTime.Parse(dateTimeString);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));
    }
}
