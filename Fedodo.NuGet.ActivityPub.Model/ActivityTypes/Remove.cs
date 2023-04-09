using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor is removing the object. If specified, the origin indicates the context from which the
///     object is being removed.
/// </summary>
public class Remove<T> : Activity<T> where T : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Remove";
}