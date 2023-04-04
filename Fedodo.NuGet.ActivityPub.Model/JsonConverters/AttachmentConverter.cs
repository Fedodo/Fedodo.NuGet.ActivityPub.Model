// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Fedodo.NuGet.ActivityPub.Model.Properties;
//
// namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;
//
// public class AttachmentConverter : JsonConverter<IEnumerable<Attachment>>
// {
//     public override IEnumerable<Attachment>? Read(ref Utf8JsonReader reader, Type typeToConvert,
//         JsonSerializerOptions options)
//     {
//         List<Attachment> attachments = new();
//
//         if (typeToConvert == typeof(string))
//         {
//             while (reader.Read())
//             {
//                 var json = reader.GetString();
//
//                 Uri? uri = null;
//                 if (Uri.TryCreate(json, new UriCreationOptions(), out uri))
//                 {
//                     
//                 }
//                 else
//                 {
//                     // TODO Throw Exception
//                 }
//             }
//         }
//         else if (typeToConvert == typeof(IEnumerable<Attachment>))
//         {
//             attachments.AddRange(JsonSerializer.Deserialize<List<Attachment>>(reader: ref reader));
//         }
//
//
//         return attachments;
//     }
//
//     public override void Write(Utf8JsonWriter writer, IEnumerable<Attachment> value, JsonSerializerOptions options)
//     {
//         throw new NotImplementedException();
//
//         writer.WriteStartArray();
//
//         foreach (var item in value)
//         {
//             writer.WriteStartObject();
//             writer.WriteString("type", item.Type);
//             writer.WriteString("content", item.Content);
//             writer.WriteString("url", item.Url.ToString());
//             writer.WriteEndObject();
//         }
//
//         writer.WriteEndArray();
//     }
// }