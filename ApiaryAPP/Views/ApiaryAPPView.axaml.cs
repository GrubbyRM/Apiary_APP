using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ApiaryAPP.Views;

public partial class ApiaryAPPView : UserControl
{
    public ApiaryAPPView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}