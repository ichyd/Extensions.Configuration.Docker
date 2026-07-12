using Ichyd.Extensions.Configuration.Docker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Extensions.Configuration.Docker.Test
{
    public class UnitFixture
    {
        public UnitFixture()
        {
            Configuration = new ConfigurationBuilder()
                                .AddDockerSecrets()
                                .Build();
                                
            Logger = new LoggerFactory().CreateLogger("UNIT_TEST");
        }
        public required ILogger Logger { get; init; }
    
        public required IConfiguration Configuration { get; init; }
    }
}

