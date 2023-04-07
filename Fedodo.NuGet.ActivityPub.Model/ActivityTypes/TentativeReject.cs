using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     A specialization of Reject in which the rejection is considered tentative.
/// </summary>
public class TentativeReject : Reject
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "TentativeReject";
}