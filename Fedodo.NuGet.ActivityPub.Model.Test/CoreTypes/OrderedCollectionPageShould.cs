using System.Text.Json;
using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;
using Shouldly;
using Xunit;

namespace Fedodo.NuGet.ActivityPub.Model.Test.CoreTypes;

public class OrderedCollectionPageShould
{
    [Fact]
    public void ShouldSerializeCorrectly()
    {
        // Arrange
        OrderedCollectionPage page = new()
        {
            Items = new TripleSet<Object>()
            {
                StringLinks = new []
                {
                    "Lexa kom Trikru",
                    "Blub"
                }
            }
        };
        var jsonShould =
            """
            {"type":"OrderedCollectionPage","startIndex":0,"orderedItems":["Lexa kom Trikru","Blub"],"totalItems":0,"@context":"https://www.w3.org/ns/activitystreams"}
            """;

        // Act
        var json = JsonSerializer.Serialize(page, new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        // Assert
        json.ShouldNotBeNull();
        json.ShouldBe(jsonShould);
    }
}