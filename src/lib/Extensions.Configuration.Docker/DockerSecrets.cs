using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Hoeydev.Extensions.Configuration.Docker
{
    public class DockerSecretsProvider : IConfigurationProvider
    {
        /// <inheritdoc/>
        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string? parentPath)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Load()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Set(string key, string? value)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool TryGet(string key, out string? value)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Represents a <b>docker secrets</b> source of configuration key/values for an application.
    /// </summary>
    public class DockerSecretsSource : IConfigurationSource
    {
        /// <inheritdoc/>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            throw new NotImplementedException();
        }
    }

    // public static class ConfigurationManagerExtensions
    // {
    //     public static ConfigurationManager AddEntityConfiguration(
    //         this ConfigurationManager manager)
    //     {
    //         var connectionString = manager.GetConnectionString("WidgetConnectionString");

    //         IConfigurationBuilder configBuilder = manager;
    //         configBuilder.Add(new EntityConfigurationSource(connectionString));

    //         return manager;
    //     }
    // }
}
