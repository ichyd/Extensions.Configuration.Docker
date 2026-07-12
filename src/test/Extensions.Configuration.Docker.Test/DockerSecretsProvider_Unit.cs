using System;
using Hi_saac.Extensions.Configuration.Docker;
using Xunit;
using Xunit.Sdk;

namespace Extensions.Configuration.Docker.Test
{
    [Trait(nameof(TestAttributeNames.Category), "Unit")]
    public partial class DockerSecretsProvider_Unit
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void DockerSecrets_Constructor_EmptySecretPath_Throws_ArgumentException(
            string? path)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => new DockerSecretsProvider(path!));
        }

        [Fact]
        public void DockerSecrets_Constructor_NullSecretPath_Throws_ArgumentNullException()
        {
            // Arrange
            string? path = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new DockerSecretsProvider(path!));
        }

        [Fact]
        public void DockerSecrets_Constructor_InvalidSecretPath_Throws_InvalidOperationException()
        {
            // Arrange
            string path = "NOT_A_REAL_DIRECTORY";
            // Act
            
            
            // Assert
            Assert.Throws<InvalidOperationException>(() => new DockerSecretsProvider(path!));
        }

        [Fact]
        public void DockerSecrets_Constructor_ValidSecretPath_Returns_Instance()
        {
            // Arrange
            string path = "./";
            
            // Act
            var provider = new DockerSecretsProvider(path);
            
            // Assert
            Assert.Multiple(
                () => Assert.NotNull(provider),
                () => Assert.IsType<DockerSecretsProvider>(provider)
            );
        }

        [Fact]
        public void DockerSecrets_Set_Throws_NotSupportedException()
        {
            // Arrange
            string path = "./";
            var provider = new DockerSecretsProvider(path);

            // Act
            // Assert
            Assert.Throws<NotSupportedException>(
                () => provider.Set("TEST_KEY", "TEST_VALUE")
            );
        }

    }

    public partial class DockerSecretsProvider_Unit : IClassFixture<UnitFixture>
    {
        private readonly UnitFixture _fixture;
        public DockerSecretsProvider_Unit(UnitFixture fixture)
        {
            ArgumentNullException.ThrowIfNull(fixture);
            _fixture = fixture;
        }

        [Fact]
        public void DockerSecrets_Get_ValidPath_Returns_ExpectedString()
        {
            // Arrange
            string expectedKey = "SAMPLE_SECRET"; // see docker-compose.yml for devcontainer            
            // Act
            
            string? observedValue = _fixture.Configuration[expectedKey];

            // Assert
            Assert.Equal(expected: "SOME SECRET TEXT", observedValue);
        }
    }
}
