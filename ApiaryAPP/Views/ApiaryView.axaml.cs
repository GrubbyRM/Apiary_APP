using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ApiaryAPP.Views;

public partial class ApiaryView : Window
{
    public ApiaryView()
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