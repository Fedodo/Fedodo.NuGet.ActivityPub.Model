using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor is "following" the object. Following is defined in the sense typically used within Social
///     systems in which the actor is interested in any activity performed by or on the object. The target and origin
///     typically have no defined meaning.
/// </summary>
public class Follow<T> : Activity<T> where T : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Follow";
}