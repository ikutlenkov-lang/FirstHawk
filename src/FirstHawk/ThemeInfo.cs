namespace FirstHawk;

public sealed record ThemeOption(string Name, string Description, string Accent, string Background, string Surface, string Foreground)
{
    public static readonly IReadOnlyList<ThemeOption> All =
    [
        new("Midnight", "Deep graphite with electric blue accents", "#7C9CFF", "#0B1020", "#151D31", "#F3F6FF"),
        new("Aurora", "Cool violet and cyan glass", "#B18CFF", "#111020", "#211B36", "#F8F3FF"),
        new("Emerald", "Dark forest with mint highlights", "#54D6A0", "#0B1715", "#142923", "#EDFFF7"),
        new("Snow", "Clean bright surfaces and calm blue", "#386CEB", "#EEF2F9", "#FFFFFF", "#172033")
    ];
}
