# FirstHawk

**Make Windows yours.**

FirstHawk is a visual customization hub for Windows 10 and Windows 11. The first release focuses on a polished desktop companion, theme previews, and a safe foundation for reversible visual tweaks.

## FirstHawk 0.1

- WPF desktop application targeting .NET 8
- Windows 10 / Windows 11 detection
- Dark and light application appearance
- Theme gallery with live preview and selection
- Safe architecture for future reversible visual modules
- No process injection, unsigned code loading, or destructive system changes

> The initial theme selector changes FirstHawk's own interface. Applying system-wide Windows changes will be added as separately tested, reversible modules.

## Build

Install the .NET 8 SDK on Windows, then run:

```powershell
dotnet restore FirstHawk.sln
dotnet build FirstHawk.sln -c Release
dotnet run --project src/FirstHawk/FirstHawk.csproj
```

## Compatibility

Windows 10 (1903+) and Windows 11, x64.

## License

MIT
