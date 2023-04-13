using System.Text.Json;
using System.Text.Json.Serialization;
using CommonExtensions;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class ObjectTypeConverter : JsonConverter<CoreTypes.Object>
{
    public override Object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var tempReader = reader;
        
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new ArgumentException("The object parameter can only be an object");
        }

        var tempObject = JsonSerializer.Deserialize<Object>(ref tempReader);

        if (!tempObject.IsNotNull() || !tempObject.Type.IsNotNullOrEmpty()) return null;
        
        var T = Type.GetType("Fedodo.NuGet.ActivityPub.Model.ObjectTypes." + tempObject.Type);
        var realObject = JsonSerializer.Deserialize(ref reader, T) as Object;
        
        return realObject;
    }

    public override void Write(Utf8JsonWriter writer, Object value, JsonSerializerOptions options)
    {
        //TODO
        throw new NotImplementedException();
    }
}