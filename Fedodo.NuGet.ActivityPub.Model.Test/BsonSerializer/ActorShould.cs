using Fedodo.NuGet.ActivityPub.Model.ActorTypes;
using MongoDB.Bson;
using Shouldly;
using Xunit;

namespace Fedodo.NuGet.ActivityPub.Model.Test.BsonSerializer;

public class ActorShould
{
    [Fact]
    public void BsonSerialize()
    {
        // Arrange
        var document = new BsonDocument
        {
            {"_id", "https://dev.fedodo.social/actor/e287834b-0564-4ece-b793-0ef323344959"},
            {"Type", "Person"},
            {"Summary", "I am a Test User"},
        };
        
        // Act
        var result = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<Actor>(document);

        // Assert
        result.ShouldNotBeNull();
    }
}