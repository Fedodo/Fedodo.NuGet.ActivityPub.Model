using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.ObjectTypes;

/// <summary>
///     Represents a Web Page.
/// </summary>
public class Page : Document
{
    [JsonPropertyName("type")] public override string Type { get; set; } = "Page";
}