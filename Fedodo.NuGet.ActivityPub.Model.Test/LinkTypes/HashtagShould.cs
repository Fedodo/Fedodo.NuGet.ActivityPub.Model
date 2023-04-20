using System.Linq;
using System.Text.Json;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.LinkTypes;
using Shouldly;
using Xunit;

namespace Fedodo.NuGet.ActivityPub.Model.Test.LinkTypes;

public class HashtagShould
{
    [Fact]
    public void Deserialize()
    {
        // Arrange
        var json =
            """
              {
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
                ]
                
              }              
            """;

        // Act
        var create = JsonSerializer.Deserialize<Object>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new ObjectTypeConverter<Object>()
            }
        });

        // Assert
        create.ShouldNotBeNull();
        create.Tag.Links.Count().ShouldBe(2);
        create.Tag.StringLinks.ShouldBeNull();
    }
}