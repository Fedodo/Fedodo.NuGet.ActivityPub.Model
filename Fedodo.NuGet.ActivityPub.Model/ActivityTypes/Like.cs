using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor likes, recommends or endorses the object. The target and origin typically have no defined
///     meaning.
/// </summary>
public class Like<T> : Activity<T> where T : CoreTypes.Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Like";
}