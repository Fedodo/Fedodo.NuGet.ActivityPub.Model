using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     A specialization of Reject in which the rejection is considered tentative.
/// </summary>
public class TentativeReject<T> : Reject<T> where T : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "TentativeReject";
}