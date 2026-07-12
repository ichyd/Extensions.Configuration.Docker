using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace Ichyd.Extensions.Configuration.Docker
{
    /// <summary>
    /// Represents a <b>docker secrets</b> source of configuration key/values for an application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class DockerSecretsSource : IConfigurationSource
    {
        private string _secretsPath;

        /// <summary>
        /// Constructs a new instance of <see cref="DockerSecretsSource"/>.
        /// </summary>
        /// <param name="secretsPath">Path to the secrets location.</param>
        public DockerSecretsSource(string secretsPath)
        {
            _secretsPath = secretsPath;
        }

        /// <inheritdoc/>
        public IConfigurationProvider Build(IConfigurationBuilder builder) 
            => new DockerSecretsProvider(_secretsPath);
    }
}
