using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     A specialization of Offer in which the actor is extending an invitation for the object to the target.
/// </summary>
public class Invite<T> : Offer<T> where T : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Invite";
}