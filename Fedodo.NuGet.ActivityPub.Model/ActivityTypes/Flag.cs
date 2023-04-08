using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor is "flagging" the object. Flagging is defined in the sense common to many social platforms
///     as reporting content as being inappropriate for any number of reasons.
/// </summary>
public class Flag<T> : Activity<T> where T : CoreTypes.Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Flag";
}