using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiaryAPP.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using MainWindowViewModel = ApiaryAPP.ViewModels.MainWindowViewModel;

namespace ApiaryAPP.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    private readonly List<Window> _windows = new();
    private ContentControl contentContainer;
    private Window _mainWindow;
    private DockPanel _windowContainer;
    
    public MainWindow()
    {
        InitializeComponent();
        // _mainWindow = this;
        // _windowContainer = new DockPanel();
        // Content = _windowContainer;
        // contentContainer = this.Find<ContentControl>("contentContainer");
        // this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        // _windowContainer = this.Find<DockPanel>("windowContainer");
        // _mainWindow = this;
        // Content = _windowContainer;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private void NewInspection(object sender, RoutedEventArgs e)
    {
        var window = new InspectionView()
        {
            DataContext = new InspectionViewModel(),
            Width = 360,
            Height = 900,
            // CanResize = false
        };
        window.Show();
        window.Activate();
    }

    private void History(object sender, RoutedEventArgs e)
    {
        var window = new HistoryView()
        {
            DataContext = new InspectionViewModel(),
        };
        window.Show();
        window.Activate();
    }
    
    

    private void NewInspection2(object sender, RoutedEventArgs e)
    {
        var inspection = this.FindControl<Button>("NewInspection");
        inspection.IsVisible = false;
    }

    // private async Task DoShowDialogAsync(InteractionContext<ApiaryAPPViewModel, NewInspectionViewModel?> interaction)
    // {
    //     var inspection = new NewInspectionWindow();
    //     inspection.DataContext = interaction.Input;
    //
    //     var result = await inspection.ShowDialog<NewInspectionViewModel?>(this);
    //     interaction.SetOutput(result);
    // }
}