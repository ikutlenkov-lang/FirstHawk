using System.Windows;
using System.Windows.Controls;

namespace FirstHawk;

public partial class ThemesWindow : Window
{
    public ThemesWindow()
    {
        InitializeComponent();
        ThemeList.ItemsSource = ThemeOption.All;
        GalleryStatus.Text = $"Current theme: {ThemeService.CurrentThemeName}. Choose a theme to apply it.";
    }

    private void ApplyTheme_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { Tag: ThemeOption theme })
        {
            ThemeService.Apply(theme);
            GalleryStatus.Text = $"{theme.Name} is now active. Your choice is saved for the next launch.";
        }
    }
}