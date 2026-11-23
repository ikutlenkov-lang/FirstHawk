using System;
using System.Linq;
using System.Windows;

namespace FirstHawk;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DetectWindows();
    }

    private void DetectWindows()
    {
        var version = Environment.OSVersion.Version;
        bool isWindows11 = version.Build >= 22000;
        OsLabel.Text = isWindows11 ? "Windows 11" : "Windows 10 / compatible";
        SystemName.Text = isWindows11 ? "Windows 11" : "Windows 10";
        SystemVersion.Text = $"Build {version.Build} · {Environment.Is64BitOperatingSystem switch { true => "64-bit", false => "32-bit" }}";
        StatusText.Text = $"Running on {Environment.MachineName} · FirstHawk 0.1.0";
    }

    private void SetPage(string title, string subtitle)
    {
        PageTitle.Text = title;
        PageSubtitle.Text = subtitle;
        StatusText.Text = $"Opened {title}";
    }

    private void Overview_Click(object sender, RoutedEventArgs e) => SetPage("Good afternoon.", "A calmer, more personal desktop starts here.");
    private void Themes_Click(object sender, RoutedEventArgs e)
    {
        var window = new ThemesWindow { Owner = this };
        window.ShowDialog();
        StatusText.Text = "Theme gallery closed.";
    }
    private void Taskbar_Click(object sender, RoutedEventArgs e) => SetPage("Taskbar studio", "Taskbar visual controls are being prepared for a reversible release.");
    private void Desktop_Click(object sender, RoutedEventArgs e) => SetPage("Desktop studio", "Wallpaper collections and desktop widgets are coming next.");
    private void Effects_Click(object sender, RoutedEventArgs e) => SetPage("Visual effects", "Explore motion, transparency, and window polish in a future update.");
    private void Library_Click(object sender, RoutedEventArgs e) => SetPage("Mod library", "The extension catalogue is being prepared. Only trusted, reviewable modules will be supported.");
    private void Settings_Click(object sender, RoutedEventArgs e) => SetPage("Settings", "FirstHawk preferences and restore controls will live here.");
}
