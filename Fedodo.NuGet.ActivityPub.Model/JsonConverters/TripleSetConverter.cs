using System.Text.Json;
using System.Text.Json.Serialization;
using CommonExtensions;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class TripleSetConverter<T> : JsonConverter<TripleSet<T>> where T : class
{
    private readonly bool _singleChildArray = false;

    public TripleSetConverter(bool singleChildArray)
    {
        _singleChildArray = singleChildArray;
    }

    public TripleSetConverter()
    {
    }

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
        if (value.IsNull()) return;

        if (_singleChildArray == false)
        {
            // Only write one object if the count is 1 and not an array
            if (value.StringLinks.IsNullOrEmpty() && value.Links.IsNullOrEmpty() && value.Objects?.Count() == 1)
            {
                JsonSerializer.Serialize(writer, value.Objects.First(), new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
                return;
            }

            if (value.StringLinks.IsNullOrEmpty() && value.Objects.IsNullOrEmpty() && value.Links?.Count() == 1)
            {
                JsonSerializer.Serialize(writer, value.Links.First(), new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
                return;
            }

            if (value.Objects.IsNullOrEmpty() && value.Links.IsNullOrEmpty() && value.StringLinks?.Count() == 1)
            {
                writer.WriteStringValue(value.StringLinks.First());
                return;
            }
        }

        writer.WriteStartArray();

        if (value.Objects.IsNotNullOrEmpty())
            foreach (var item in value.Objects)
            {
                var type = item.GetType();

                JsonSerializer.Serialize(writer, item, type, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
            }

        if (value.StringLinks.IsNotNullOrEmpty())
            foreach (var item in value.StringLinks)
                writer.WriteStringValue(item);

        if (value.Links.IsNotNullOrEmpty())
            foreach (var item in value.Links)
            {
                var type = item.GetType();
                
                JsonSerializer.Serialize(writer, item, type, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                });
            }


        writer.WriteEndArray();
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

        var templink = JsonSerializer.Deserialize<Link>(ref tempReader, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new LinkTypeConverter<Link>()
            }
        });

        if (templink.IsNull())
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
            var link = JsonSerializer.Deserialize<Link>(ref reader, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new LinkTypeConverter<Link>()
                }
            })!;
            
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