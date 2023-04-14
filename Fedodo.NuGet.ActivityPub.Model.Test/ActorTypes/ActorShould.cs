using System.Text.Json;
using Fedodo.NuGet.ActivityPub.Model.ActorTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Xunit;

namespace Fedodo.NuGet.ActivityPub.Model.Test.ActorTypes;

public class ActorShould
{
    [Fact]
    public void DeserializeActor()
    {
        // Arrange
        var json =
            """
                {
                  "ID": "https://dev.fedodo.social/actor/e287834b-0564-4ece-b793-0ef323344959",
                  "Context": [
                    "https://www.w3.org/ns/activitystreams",
                    "https://w3id.org/security/v1"
                  ],
                  "Type": "Person",
                  "Name": "Test User",
                  "PreferredUsername": "Test001",
                  "Summary": "I am a Test User",
                  "Inbox": "https://dev.fedodo.social/inbox/e287834b-0564-4ece-b793-0ef323344959",
                  "Outbox": "https://dev.fedodo.social/outbox/e287834b-0564-4ece-b793-0ef323344959",
                  "Followers": "https://dev.fedodo.social/followers/e287834b-0564-4ece-b793-0ef323344959",
                  "Following": "https://dev.fedodo.social/following/e287834b-0564-4ece-b793-0ef323344959",
                  "Icon": null,
                  "PublicKey": {
                    "ID": "https://dev.fedodo.social/actor/e287834b-0564-4ece-b793-0ef323344959#main-key",
                    "Owner": "https://dev.fedodo.social/actor/e287834b-0564-4ece-b793-0ef323344959",
                    "PublicKeyPem": "-----BEGIN RSA PUBLIC KEY-----\nMIIBCgKCAQEAzpko50+cfo8KmyiJ8s0D25cPz0IrQ2YdAjQRA27cgwnb/ImAX3jvDWjcAKnObhmC4dwiErt4R7R+Fv458FMi5SrG+Zk9sjdzTXXn1eMmfAgsYXmrY6fia+gYlaS8ApbnO8gX/9U8mxPrRSr+dZSQ8NJ009rUN924XQYSJIUrZ2HM0eQIYmIQwPj/nzmynJYmL6n6KzN8IDE25GWPluMKGHimoIGSXE3s91+z/h9b+QRHz1iOGXxarCOZfP0YOWTWdZlK8eP4lQy4Vsl0eYxCYMBLSdkImH3mz00BhyMAqrZ4gyXD2MAxpQE5ZXKnKzrsDSGHi6niMQIwBFexuuqS+QIDAQAB\n-----END RSA PUBLIC KEY-----"
                  },
                  "Endpoints": null
                }
            """;

        // Act
        var create = JsonSerializer.Deserialize<Actor>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new ObjectTypeConverter<Actor>()
            }
        });

        // Assert
    }
}