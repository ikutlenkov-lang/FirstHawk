# FirstHawk

**Make Windows yours.**

FirstHawk is a visual customization hub for Windows 10 and Windows 11. The current build is a working desktop companion with a persistent theme engine and shortcuts to native Windows personalization settings.

## Working in this build

- WPF desktop application targeting .NET 8 (Windows x64 publish)
- Windows 10 / Windows 11 detection
- Four application themes: Midnight, Aurora, Emerald, and Snow
- Live theme application across windows and controls that use the shared theme resources
- Theme selection saved to `%LocalAppData%\FirstHawk\settings.json` and restored on next launch
- Reset appearance to the default Midnight theme
- Taskbar, Desktop, and Effects sections open the corresponding Windows Settings pages
- No process injection, unsigned code loading, or destructive system changes

## Build

Install the .NET 8 SDK on Windows, then run:

```powershell
dotnet restore src/FirstHawk/FirstHawk.csproj
dotnet build src/FirstHawk/FirstHawk.csproj -c Release
dotnet run --project src/FirstHawk/FirstHawk.csproj
```

A self-contained Windows x64 build is also produced by the GitHub Actions workflow. Download the `FirstHawk-Windows-x64` artifact from the latest successful workflow run.

## Compatibility

Windows 10 (1903+) and Windows 11, x64.

## Roadmap

- More granular taskbar and desktop controls with reversible settings
- Built-in visual effects with previews
- Curated, reviewable module library
- Import and export of appearance profiles

## License

MIT
