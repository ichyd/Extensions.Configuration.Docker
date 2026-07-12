using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Ichyd.Extensions.Configuration.Docker
{
    /// <summary>
    /// Provides <b>docker secrets</b> configuration providder key/values for an application.
    /// </summary>
    public sealed class DockerSecretsProvider : ConfigurationProvider
    {
        private string _secretsPath;

        public DockerSecretsProvider(string secretsPath)
        {
            ArgumentException.ThrowIfNullOrEmpty(secretsPath);
            ArgumentException.ThrowIfNullOrWhiteSpace(secretsPath);

            if(!Directory.Exists(secretsPath))
                    throw new InvalidOperationException(
                        $"Could not find part of the secrets path: {secretsPath}");

            _secretsPath = secretsPath;
        }
        /// <inheritdoc/>
        public override IEnumerable<string> GetChildKeys(
            IEnumerable<string> earlierKeys, string? parentPath) => 
                base.GetChildKeys(earlierKeys, parentPath);

        /// <inheritdoc/>
        public override void Load()
        {
            foreach(var file in Directory.EnumerateFiles(_secretsPath))
                Data.Add(Path.GetFileName(file), null);
        }

        /// <inheritdoc/>
        public override void Set(string key, string? value)
        {
            throw new NotSupportedException(
                "Setting docker secrets is not supported. Manage secrets via the docker CLI.");
        }

        /// <inheritdoc/>
        public override bool TryGet(string key, out string? value)
        {
            value = null;
            if(!Data.ContainsKey(key))
                return false;
            
            value = ReadFile(key);
            return true;
        }

        private string? ReadFile(string key)
        {
            if(string.IsNullOrEmpty(key))
                return null;

            string? value = File.ReadAllText($"{_secretsPath}/{key}");

            return value;
        }
    }
}
