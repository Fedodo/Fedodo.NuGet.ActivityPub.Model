using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor dislikes the object.
/// </summary>
public class Dislike<T> : Activity<T> where T : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Dislike";
}