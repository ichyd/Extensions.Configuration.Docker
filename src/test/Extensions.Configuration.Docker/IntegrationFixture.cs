using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Ichyd.Extensions.Configuration.Docker;
using System.Diagnostics;

namespace Extensions.Configuration.Docker.Test
{
    /// <summary>
    /// Builds a configuration from a temporary secrets folder, so unit tests do not depend on
    /// <em>/run/secrets</em> existing on the host.
    /// </summary>
    public sealed class IntegrationFixture : IDisposable
    {
        public const string SampleSecretKey = "SAMPLE_SECRET";
        public const string SampleSecretValue = "SOME SECRET TEXT";

        public IntegrationFixture()
        {
            SecretsPath = Directory.CreateTempSubdirectory("docker-secrets-").FullName;
            File.WriteAllText(Path.Combine(SecretsPath, SampleSecretKey), SampleSecretValue);

            Debug.WriteLine(string.Format("Created temp directory: {0}", SecretsPath));

            Configuration = new ConfigurationBuilder()
                                .AddDockerSecrets(SecretsPath)
                                .Build();
            var home = Environment.GetEnvironmentVariable("HOME");
            Debug.WriteLine(string.Format("Home directory is at: {0}", home));
        }

        public string SecretsPath { get; init; }

        public IConfiguration Configuration { get; init; }

        public void Dispose()
        {
            if (Directory.Exists(SecretsPath))
                Directory.Delete(SecretsPath, recursive: true);
        }
    }
}
