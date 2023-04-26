using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
///     A Tombstone represents a content object that has been deleted. It can be used in Collections to signify that there
///     used to be an object at this position, but it has been deleted.
/// </summary>
public class Tombstone : Object
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Tombstone";
    [JsonPropertyName("deleted")] public DateTime? Deleted { get; set; }
    [JsonPropertyName("formerType")] public string? FormerType { get; set; }
}