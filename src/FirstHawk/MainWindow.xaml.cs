using System;
using System.Diagnostics;
using System.Windows;

namespace FirstHawk;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ThemeService.Initialize();
        DetectWindows();
    }

    private void DetectWindows()
    {
        var version = Environment.OSVersion.Version;
        bool isWindows11 = version.Build >= 22000;
        OsLabel.Text = isWindows11 ? "Windows 11" : "Windows 10 / compatible";
        SystemName.Text = isWindows11 ? "Windows 11" : "Windows 10";
        SystemVersion.Text = $"Build {version.Build} · {(Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit")}";
        StatusText.Text = $"Running on {Environment.MachineName} · FirstHawk 0.1.0 · {ThemeService.CurrentThemeName}";
    }

    private void SetPage(string title, string subtitle)
    {
        PageTitle.Text = title;
        PageSubtitle.Text = subtitle;
        StatusText.Text = $"Opened {title}";
    }

    private void OpenWindowsSettings(string uri, string title, string subtitle)
    {
        SetPage(title, subtitle);
        try
        {
            Process.Start(new ProcessStartInfo(uri) { UseShellExecute = true });
            StatusText.Text = $"Opened Windows Settings · {title}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Windows Settings could not be opened.\n\n{ex.Message}", "FirstHawk", MessageBoxButton.OK, MessageBoxImage.Warning);
            StatusText.Text = $"Could not open {title}";
        }
    }

    private void Overview_Click(object sender, RoutedEventArgs e)
    {
        SetPage("Good afternoon.", "A calmer, more personal desktop starts here.");
        StatusText.Text = $"FirstHawk is ready · Theme: {ThemeService.CurrentThemeName}";
    }

    private void Themes_Click(object sender, RoutedEventArgs e)
    {
        var window = new ThemesWindow { Owner = this };
        window.ShowDialog();
        StatusText.Text = $"Active theme: {ThemeService.CurrentThemeName}";
    }

    private void Taskbar_Click(object sender, RoutedEventArgs e) =>
        OpenWindowsSettings("ms-settings:taskbar", "Taskbar studio", "Windows taskbar settings are open. Changes are managed by Windows and can be reverted there.");

    private void Desktop_Click(object sender, RoutedEventArgs e) =>
        OpenWindowsSettings("ms-settings:personalization-background", "Desktop studio", "Choose and customize your Windows desktop background in the system settings.");

    private void Effects_Click(object sender, RoutedEventArgs e) =>
        OpenWindowsSettings("ms-settings:colors", "Visual effects", "Windows color, transparency, and appearance settings are open.");

    private void Library_Click(object sender, RoutedEventArgs e) =>
        MessageBox.Show("The module library is being built. Future modules will be reviewed, reversible, and installed only with your confirmation.", "FirstHawk · Mod library", MessageBoxButton.OK, MessageBoxImage.Information);

    private void Settings_Click(object sender, RoutedEventArgs e)
    {
        var answer = MessageBox.Show(
            $"Current theme: {ThemeService.CurrentThemeName}\n\nReset FirstHawk appearance to the default Midnight theme?",
            "FirstHawk settings",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if (answer == MessageBoxResult.Yes)
        {
            ThemeService.Reset();
            StatusText.Text = "Appearance reset to Midnight. The choice has been saved.";
        }
        else
        {
            StatusText.Text = $"Settings unchanged · Theme: {ThemeService.CurrentThemeName}";
        }
    }
}