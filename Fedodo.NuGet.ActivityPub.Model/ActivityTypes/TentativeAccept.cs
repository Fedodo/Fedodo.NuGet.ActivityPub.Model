using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     A specialization of Accept indicating that the acceptance is tentative.
/// </summary>
public class TentativeAccept : Accept
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "TentativeAccept";
}