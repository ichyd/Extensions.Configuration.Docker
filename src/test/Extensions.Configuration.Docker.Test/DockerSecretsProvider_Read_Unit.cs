using System;
using Xunit;

namespace Extensions.Configuration.Docker.Test
{
    [Trait(nameof(TestAttributeNames.Category), "Unit")]
    public class DockerSecretsProvider_Read_Unit : IClassFixture<UnitFixture>
    {
        private readonly UnitFixture _fixture;

        public DockerSecretsProvider_Read_Unit(UnitFixture fixture)
        {
            ArgumentNullException.ThrowIfNull(fixture);
            _fixture = fixture;
        }

        [Fact]
        public void DockerSecrets_Get_ValidPath_Returns_ExpectedString()
        {
            // Arrange
            string expectedKey = UnitFixture.SampleSecretKey;

            // Act
            string? observedValue = _fixture.Configuration[expectedKey];

            // Assert
            Assert.Equal(expected: UnitFixture.SampleSecretValue, observedValue);
        }

        [Fact]
        public void DockerSecrets_Get_MissingKey_Returns_Null()
        {
            // Arrange
            // Act
            string? observedValue = _fixture.Configuration["NOT_A_REAL_SECRET"];

            // Assert
            Assert.Null(observedValue);
        }
    }
}
