using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has created the object.
/// </summary>
public class Create : Activity
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Create";
}