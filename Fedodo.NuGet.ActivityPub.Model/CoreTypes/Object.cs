using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.Properties;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
/// Describes an object of any kind. The Object type serves as the base type for most of the other kinds of objects defined in the Activity Vocabulary, including other Core types such as Activity, IntransitiveActivity, Collection and OrderedCollection.
/// </summary>
public class Object
{
    [JsonPropertyName("attachment")] public IEnumerable<Attachment>? Attachment { get; set; }
    [JsonPropertyName("attributedTo")] public IEnumerable<Uri>? AttributedTo { get; set; } // TODO This also might be of type AttributedTo
}