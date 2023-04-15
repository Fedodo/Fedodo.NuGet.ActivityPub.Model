using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.LinkTypes;

public class Hashtag : Link
{
    [JsonPropertyName("type")] public new string Type { get; set; } = "Hashtag";
}