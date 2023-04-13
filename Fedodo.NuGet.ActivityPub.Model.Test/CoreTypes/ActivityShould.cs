using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Fedodo.NuGet.ActivityPub.Model.ActivityTypes;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.ObjectTypes;
using Shouldly;
using Xunit;

namespace Fedodo.NuGet.ActivityPub.Model.Test.CoreTypes;

public class ActivityShould
{
    [Fact]
    public void DeserializeCreateActivity()
    {
        // Arrange
        var json = """
            {
              "id": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/activity",
              "type": "Create",
              "actor": "https://social.heise.de/users/heisedeveloper",
              "published": "2023-02-24T15:57:00Z",
              "to": [
                "https://www.w3.org/ns/activitystreams#Public"
              ],
              "cc": [
                "https://social.heise.de/users/heisedeveloper/followers"
              ],
              "object": {
                "id": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043",
                "type": "Note",
                "summary": null,
                "inReplyTo": null,
                "published": "2023-02-24T15:57:00Z",
                "url": "https://social.heise.de/@heisedeveloper/109920532625809043",
                "attributedTo": "https://social.heise.de/users/heisedeveloper",
                "to": [
                  "https://www.w3.org/ns/activitystreams#Public"
                ],
                "cc": [
                  "https://social.heise.de/users/heisedeveloper/followers"
                ],
                "sensitive": false,
                "atomUri": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043",
                "inReplyToAtomUri": null,
                "conversation": "tag:social.heise.de,2023-02-24:objectId=209050:objectType=Conversation",
                "content": "<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>",
                "contentMap": {
                  "de": "<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>"
                },
                "attachment": [
                  {
                    "type": "Document",
                    "mediaType": "image/jpeg",
                    "url": "https://social.heise.de/system/media_attachments/files/109/920/532/619/836/925/original/fb52dfc289817fa2.jpeg",
                    "name": null,
                    "blurhash": "UuGSjUtS0YIURRnNa*S#R7Rkk8x[t7j=WUfl",
                    "width": 600,
                    "height": 338
                  }
                ],
                "tag": [
                  {
                    "type": "Hashtag",
                    "href": "https://social.heise.de/tags/softwareentwicklung",
                    "name": "#softwareentwicklung"
                  },
                  {
                    "type": "Hashtag",
                    "href": "https://social.heise.de/tags/news",
                    "name": "#news"
                  }
                ],
                "replies": {
                  "id": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies",
                  "type": "Collection",
                  "first": {
                    "type": "CollectionPage",
                    "next": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies?only_other_accounts=true&page=true",
                    "partOf": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies",
                    "items": []
                  }
                }
              }
            }
        """;
        Note? note = null;
        Create? createActivity = null;
        Document? document = null;

        // Act
        var create = JsonSerializer.Deserialize<Activity>(json, options: new JsonSerializerOptions()
        {
          Converters =
          {
            new TypeConverter<Activity>()
          }
        });
        note = (Note?)create?.Object;
        createActivity = (Create)create!;
        document = (Document)create?.Object?.Attachment?.Objects?.First()!;

        // Assert
        create.ShouldNotBeNull();
        createActivity.ShouldNotBeNull();
        create.GetType().ShouldBe(typeof(Create));
        createActivity.Type.ShouldBe("Create");
        createActivity.Id.ShouldBe("https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/activity");
        createActivity.Actor?.StringLinks?.ShouldContain("https://social.heise.de/users/heisedeveloper");
        createActivity.Published.ShouldBe(DateTime.Parse("2023-02-24T15:57:00Z").ToUniversalTime());
        createActivity.To?.StringLinks?.ShouldContain("https://www.w3.org/ns/activitystreams#Public");
        createActivity.Cc?.StringLinks?.ShouldContain("https://social.heise.de/users/heisedeveloper/followers");
        createActivity.Object.ShouldBeOfType<Note>();
        createActivity.Object?.GetType().ShouldBe(typeof(Note));
        
        note.ShouldNotBeNull();
        note.Type.ShouldBe("Note");
        note.Id.ShouldBe("https://social.heise.de/users/heisedeveloper/statuses/109920532625809043");
        note.Published.ShouldBe(DateTime.Parse("2023-02-24T15:57:00Z").ToUniversalTime());
        note?.AttributedTo?.StringLinks?.ShouldContain("https://social.heise.de/users/heisedeveloper");
        note?.To?.StringLinks?.ShouldContain("https://www.w3.org/ns/activitystreams#Public");
        note?.Cc?.StringLinks?.ShouldContain("https://social.heise.de/users/heisedeveloper/followers");
        note?.Sensitive.ShouldBe(false);
        note?.Content.ShouldBe("<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>");
        note?.ContentMap?.ShouldContainKeyAndValue("de", "<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>");
        note?.Attachment?.Objects?.First().ShouldBeOfType<Document>();
        note?.Url?.Href.ShouldBe(new Uri("https://social.heise.de/@heisedeveloper/109920532625809043"));

        document.Type.ShouldBe("Document");
        document?.Url?.Href.ShouldBe(new Uri("https://social.heise.de/system/media_attachments/files/109/920/532/619/836/925/original/fb52dfc289817fa2.jpeg"));
        document?.MediaType.ShouldBe("image/jpeg");
    }
}