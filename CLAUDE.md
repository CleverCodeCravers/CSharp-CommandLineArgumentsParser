# CLAUDE.md

## Projektbeschreibung

CSharp-CommandLineArgumentsParser ist eine Library zum Parsen von Kommandozeilen-Argumenten in C#-Anwendungen. Sie unterstuetzt Bool-, String- und Int32-Optionen mit Validierung und bietet ein einfaches API fuer die Definition und Auswertung von CLI-Parametern.

## TechStack

- .NET 10.0
- C#
- NuGet-Paket

## Build

```bash
dotnet build Source/CommandLineArgumentsParser/CommandLineArgumentsParser/CommandLineArgumentsParser.csproj
```

## Konventionen

- Namespace: `CommandLineArgumentsParser`
- Neue Optionstypen erben von `WithValueCommandLineOption<T>` und implementieren `ValidateAndParseValue`
- Bool-Optionen implementieren `IBoolCommandLineOption`
- Alle Optionen implementieren `ICommandLineOption`
- `TreatWarningsAsErrors` ist aktiv -- alle Warnungen muessen behoben werden
- Nullable Reference Types sind aktiviert (`<Nullable>enable</Nullable>`)
