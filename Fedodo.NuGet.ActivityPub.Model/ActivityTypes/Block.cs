using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor is blocking the object. Blocking is a stronger form of Ignore. The typical use is to
///     support social systems that allow one user to block activities or content of other users. The target and origin
///     typically have no defined meaning.
/// </summary>
public class Block<T> : Ignore<T> where T : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Block";
}