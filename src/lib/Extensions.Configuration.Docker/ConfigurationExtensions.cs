using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Hisaac.Extensions.Configuration.Docker
{
    [ExcludeFromCodeCoverage]
    public static class ConfigurationManagerExtensions
    {
        public static IConfigurationBuilder AddDockerSecrets(
            this IConfigurationBuilder builder, string? secretsPath = null)
        {
            ArgumentException.ThrowIfNullOrEmpty(secretsPath);
            ArgumentException.ThrowIfNullOrWhiteSpace(secretsPath);

            if(!Directory.Exists(secretsPath))
                throw new InvalidOperationException(
                    $"Could not find part of the secrets path: {secretsPath}");

            builder.Add(new DockerSecretsSource(secretsPath));

            return builder;
        }
    }
}
