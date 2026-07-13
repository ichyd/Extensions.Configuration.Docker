# (dotnet) Extensions.Configuration.Docker
A dotnet custom configuration provider using Docker secrets.

## Getting started 

A NuGet package may be installed from GitHub:

Add the package source:
```bash
$ dotnet nuget add source --name github "https://nuget.pkg.github.com/ichyd/index.json"
```

If you need to push packages:
```bash
$ dotnet nuget add source --username $GITHUB_USER --password $GITHUB_PAT --store-password-in-clear-text --name github "https://nuget.pkg.github.com/ichyd/index.json"
# Push the package to the GitHub NuGet repository
$ dotnet nuget push "bin/Release/Ichyd.Extensions.Configuration.Docker.1.0.0.nupkg" --api-key $GITHUB_PAT --source "github"
```

Add a package reference.
```bash
$ dotnet add package Ichyd.Extensions.Configuration.Docker --version 1.0.0
```

## Usage
Once the package referenced is added or restored, use the extension methods to modify the `IConfigurationBuilder`.
```csharp
IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .AddDockerSecrets()
                    .Build();
```

The base path to the secret store may be specified, but this is not recommended. The default setting uses the Docker sercrets store at `/run/secrets` within the container.

## See also:
- [dotnet configuration provider](https://learn.microsoft.com/en-us/dotnet/core/extensions/custom-configuration-provider)
- [docker secrets](https://docs.docker.com/engine/swarm/secrets/)

[Contributing Guidelines](CONTRIBUTING.md)
