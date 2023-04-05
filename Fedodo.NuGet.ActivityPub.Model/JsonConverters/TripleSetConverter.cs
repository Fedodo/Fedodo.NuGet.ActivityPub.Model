using System.Text.Json;
using System.Text.Json.Serialization;
using CommonExtensions;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class TripleSetConverter<T> : JsonConverter<TripleSet<T>>
{
    public override TripleSet<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        TripleSet<T> tripleSet = new();

        var tokenType = reader.TokenType;

        switch (tokenType)
        {
            case JsonTokenType.StartObject:
            {
                tripleSet = GetObject(ref reader, tripleSet);

                break;
            }
            case JsonTokenType.StartArray:
            {
                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    tripleSet = reader.TokenType switch
                    {
                        JsonTokenType.StartObject => GetObject(ref reader, tripleSet),
                        JsonTokenType.String => GetString(reader, tripleSet),
                        _ => tripleSet
                    };
                }
                
                break;
            }
            case JsonTokenType.String:
            {
                tripleSet = GetString(reader, tripleSet);

                break;
            }
        }

        return tripleSet;
    }

    public override void Write(Utf8JsonWriter writer, TripleSet<T> value, JsonSerializerOptions options)
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
    
    /// <summary>
    /// Uses the default JsonSerializer to deserialize an Object.
    /// </summary>
    /// <param name="reader">The JSON Reader.</param>
    /// <param name="tripleSet">The TripleSet in which the String should be added.</param>
    /// <returns>Triple Set</returns>
    private TripleSet<T> GetObject(ref Utf8JsonReader reader, TripleSet<T> tripleSet)
    {
        var apObject = JsonSerializer.Deserialize<T>(reader: ref reader);

        if (apObject.IsNull()) return tripleSet;
        
        if (tripleSet.Objects.IsNull())
        {
            tripleSet.Objects = new[]
            {
                apObject
            };
        }
        else
        {
            tripleSet.Objects.ToList().Add(apObject);
        }

        return tripleSet;
    }

    /// <summary>
    /// Uses the default JsonSerializer to deserialize an String.
    /// </summary>
    /// <param name="reader">The JSON Reader.</param>
    /// <param name="tripleSet">The TripleSet in which the String should be added.</param>
    /// <returns>TripleSet</returns>
    private TripleSet<T> GetString(Utf8JsonReader reader, TripleSet<T> tripleSet)
    {
        var stringLink = reader.GetString();

        if (stringLink.IsNull()) return tripleSet;
        
        if (tripleSet.StringLinks.IsNull())
        {
            tripleSet.StringLinks = new[]
            {
                stringLink
            };
        }
        else
        {
            tripleSet.StringLinks.ToList().Add(stringLink);
        }

        return tripleSet;
    }

}