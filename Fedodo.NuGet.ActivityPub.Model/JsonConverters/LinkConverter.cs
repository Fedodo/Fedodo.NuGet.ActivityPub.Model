using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class LinkConverter : JsonConverter<CoreTypes.Link>
{
    public override CoreTypes.Link? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // TODO
        return new CoreTypes.Link();
    }

    public override void Write(Utf8JsonWriter writer, CoreTypes.Link value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}