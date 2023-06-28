using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ApiaryAPP.Views;

public partial class InspectionView : Window
{
    public InspectionView()
    {
        InitializeComponent();
// #if DEBUG
//         this.AttachDevTools();
// #endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void CloseInspectionView(object sender, RoutedEventArgs e)
    {
        ((Window)this.VisualRoot).Close();

    }
}