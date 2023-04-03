using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.Properties;

namespace Fedodo.NuGet.ActivityPub.Model.CoreTypes;

/// <summary>
/// Describes an object of any kind. The Object type serves as the base type for most of the other kinds of objects defined in the Activity Vocabulary, including other Core types such as Activity, IntransitiveActivity, Collection and OrderedCollection.
/// </summary>
public class Object
{
    // TODO Maybe I can use custom converters with the specific attribute to see if an object is an link or an real object.
    
    [JsonPropertyName("attachment")] 
    [JsonConverter(typeof(AttachmentConverter))]
    public IEnumerable<Attachment>? Attachment { get; set; }
    [JsonPropertyName("attributedTo")] public IEnumerable<Uri>? AttributedTo { get; set; } // TODO This also might be of type AttributedTo
}