using System.IO;
using System.Text.Json;
using Fedodo.NuGet.ActivityPub.Model.CoreTypes;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.ObjectTypes;
using Shouldly;
using Xunit;

namespace Fedodo.NuGet.ActivityPub.Model.Test.CoreTypes;

public class ActivityShould
{
    [Fact]
    public void Serialize()
    {
        // Arrange
        var json = File.ReadAllText("./TestData/ActivityTests/Create.json");
        Activity? note = null;

        // Act
        var create = JsonSerializer.Deserialize<Activity>(json);

        if (create?.Object?.Type == "Note") note = JsonSerializer.Deserialize<Activity>(json);

        // Assert
        create.ShouldNotBeNull();
        note.ShouldNotBeNull();
    }
}