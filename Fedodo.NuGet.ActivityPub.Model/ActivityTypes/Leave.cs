using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has left the object. The target and origin typically have no meaning.
/// </summary>
public class Leave<T> : Activity<T> where T : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Leave";
}