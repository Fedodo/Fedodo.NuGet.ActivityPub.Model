using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     A specialization of Accept indicating that the acceptance is tentative.
/// </summary>
public class TentativeAccept<T> : Accept<T> where T : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "TentativeAccept";
}