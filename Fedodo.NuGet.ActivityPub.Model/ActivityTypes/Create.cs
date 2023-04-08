using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.ActivityTypes;

/// <summary>
///     Indicates that the actor has created the object.
/// </summary>
public class Create<T> : Activity<T> where T : CoreTypes.Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Create";
}