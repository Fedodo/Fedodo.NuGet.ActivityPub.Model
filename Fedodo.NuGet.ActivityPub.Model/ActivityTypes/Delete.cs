using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has deleted the object. If specified, the origin indicates the context from which the
///     object was deleted.
/// </summary>
public class Delete : Activity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Delete";
}