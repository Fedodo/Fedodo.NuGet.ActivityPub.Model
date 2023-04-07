using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
///     Represents a Web Page.
/// </summary>
public class Page : Document
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Page";
}