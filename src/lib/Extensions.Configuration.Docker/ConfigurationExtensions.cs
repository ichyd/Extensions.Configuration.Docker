using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Ichyd.Extensions.Configuration.Docker
{
    /// <summary>
    /// Extension methods for adding <see cref="DockerSecretsProvider"/> to a <see cref="IConfigurationBuilder"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ConfigurationManagerExtensions
    {
        /// <summary>
        /// Add a <see cref="DockerSecretsProvider"/> to this configuration.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="secretsPath">Path to the secrets. Default is <em>/run/secrets</em>.</param>
        /// <returns>This <see cref="IConfigurationBuilder"/> instance for method chaining.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IConfigurationBuilder AddDockerSecrets(
            this IConfigurationBuilder builder, string? secretsPath = "/run/secrets")
        {
            ArgumentException.ThrowIfNullOrEmpty(secretsPath);
            
            builder.Add(new DockerSecretsSource(secretsPath));

            return builder;
        }
    }
}
