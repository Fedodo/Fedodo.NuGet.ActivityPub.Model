using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     A specialization of Reject in which the rejection is considered tentative.
/// </summary>
public class TentativeReject : Reject
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "TentativeReject";
}