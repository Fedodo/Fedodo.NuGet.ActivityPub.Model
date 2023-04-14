using System.Text.Json.Serialization;

namespace Fedodo.NuGet.ActivityPub.Model.Interfaces;

public interface IType
{
    [JsonPropertyName("type")] public string Type { get; set; }
}