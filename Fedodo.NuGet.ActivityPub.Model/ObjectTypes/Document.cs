using System.Text.Json.Serialization;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
/// Represents a document of any kind.
/// </summary>
public class Document : Object
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Document";
}