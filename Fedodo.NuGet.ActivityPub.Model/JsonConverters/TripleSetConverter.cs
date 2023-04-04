using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using CommonExtensions;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class TripleSetConverter : JsonConverter<TripleSet>
{
    public override TripleSet? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        TripleSet tripleSet = new();

        var tokenType = reader.TokenType;

        switch (tokenType)
        {
            case JsonTokenType.StartObject:
            {
                var apObject = JsonSerializer.Deserialize<Object>(reader: ref reader);

                if (apObject.IsNotNull())
                {
                    tripleSet.Objects = new[]
                    {
                        apObject
                    };
                }
                
                break;
            }
            case JsonTokenType.StartArray:
                break;
            case JsonTokenType.String:
            {
                var stringLink = reader.GetString();

                if (stringLink.IsNotNull())
                {
                    tripleSet.StringLinks = new[]
                    {
                        stringLink
                    };
                }

                break;
            }
        }

        return tripleSet;
    }

    public override void Write(Utf8JsonWriter writer, TripleSet value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();

        // writer.WriteStartArray();
        //
        // foreach (var item in value)
        // {
        //     writer.WriteStartObject();
        //     writer.WriteString("type", item.Type);
        //     writer.WriteString("content", item.Content);
        //     writer.WriteString("url", item.Url.ToString());
        //     writer.WriteEndObject();
        // }
        //
        // writer.WriteEndArray();
    }
}