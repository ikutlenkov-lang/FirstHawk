namespace FirstHawk;

public sealed record ThemeOption(
    string Name,
    string Description,
    string Accent,
    string Background,
    string Surface,
    string Foreground,
    string Sidebar,
    string SurfaceAlt,
    string Muted,
    string Border,
    string Button)
{
    public static readonly IReadOnlyList<ThemeOption> All =
    [
        new("Midnight", "Deep graphite with electric blue accents", "#7C9CFF", "#0B1020", "#151D31", "#F3F6FF", "#0E1527", "#17233B", "#9AA8C4", "#263451", "#222E49"),
        new("Aurora", "Cool violet and cyan glass", "#B18CFF", "#111020", "#211B36", "#F8F3FF", "#17152B", "#2A2342", "#B8AECF", "#40345C", "#302747"),
        new("Emerald", "Dark forest with mint highlights", "#54D6A0", "#0B1715", "#142923", "#EDFFF7", "#10211D", "#1B342C", "#A8C9BB", "#29483C", "#203D32"),
        new("Snow", "Clean bright surfaces and calm blue", "#386CEB", "#EEF2F9", "#FFFFFF", "#172033", "#E3EAF5", "#DCE5F3", "#52627B", "#C7D2E3", "#D5E0F0")
    ];
}