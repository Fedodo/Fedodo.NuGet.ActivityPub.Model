using System.Text.Json;
using System.Text.Json.Serialization;
using CommonExtensions;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class TripleSetConverter<T> : JsonConverter<TripleSet<T>> where T : class
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
                    tripleSet = reader.TokenType switch
                    {
                        JsonTokenType.StartObject => GetObject(ref reader, tripleSet),
                        JsonTokenType.String => GetString(reader, tripleSet),
                        _ => tripleSet
                    };

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
        
        // TODO

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
    ///     Uses the default JsonSerializer to deserialize an Object.
    /// </summary>
    /// <param name="reader">The JSON Reader.</param>
    /// <param name="tripleSet">The TripleSet in which the String should be added.</param>
    /// <returns>Triple Set</returns>
    private TripleSet<T> GetObject(ref Utf8JsonReader reader, TripleSet<T> tripleSet)
    {
        var tempReader = reader;

        var link = JsonSerializer.Deserialize<Link>(ref tempReader, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new LinkTypeConverter<Link>()
            }
        });

        if (link.IsNull())
        {
            var apObject = JsonSerializer.Deserialize<T>(ref reader, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new ObjectTypeConverter<T>()
                }
            });

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
                var objectList = tripleSet.Objects.ToList();
                objectList.Add(apObject);
                tripleSet.Objects = objectList;
            }
        }
        else
        {
            if (tripleSet.Links.IsNull())
            {
                tripleSet.Links = new[]
                {
                    link
                };
            }
            else
            {
                var linkList = tripleSet.Links.ToList();
                linkList.Add(link);
                tripleSet.Links = linkList;
            }
        }

        return tripleSet;
    }

    /// <summary>
    ///     Uses the default JsonSerializer to deserialize an String.
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
            var stringLinks = tripleSet.StringLinks.ToList();
            stringLinks.Add(stringLink);
            tripleSet.StringLinks = stringLinks;
        }

        return tripleSet;
    }
}