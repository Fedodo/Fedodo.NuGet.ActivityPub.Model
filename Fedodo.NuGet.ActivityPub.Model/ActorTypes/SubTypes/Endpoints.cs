using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes.SubTypes;

public class Endpoints
{
    [JsonPropertyName("sharedInbox")] public Uri? SharedInbox { get; set; }
}