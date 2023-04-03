using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Fedodo.NuGet.ActivityPub.Model.JsonConverters;
using Fedodo.NuGet.ActivityPub.Model.Properties;
using Shouldly;
using Xunit;

namespace Fedodo.NuGet.ActivityPub.Model.Test.JsonConverters;

public class AttachmentConverterShould
{
    [Fact]
    public void Write()
    {
        // Arrange
        var attachments = new List<Attachment>()
        {
            new()
            {
                Type = "",
                Content = "",
                Url = new Uri("https://example.com")
            }
        };
        var options = new JsonSerializerOptions()
        {
            Converters = { new AttachmentConverter() },
            WriteIndented = true
        };

        // Act
        var json = JsonSerializer.Serialize(attachments, options);

        // Assert
        json.ShouldNotBeNullOrEmpty();
    }
}