using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Media;

namespace FirstHawk;

public static class ThemeService
{
    private sealed record UserSettings(string ThemeName);
    private static bool _initialized;
    private static string SettingsPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FirstHawk", "settings.json");
    public static string CurrentThemeName { get; private set; } = "Midnight";

    public static void Initialize()
    {
        if (_initialized) return;
        _initialized = true;
        var themeName = "Midnight";
        try
        {
            if (File.Exists(SettingsPath))
                themeName = JsonSerializer.Deserialize<UserSettings>(File.ReadAllText(SettingsPath))?.ThemeName ?? themeName;
        }
        catch { /* Invalid settings should never stop startup. */ }

        var theme = ThemeOption.All.FirstOrDefault(x => string.Equals(x.Name, themeName, StringComparison.OrdinalIgnoreCase)) ?? ThemeOption.All[0];
        Apply(theme, persist: false);
    }

    public static void Apply(ThemeOption theme, bool persist = true)
    {
        var app = System.Windows.Application.Current;
        if (app is null) return;
        var resources = app.Resources;
        resources["AppBackground"] = Brush(theme.Background);
        resources["SidebarBackground"] = Brush(theme.Sidebar);
        resources["SurfaceBackground"] = Brush(theme.Surface);
        resources["SurfaceAltBackground"] = Brush(theme.SurfaceAlt);
        resources["AppForeground"] = Brush(theme.Foreground);
        resources["MutedForeground"] = Brush(theme.Muted);
        resources["AccentBrush"] = Brush(theme.Accent);
        resources["BorderBrush"] = Brush(theme.Border);
        resources["ButtonBackground"] = Brush(theme.Button);
        resources["AccentSurface"] = Brush(Blend(theme.Background, theme.Accent, 0.22));
        resources["AccentBorder"] = Brush(Blend(theme.Background, theme.Accent, 0.48));
        resources["ButtonHoverBackground"] = Brush(Blend(theme.Surface, theme.Accent, 0.30));
        CurrentThemeName = theme.Name;

        if (!persist) return;
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath)!);
            File.WriteAllText(SettingsPath, JsonSerializer.Serialize(new UserSettings(theme.Name)));
        }
        catch { /* Keep the in-memory theme even if disk access is unavailable. */ }
    }

    public static void Reset() => Apply(ThemeOption.All[0]);

    private static SolidColorBrush Brush(string value) => new((Color)ColorConverter.ConvertFromString(value));

    private static string Blend(string first, string second, double amount)
    {
        var a = (Color)ColorConverter.ConvertFromString(first);
        var b = (Color)ColorConverter.ConvertFromString(second);
        byte Mix(byte x, byte y) => (byte)Math.Clamp(x + (y - x) * amount, 0, 255);
        var result = Color.FromRgb(Mix(a.R, b.R), Mix(a.G, b.G), Mix(a.B, b.B));
        return $"#{result.R:X2}{result.G:X2}{result.B:X2}";
    }
}