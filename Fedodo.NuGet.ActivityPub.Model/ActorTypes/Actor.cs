using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.ActorTypes.SubTypes;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActorTypes;

/// <summary>
///     This is the base type for all Actors.
/// </summary>
public class Actor : Object
{
    /// <summary>
    /// Identifies the Object or Link type.
    /// </summary>
    /// <example>Actor</example>
    [JsonPropertyName("type")] public override string Type { get; set; } = "Actor";

    /// <summary>
    /// The real username displayed together with the domain name. This would look like "Jane@example.com".
    /// </summary>
    /// <example>Jane</example>
    [JsonPropertyName("preferredUsername")]
    public string? PreferredUsername { get; set; }

    [JsonPropertyName("inbox")] public Uri? Inbox { get; set; }
    [JsonPropertyName("outbox")] public Uri? Outbox { get; set; }
    [JsonPropertyName("followers")] public Uri? Followers { get; set; }
    [JsonPropertyName("following")] public Uri? Following { get; set; }
    [JsonPropertyName("publicKey")] public PublicKey? PublicKey { get; set; }
    [JsonPropertyName("endpoints")] public Endpoints? Endpoints { get; set; }
}