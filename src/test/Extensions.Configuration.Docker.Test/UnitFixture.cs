using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Ichyd.Extensions.Configuration.Docker;

namespace Extensions.Configuration.Docker.Test
{
    /// <summary>
    /// Builds a configuration from a temporary secrets folder, so unit tests do not depend on
    /// <em>/run/secrets</em> existing on the host.
    /// </summary>
    public sealed class UnitFixture : IDisposable
    {
        public const string SampleSecretKey = "SAMPLE_SECRET";
        public const string SampleSecretValue = "SOME SECRET TEXT";

        public UnitFixture()
        {
            SecretsPath = Directory.CreateTempSubdirectory("docker-secrets-").FullName;
            File.WriteAllText(Path.Combine(SecretsPath, SampleSecretKey), SampleSecretValue);

            Configuration = new ConfigurationBuilder()
                                .AddDockerSecrets(SecretsPath)
                                .Build();

            Logger = new LoggerFactory().CreateLogger("UNIT_TEST");
        }

        public string SecretsPath { get; }

        public ILogger Logger { get; }

        public IConfiguration Configuration { get; }

        public void Dispose()
        {
            if (Directory.Exists(SecretsPath))
                Directory.Delete(SecretsPath, recursive: true);
        }
    }
}
