using System.Text.Json;
using System.Text.Json.Serialization;
using CommonExtensions;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class LinkConverter : JsonConverter<Link>
{
    public override Link? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var link = new Link();

        switch (reader.TokenType)
        {
            case JsonTokenType.StartObject:
                link = JsonSerializer.Deserialize<Link>(ref reader, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                break;
            case JsonTokenType.String:
                link.Href = new Uri(reader.GetString()!);
                break;
        }

        return link;
    }

    public override void Write(Utf8JsonWriter writer, Link value, JsonSerializerOptions options)
    {
        if (value.Height.IsDefault() && value.Name.IsDefault() && value.Preview.IsDefault() &&
            value.MediaType.IsDefault() && value.NameMap.IsDefault() && value.Hreflang.IsDefault() &&
            value.Rel.IsDefault())
        {
            writer.WriteStringValue(value.Href?.ToString());
            return;
        }

        JsonSerializer.Serialize(writer, value, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }
}