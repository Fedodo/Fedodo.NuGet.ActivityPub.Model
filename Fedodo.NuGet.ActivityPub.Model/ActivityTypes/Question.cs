using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
/// Represents a question being asked. Question objects are an extension of IntransitiveActivity. That is, the Question object is an Activity, but the direct object is the question itself and therefore it would not contain an object property.
/// Either of the anyOf and oneOf properties may be used to express possible answers, but a Question object must not have both properties.
/// </summary>
public class Question : IntransitiveActivity
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Question";

    public TripleSet<Object>? OneOf { get; set; }
    public TripleSet<Object>? AnyOf { get; set; }
    public TripleSet<Object>? Closed { get; set; } // TODO This also might be a bool or a datetime
    
}