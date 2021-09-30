using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hommy.ResultModel
{
    public class ResultJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
            => typeToConvert.IsGenericType
            && typeToConvert.GetGenericTypeDefinition() == typeof(Result<>);

        public override JsonConverter CreateConverter(
            Type typeToConvert, JsonSerializerOptions options)
        {
            var keyType = typeToConvert.GenericTypeArguments[0];
            var converterType = typeof(ResultJsonConverter<>).MakeGenericType(keyType);

            return (JsonConverter)Activator.CreateInstance(converterType);
        }
    }

    public class ResultJsonConverter<T> : JsonConverter<Result<T>>
    {
        public override Result<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (JsonDocument.TryParseValue(ref reader, out var doc))
            {
                if (doc.RootElement.TryGetProperty("isSuccess", out var isSuccessProperty))
                {
                    var isSuccess = isSuccessProperty.GetBoolean();
                    
                    if (isSuccess)
                    {
                        var dataElement = doc.RootElement.GetProperty("data").GetRawText();

                        return JsonSerializer.Deserialize<T>(dataElement, options);
                    } 
                    else
                    {
                        var failureElement = doc.RootElement.GetProperty("failure").GetRawText();

                        var failure = JsonSerializer.Deserialize<Failure>(failureElement, options);

                        return Result.Fail(failure);
                    }
                }                
            }

            throw new JsonException("Failed to parse");
        }

        public override void Write(Utf8JsonWriter writer, Result<T> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
