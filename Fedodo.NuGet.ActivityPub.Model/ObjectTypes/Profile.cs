using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
///     A Profile is a content object that describes another Object, typically used to describe Actor Type objects. The
///     describes property is used to reference the object being described by the profile.
/// </summary>
public class Profile : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Profile";

    [JsonPropertyName("describes")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Describes { get; set; }
}