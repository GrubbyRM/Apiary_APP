using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ApiaryAPP.DataAccess;
using ApiaryAPP.Models;
using ApiaryAPP.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;
using ReactiveUI;

namespace ApiaryAPP.ViewModels;

     public class InspectionCollection
     {
         private List<InspectionModel> inspections;
     
         public InspectionCollection()
         {
             inspections = new List<InspectionModel>();
         }
     
         public IEnumerable<InspectionModel> GetItems()
         {
             return inspections;
         }
     
         public void AddInspection(InspectionModel inspection)
         {
             inspections.Add(inspection);
         }
     }

public class MainWindowViewModel : ViewModelBase
{
    InspectionDataAccess dataAccess = new InspectionDataAccess();
    private string beehiveId;
    private string inspectionDate;
    private string queenBee;
    private string queenCells;
    private ObservableCollection<InspectionModel> inspections;
    private string inputBeehiveId;
    private InspectionModel inspectionData;
    private string inspectionDataText;
    
    private bool isShowButtonClicked;
    
    private InspectionDataAccess _db;

    public MainWindowViewModel()
    {
        var database_test = new InspectionDataAccess();
        inspections = new ObservableCollection<InspectionModel>();
        Ok = ReactiveCommand.Create<InspectionModel>(() =>
        {
            var inspection1 = new InspectionModel
            {
                beehiveId = BeehiveId,
                queenBee = QueenBee,
                inspectionDate = InspectionDate,
                queenCells = QueenCells
            };
            
            return inspection1;
        });

        Ok.Subscribe(inspection1 =>
        {
            database_test.AddInspection(inspection1);
        });

        Cancel = ReactiveCommand.Create(() => { });

        ShowCommand = ReactiveCommand.Create<string>(() =>
        {
            IsShowButtonClicked = true;
            var inspect = database_test.GetBeehiveNameById("Dzisiaj");
            InspectionDataText = inspect.ToString();
            return inspect;
        });
    }
    
    public string BeehiveId
    {
        get => beehiveId;
        set => this.RaiseAndSetIfChanged(ref beehiveId, value);
    }

    public string InspectionDate
    {
        get => inspectionDate;
        set => this.RaiseAndSetIfChanged(ref inspectionDate, value);
    }

    public string QueenBee
    {
        get => queenBee;
        set => this.RaiseAndSetIfChanged(ref queenBee, value);
    }

    public string QueenCells
    {
        get => queenCells;
        set => this.RaiseAndSetIfChanged(ref queenCells, value);
    }
    
    public ObservableCollection<InspectionModel> Inspections
         {
             get => inspections;
             set => this.RaiseAndSetIfChanged(ref inspections, value);
         }

    public string InputBeehiveId
    {
        get => inputBeehiveId;
        set => this.RaiseAndSetIfChanged(ref inputBeehiveId, value);
    }
    
    public InspectionModel InspectionData
    {
        get => inspectionData;
        set => this.RaiseAndSetIfChanged(ref inspectionData, value);
    }
    
    public string InspectionDataText
    {
        get => inspectionDataText;
        set => this.RaiseAndSetIfChanged(ref inspectionDataText, value);
    }
    
    public bool IsShowButtonClicked
    {
        get => isShowButtonClicked;
        set => this.RaiseAndSetIfChanged(ref isShowButtonClicked, value);
    }
    
    public ReactiveCommand<Unit, InspectionModel> Ok { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }
    public ReactiveCommand<Unit, string> ShowCommand { get; }

}