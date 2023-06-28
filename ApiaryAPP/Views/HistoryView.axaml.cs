using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ApiaryAPP.ViewModels;
using ApiaryAPP.Models;
using ApiaryAPP.Views;


namespace ApiaryAPP.Views;

public partial class HistoryView : Window
{
    public HistoryView()
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
    
    private int currentIndex = 0;
    



}