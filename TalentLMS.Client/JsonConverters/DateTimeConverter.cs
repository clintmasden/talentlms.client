using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TalentLMS.Client.JsonConverters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.TryParse(reader.GetString(), out var result) ? result : DateTime.MinValue;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}