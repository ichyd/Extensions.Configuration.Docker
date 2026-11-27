using System;
using Xunit;

namespace Extensions.Configuration.Docker.Test;

public class DockerSecretsProvider_Integration : IClassFixture<IntegrationFixture>
{
    private readonly IntegrationFixture _fixture;
    public DockerSecretsProvider_Integration(IntegrationFixture fixture)
    {
        ArgumentNullException.ThrowIfNull(fixture);
        _fixture = fixture;
    }

    [Fact]
    public void DockerSecrets_Get_ValidPath_Returns_ExpectedString()
    {
        // Arrange
        string expectedKey = IntegrationFixture.SampleSecretKey;

        // Act
        string? observedValue = _fixture.Configuration[expectedKey];

        // Assert
        Assert.Equal(expected: IntegrationFixture.SampleSecretValue, observedValue);
    }
}
