using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ApiaryAPP.Views;

public partial class InspectionView : Window
{
    private ComboBox _comboBox;
    
    
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
        _comboBox = this.FindControl<ComboBox>("ComboBox");
    }

    private void CloseInspectionView(object sender, RoutedEventArgs e)
    {
        ((Window)this.VisualRoot).Close();

    }
}