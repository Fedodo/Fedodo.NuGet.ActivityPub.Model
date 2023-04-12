using System.Text.Json;
using System.Text.Json.Serialization;
using CommonExtensions;
using Fedodo.NuGet.ActivityPub.Model.ObjectTypes;
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

        // if (tempObject.IsNotNull() && tempObject.Type.IsNotNullOrEmpty())
        // {
        //     var T = Type.GetType("Fedodo.NuGet.ActivityPub.Model.ObjectTypes." + tempObject.Type);
        //     var realObject = JsonSerializer.Deserialize<T>(ref reader);
        //
        //     return realObject;
        // }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, Object value, JsonSerializerOptions options)
    {
        //TODO
        throw new NotImplementedException();
    }
}