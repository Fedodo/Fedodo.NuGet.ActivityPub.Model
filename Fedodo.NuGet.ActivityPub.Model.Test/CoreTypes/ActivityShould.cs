using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.JsonDiffPatch.Xunit;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.ActivityTypes;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.LinkTypes;
using Fedodo.NuGet.ActivityPub.Model.ObjectTypes;
using Shouldly;
using Xunit;

namespace Fedodo.NuGet.ActivityPub.Model.Test.CoreTypes;

public class ActivityShould
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void DeserializeCreateActivity(int jsonCount)
    {
        // Arrange
        string? json = null;

        switch (jsonCount)
        {
            case 0:
            {
                json = """
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
                break;
            }
            case 1:
            {
                json = """
                        {
                          "ID": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/activity",
                          "Type": "Create",
                          "Actor": "https://social.heise.de/users/heisedeveloper",
                          "Published": "2023-02-24T15:57:00Z",
                          "To": [
                            "https://www.w3.org/ns/activitystreams#Public"
                          ],
                          "CC": [
                            "https://social.heise.de/users/heisedeveloper/followers"
                          ],
                          "Object": {
                            "Id": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043",
                            "type": "Note",
                            "summary": null,
                            "inReplyTo": null,
                            "published": "2023-02-24T15:57:00Z",
                            "url": "https://social.heise.de/@heisedeveloper/109920532625809043",
                            "attributedTo": "https://social.heise.de/users/heisedeveloper",
                            "to": [
                              "https://www.w3.org/ns/activitystreams#Public"
                            ],
                            "Cc": [
                              "https://social.heise.de/users/heisedeveloper/followers"
                            ],
                            "Sensitive": false,
                            "AtomUri": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043",
                            "InReplyToAtomUri": null,
                            "Conversation": "tag:social.heise.de,2023-02-24:objectId=209050:objectType=Conversation",
                            "Content": "<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>",
                            "ContentMap": {
                              "de": "<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>"
                            },
                            "Attachment": [
                              {
                                "Type": "Document",
                                "MediaType": "image/jpeg",
                                "Url": "https://social.heise.de/system/media_attachments/files/109/920/532/619/836/925/original/fb52dfc289817fa2.jpeg",
                                "Name": null,
                                "Blurhash": "UuGSjUtS0YIURRnNa*S#R7Rkk8x[t7j=WUfl",
                                "Width": 600,
                                "Height": 338
                              }
                            ],
                            "Tag": [
                              {
                                "Type": "Hashtag",
                                "Href": "https://social.heise.de/tags/softwareentwicklung",
                                "Name": "#softwareentwicklung"
                              },
                              {
                                "Type": "Hashtag",
                                "Href": "https://social.heise.de/tags/news",
                                "Name": "#news"
                              }
                            ],
                            "Replies": {
                              "Id": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies",
                              "Type": "Collection",
                              "First": {
                                "Type": "CollectionPage",
                                "Next": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies?only_other_accounts=true&page=true",
                                "PartOf": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies",
                                "Items": []
                              }
                            }
                          }
                        }
                    """;

                break;
            }
        }


        Note? note = null;
        Create? createActivity = null;
        Document? document = null;
        Hashtag? hashtag = null;
        CollectionPage? collectionPage = null;

        // Act
        var create = JsonSerializer.Deserialize<Activity>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new ObjectTypeConverter<Activity>()
            }
        });
        note = (Note?)create?.Object.Objects.First();
        createActivity = (Create)create!;
        document = (Document)create?.Object?.Objects.First().Attachment?.Objects?.First()!;
        hashtag = (Hashtag)note?.Tag?.Links?.First()!;
        collectionPage = note?.Replies?.First?.Objects?.First()!;

        // Assert
        create.ShouldNotBeNull();
        createActivity.ShouldNotBeNull();
        create.GetType().ShouldBe(typeof(Create));
        createActivity.Type.ShouldBe("Create");
        createActivity.Id.ShouldBe(
            new Uri("https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/activity"));
        createActivity.Actor!.StringLinks!.ShouldContain(new Uri("https://social.heise.de/users/heisedeveloper"));
        createActivity.Published.ShouldBe(DateTime.Parse("2023-02-24T15:57:00Z").ToUniversalTime());
        createActivity.To!.StringLinks!.ShouldContain(new Uri("https://www.w3.org/ns/activitystreams#Public"));
        createActivity.Cc!.StringLinks!.ShouldContain(
            new Uri("https://social.heise.de/users/heisedeveloper/followers"));
        createActivity.Object!.Objects!.First().ShouldBeOfType<Note>();
        createActivity.Object!.Objects!.First().GetType().ShouldBe(typeof(Note));

        note.ShouldNotBeNull();
        note.Type.ShouldBe("Note");
        note.Id.ShouldBe(new Uri("https://social.heise.de/users/heisedeveloper/statuses/109920532625809043"));
        note.Published.ShouldBe(DateTime.Parse("2023-02-24T15:57:00Z").ToUniversalTime());
        note!.AttributedTo!.StringLinks!.ShouldContain(new Uri("https://social.heise.de/users/heisedeveloper"));
        note!.To!.StringLinks!.ShouldContain(new Uri("https://www.w3.org/ns/activitystreams#Public"));
        note!.Cc!.StringLinks!.ShouldContain(new Uri("https://social.heise.de/users/heisedeveloper/followers"));
        note!.Sensitive.ShouldBe(false);
        note!.Content.ShouldBe(
            "<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>");
        note!.ContentMap!.ShouldContainKeyAndValue("de",
            "<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>");
        note!.Attachment!.Objects!.First().ShouldBeOfType<Document>();
        note!.Url!.Href.ShouldBe(new Uri("https://social.heise.de/@heisedeveloper/109920532625809043"));
        note!.Tag!.Links!.First().ShouldBeOfType<Hashtag>();
        note!.Tag.StringLinks.ShouldBeNull();
        hashtag.Type.ShouldBe("Hashtag");
        hashtag.Href.ShouldBe(new Uri("https://social.heise.de/tags/softwareentwicklung"));
        hashtag.Name.ShouldBe("#softwareentwicklung");
        note.Replies!.Type.ShouldBe("Collection");
        note.Replies!.Id.ShouldBe(
            new Uri("https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies"));
        collectionPage.Type.ShouldBe("CollectionPage");
        collectionPage.ShouldBeOfType<CollectionPage>();
        collectionPage.Items?.Objects.ShouldBeNull();
        collectionPage.Next!.StringLinks!.First()
            .ShouldBe(
                new Uri(
                    "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies?only_other_accounts=true&page=true"));
        collectionPage.PartOf!.StringLinks!.First()
            .ShouldBe(new Uri("https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies"));
        document.Type.ShouldBe("Document");
        document.Url!.Href.ShouldBe(new Uri(
            "https://social.heise.de/system/media_attachments/files/109/920/532/619/836/925/original/fb52dfc289817fa2.jpeg"));
        document.MediaType.ShouldBe("image/jpeg");
    }

    [Fact]
    public void SerializeActivity()
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
                        "content": "<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>",
                        "contentMap": {
                          "de": "<p>Developer Snapshots: Programmierer-News in ein, zwei Sätzen</p><p>Unsere Übersicht kleiner, interessanter Meldungen enthält unter anderem GraphQL, SwaggerHub Explore, JetBrains Academy Plugin, Deno und Hugging Face.</p><p><a href=\"https://www.heise.de/news/Developer-Snapshots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege\" target=\"_blank\" rel=\"nofollow noopener noreferrer\"><span class=\"invisible\">https://www.</span><span class=\"ellipsis\">heise.de/news/Developer-Snapsh</span><span class=\"invisible\">ots-Programmierer-News-in-ein-zwei-Saetzen-7526368.html?wt_mc=sm.red.ho.mastodon.mastodon.md_beitraege.md_beitraege</span></a></p><p><a href=\"https://social.heise.de/tags/Softwareentwicklung\" class=\"mention hashtag\" rel=\"tag\">#<span>Softwareentwicklung</span></a> <a href=\"https://social.heise.de/tags/news\" class=\"mention hashtag\" rel=\"tag\">#<span>news</span></a></p>"
                        },
                        "attachment": [
                          {
                            "type": "Document",
                            "mediaType": "image/jpeg",
                            "url": "https://social.heise.de/system/media_attachments/files/109/920/532/619/836/925/original/fb52dfc289817fa2.jpeg"
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
                          "totalItems": 0,
                          "first": {
                            "totalItems": 0,
                            "type": "CollectionPage",
                            "next": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies?only_other_accounts=true&page=true",
                            "partOf": "https://social.heise.de/users/heisedeveloper/statuses/109920532625809043/replies",
                            "items": []
                          }
                        }
                      }
                    }
                """;
        var inputObject = JsonNode.Parse(json);

        var create = JsonSerializer.Deserialize<Create>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new ObjectTypeConverter<Activity>()
            }
        });

        // Act
        var resultJson = JsonSerializer.Serialize(create, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
        var resultObject = JsonNode.Parse(resultJson);

        // Assert
        JsonAssert.Equal(inputObject, resultObject, true);
    }
}