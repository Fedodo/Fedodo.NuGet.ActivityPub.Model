using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     A specialization of Accept indicating that the acceptance is tentative.
/// </summary>
public class TentativeAccept<T> : Accept<T> where T : CoreTypes.Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "TentativeAccept";
}