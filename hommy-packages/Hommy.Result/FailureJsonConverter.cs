using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hommy.ResultModel
{
    public class FailureJsonConverter : JsonConverter<Failure>
    {
        public override Failure Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Failure value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}