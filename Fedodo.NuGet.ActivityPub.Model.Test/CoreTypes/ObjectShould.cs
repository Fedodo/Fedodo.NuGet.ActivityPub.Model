using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Shouldly;
using Xunit;

namespace Fedodo.NuGet.ActivityPub.Model.Test.CoreTypes;

public class ObjectShould
{
    [Theory]
    [InlineData("./TestData/ObjectTest1.json")]
    [InlineData("./TestData/ObjectTest2.json")]
    [InlineData("./TestData/ObjectTest3.json")]
    [InlineData("./TestData/ObjectTest4.json")]
    [InlineData("./TestData/ObjectTest5.json")]
    public void BeDeserializable(string path)
    {
        // Arrange
        var json = File.ReadAllText(path);

        // Act
        var activityPubObject = JsonSerializer.Deserialize<Object>(json);

        // Assert
        activityPubObject.ShouldNotBeNull();
        activityPubObject.Attachment.ShouldNotBeNull();
    }
}