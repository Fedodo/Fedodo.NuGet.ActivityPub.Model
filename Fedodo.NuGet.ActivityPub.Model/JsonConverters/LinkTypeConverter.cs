using System.Text.Json;
using System.Text.Json.Serialization;
using CommonExtensions;
using Fedodo.NuGet.ActivityPub.Model.Helpers;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class LinkTypeConverter<T> : JsonConverter<T> where T : class
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var tempReader = reader;

        if (reader.TokenType != JsonTokenType.StartObject)
            throw new ArgumentException("The object parameter can only be an object");

        var tempObject = JsonSerializer.Deserialize<TypeHelper>(ref tempReader, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        if (tempObject.IsNull() || tempObject.Type.IsNull())
        {
            JsonSerializer.Deserialize<TypeHelper>(ref reader);
            return null;
        }

        var type = Type.GetType("Fedodo.NuGet.ActivityPub.Model.LinkTypes." + tempObject.Type);

        if (tempObject.Type == "Link") type = Type.GetType("Fedodo.NuGet.ActivityPub.Model.CoreTypes.Link");

        if (type.IsNull())
        {
            JsonSerializer.Deserialize<object>(ref reader);
            return null;
        }

        var realObject = (T)JsonSerializer.Deserialize(ref reader, type, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return realObject;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var type = value.GetType();
        
        JsonSerializer.Serialize(writer, value, type, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }
}