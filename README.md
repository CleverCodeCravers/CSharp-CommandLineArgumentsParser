# CSharp-CommandLineArgumentsParser

Feature rich library to parse command line arguments in C# Applications

# Usage

[Github Docs](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry)

# Pushing the package

`dotnet nuget push "PATH TO NUPKG" --api-key YOUR_PAT --source "github"`

# Packing the package with the right metadata

`NuGet.exe pack CommandLineArgumentsParser.csproj -Prop Configuration=Release`

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

# Usage

This is an advance approach for using the library, a simpler way is also possible.

## Define a Record for the CLI Commands:

```csharp
    public record ConsoleCommandLineParameters(bbol Configure, string TargetDirectory, string ScriptsDirectory, int Count);
```

## Now Create a class that should parse and handle your CLI commands:

```csharp
using CommandLineArgumentsParser;

    public class ConsoleCommandLineParser
    {
        public Result<ConsoleCommandLineParameters> Parse(string[] args)
        {
            var parser = new Parser(
                new ICommandLineOption[] {
                new BoolCommandLineOption("--configure", "configures the app"),
                new StringCommandLineOption("--targetDirectory", "The directory where the files should be saved e.g"),
                new StringCommandLineOption("--scriptsDirectory", "The directory where the scripts live"),
                new Int32CommandLineOption("--count", "How many times the app should run!")
                });

            if (!parser.TryParse(args, true) || args.Length == 0)
            {
                return Result<ConsoleCommandLineParameters>.Failure("Invalid command line arguments");
            }

            return Result<ConsoleCommandLineParameters>.Success(
                new ConsoleCommandLineParameters(
                    parser.GetBoolOption("--configure"),
                    parser.GetOptionWithValue<string>("--targetDirectory") ?? "",
                    parser.GetOptionWithValue<string>("--scriptsDirectory") ?? "",
                    parser.GetOptionWithValue<int>("--count") ?? 0,
                ));
        }
    }

```

## Now use the class in your main program:

```csharp

var parser = new ConsoleCommandLineParser();

var commandLineParametersResult = parser.Parse(args);

if (!commandLineParametersResult.IsSuccess)
{
    Console.WriteLine("Unfortunately there have been problems with the command line arguments.");
    return;
}

var parameters = commandLineParametersResult.Value;

```

## Iterating through the registered CLI options:

```csharp
var parser = new ConsoleCommandLineParser();

var commandLineParametersResult = parser.Parse(args);

if (!commandLineParametersResult.IsSuccess)
{
    Console.WriteLine("Unfortunately there have been problems with the command line arguments.");
    return;
}

// The GetCommandsList() will return an array of ICommandLineOption[] which can be helpful when creating help command

ICommandLineOption[] commands = parser.GetCommandsList();
```
