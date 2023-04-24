using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.JsonDiffPatch.Xunit;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.ObjectTypes;
using Shouldly;
using Xunit;
using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.Test.CoreTypes;

public class ObjectShould
{
    [Theory]
    [InlineData("./TestData/ObjectTests/ObjectTest1.json")]
    [InlineData("./TestData/ObjectTests/ObjectTest2.json")]
    [InlineData("./TestData/ObjectTests/ObjectTest3.json")]
    [InlineData("./TestData/ObjectTests/ObjectTest4.json")]
    [InlineData("./TestData/ObjectTests/ObjectTest5.json")]
    [InlineData("./TestData/ObjectTests/Example1.json")]
    [InlineData("./TestData/ObjectTests/AttachmentExample.json")]
    public void BeDeserializable(string path)
    {
        // Arrange
        var json = File.ReadAllText(path);

        // Act
        var activityPubObject = JsonSerializer.Deserialize<Object>(json);

        // Assert
        activityPubObject.ShouldNotBeNull();
    }

    [Fact]
    public void SerializeObject()
    {
        // Arrange
        var json = File.ReadAllText("./TestData/ObjectTests/ObjectTest3.json");
        var inputObject = JsonNode.Parse(json);
        var activityPubObject = JsonSerializer.Deserialize<Object>(json);
        var temp = activityPubObject!.Attachment!.Objects!.ToList();
        temp[0] = (Image)activityPubObject.Attachment.Objects!.First();
        activityPubObject.Attachment.Objects = temp;

        // Act
        var resultJson = JsonSerializer.Serialize(activityPubObject, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });
        var resultObject = JsonNode.Parse(resultJson);

        // Assert
        JsonAssert.Equal(inputObject, resultObject, true);
    }

    [Fact]
    public void AcceptPublicStrings()
    {
        // Arrange
        var json = 
            """
                {
                  "type": "Object",
                  "attachment": [
                    "https://example.com/example"
                  ],
                  "to": [
                    "as:Public",
                    "https://www.w3.org/ns/activitystreams#Public",
                    "public"
                    ]
                }
            """;

        // Act
        var activityPubObject = JsonSerializer.Deserialize<Object>(json);
        
        // Assert
        activityPubObject!.To!.StringLinks.ShouldNotBeNull();
        var list = activityPubObject!.To!.StringLinks.ToList();
        list[0].ShouldBe("as:Public");
        list[1].ShouldBe("https://www.w3.org/ns/activitystreams#Public");
        list[2].ShouldBe("public");
    }
}