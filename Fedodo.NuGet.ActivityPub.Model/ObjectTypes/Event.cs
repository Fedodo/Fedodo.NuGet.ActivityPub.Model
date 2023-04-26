using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
///     Represents any kind of event.
/// </summary>
public class Event : Object
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Event";
}