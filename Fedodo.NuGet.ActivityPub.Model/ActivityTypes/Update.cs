using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has updated the object. Note, however, that this vocabulary does not define a mechanism
///     for describing the actual set of modifications made to object.
///     The target and origin typically have no defined meaning.
/// </summary>
public class Update : Activity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Update";
}