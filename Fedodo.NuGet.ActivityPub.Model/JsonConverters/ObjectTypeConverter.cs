using System.Text.Json;
using System.Text.Json.Serialization;
using CommonExtensions;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class ObjectTypeConverter<T> : JsonConverter<T> where T : class
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var tempReader = reader;

        if (reader.TokenType != JsonTokenType.StartObject)
            throw new ArgumentException("The object parameter can only be an object");

        var tempObject = JsonSerializer.Deserialize<Object>(ref tempReader, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (!tempObject.IsNotNull() || !tempObject.Type.IsNotNullOrEmpty()) return null;

        var type = Type.GetType("Fedodo.NuGet.ActivityPub.Model.ObjectTypes." + tempObject.Type) ??
                   Type.GetType("Fedodo.NuGet.ActivityPub.Model.ActivityTypes." + tempObject.Type) ??
                   Type.GetType("Fedodo.NuGet.ActivityPub.Model.ActorTypes." + tempObject.Type);

        if (type.IsNull())
            return JsonSerializer.Deserialize<T>(ref reader, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        var realObject = (T)JsonSerializer.Deserialize(ref reader, type, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return realObject;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
    }
}