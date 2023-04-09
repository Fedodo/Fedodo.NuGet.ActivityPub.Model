using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has deleted the object. If specified, the origin indicates the context from which the
///     object was deleted.
/// </summary>
public class Delete<T> : Activity<T> where T : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Delete";
}