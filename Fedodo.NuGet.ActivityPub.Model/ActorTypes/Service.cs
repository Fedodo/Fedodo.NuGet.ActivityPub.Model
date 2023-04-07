using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes;

public class Service : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Service";
}