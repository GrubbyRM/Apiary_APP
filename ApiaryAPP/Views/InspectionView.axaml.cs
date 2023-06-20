using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ApiaryAPP.Views;

public partial class InspectionView : Window
{
    public InspectionView()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}