using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
/// Indicates that the actor is traveling to target from origin. Travel is an IntransitiveObject whose actor specifies the direct object. If the target or origin are not specified, either can be determined by context.
/// </summary>
public class Travel : IntransitiveActivity
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Travel";

}