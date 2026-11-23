using System.Windows;
using System.Windows.Controls;

namespace FirstHawk;

public partial class ThemesWindow : Window
{
    public ThemesWindow()
    {
        InitializeComponent();
        ThemeList.ItemsSource = ThemeOption.All;
    }

    private void ApplyTheme_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { Tag: ThemeOption theme })
            GalleryStatus.Text = $"{theme.Name} selected. Workspace theme engine is ready for the next implementation step.";
    }
}
