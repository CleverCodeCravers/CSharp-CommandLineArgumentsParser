# CSharp-CommandLineArgumentsParser

Feature rich library to parse command line arguments in C# Applications


# Usage

[Github Docs](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry)

# Pushing the package

`dotnet nuget push "PATH TO NUPKG" --api-key YOUR_PAT --source "github"`

# Where is my nuget-config file?

```
C:\Users\USERNAME\AppData\Roaming\NuGet\NuGet.Config
```


```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
    <add key="github" value="https://nuget.pkg.github.com/CleverCodeCravers/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
        <add key="Username" value="CleverCodeCravers" />
        <add key="ClearTextPassword" value="<PERSONAL ACCESS TOKEN FOR YOUR USER>" />
      </github>
  </packageSourceCredentials>
</configuration>
```
