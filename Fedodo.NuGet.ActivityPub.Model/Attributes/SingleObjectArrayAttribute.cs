using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;

namespace Fedodo.NuGet.ActivityPub.Model.Attributes;

public class SingleObjectArrayAttribute : JsonConverterAttribute
{
    public override JsonConverter CreateConverter(Type typeToConvert)
    {
        return new TripleSetConverter<CoreTypes.Object>(true);
    }
}