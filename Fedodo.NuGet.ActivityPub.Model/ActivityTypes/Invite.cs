using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     A specialization of Offer in which the actor is extending an invitation for the object to the target.
/// </summary>
public class Invite : Offer
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Invite";
}