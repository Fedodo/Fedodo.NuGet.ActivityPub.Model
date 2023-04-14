using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.Interfaces;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
///     A Link is an indirect, qualified reference to a resource identified by a URL. The fundamental model for links is
///     established by [ RFC5988]. Many of the properties defined by the Activity Vocabulary allow values that are either
///     instances of Object or Link. When a Link is used, it establishes a qualified relation connecting the subject (the
///     containing object) to the resource identified by the href. Properties of the Link are properties of the reference
///     as opposed to properties of the resource.
/// </summary>
public class Link : IType
{
    [JsonPropertyName("type")] public string Type { get; set; } = "Link";
    [JsonPropertyName("href")] public Uri? Href { get; set; }

    [JsonPropertyName("rel")]
    public object Rel { get; set; } // TODO Link Relation https://www.w3.org/TR/activitystreams-vocabulary/#dfn-rel

    [JsonPropertyName("mediaType")] public string? MediaType { get; set; } // Must be a MIME Media Type
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("nameMap")] public Dictionary<string, string>? NameMap { get; set; }
    [JsonPropertyName("hreflang")] public string Hreflang { get; set; } // [BCP47] Language Tag
    [JsonPropertyName("height")] public int Height { get; set; }
    [JsonPropertyName("width")] public int Width { get; set; }

    [JsonPropertyName("preview")]
    [JsonConverter(typeof(TripleSetConverter<Object>))]
    public TripleSet<Object>? Preview { get; set; }
}