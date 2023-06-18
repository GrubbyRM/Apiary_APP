using System.Threading.Tasks;
using ApiaryAPP.ViewModels;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace ApiaryAPP.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        // this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
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