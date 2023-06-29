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
using ApiaryAPP.Views;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MongoDB.Bson;
using MongoDB.Driver;
using ReactiveUI;
using System;

namespace ApiaryAPP.ViewModels;

public class InspectionViewModel : ViewModelBase
{
    private string _beehiveId;
    private DateTime _inspectionDate;
    private bool _queenBee;
    private bool _queenCells;
    private bool _eggs;
    private bool _openBrood;
    private bool _closedBrood;
    private bool _droneBrood;
    private bool _freshHoney;
    private bool _cappedHoney;
    private bool _beeBread;

    private int _frames;
    private int _beehiveBoxes;
    private int _honeyFrames;
    private int _broodFrames;
    private int _breadFrames;
    private int _waxFrames;

    private string _inspectionData;
    private bool _isShowButtonClicked;
    private int _inspectionIter;

    private ObservableCollection<string> _beehiveIds;
    private string _selectedBeehiveId;
    int currentIndex = 0;

    public InspectionViewModel()
    {
        var mongoDbConnection = new InspectionDataAccess();
        LoadBeehiveIdsFromDatabase();
        SaveInspection = ReactiveCommand.Create(() =>
            {
                var inspection = new InspectionModel
                {
                    beehiveId = BeehiveId,
                    inspectionDate = InspectionDate,
                    queenBee = QueenBee,
                    queenCells = QueenCells,
                    eggs = Eggs,
                    openBrood = OpenBrood,
                    closedBrood = ClosedBrood,
                    droneBrood = DroneBrood,
                    freshHoney = FreshHoney,
                    cappedHoney = CappedHoney,
                    beeBread = BeeBread,
                    frames = Frames,
                    beehiveBoxes = BeehiveBoxes,
                    honeyFrames = HoneyFrames,
                    broodFrames = BroodFrames,
                    breadFrames = BreadFrames,
                    waxFrames = WaxFrames
                };
                return inspection;
            }
        );

        SaveInspection.Subscribe(inspection => { mongoDbConnection.AddInspection(inspection); });

        ShowCommand = ReactiveCommand.Create(() =>
        {
            IsShowButtonClicked = true;
            // var frames = InspectionData;
            var inspections = mongoDbConnection.GetInspectionDataByBeehiveId(InspectionData);

            var i = inspections[0];
            IsShowButtonClicked = true;
            InspectionDate = i.inspectionDate;
            QueenBee = i.queenBee;
            QueenCells = i.queenCells;
            Eggs = i.eggs;
            OpenBrood = i.openBrood;
            ClosedBrood = i.closedBrood;
            DroneBrood = i.droneBrood;
            FreshHoney = i.freshHoney;
            CappedHoney = i.cappedHoney;
            BeeBread = i.beeBread;
            Frames = i.frames;
            BeehiveBoxes = i.beehiveBoxes;
            HoneyFrames = i.honeyFrames;
            BroodFrames = i.broodFrames;
            BreadFrames = i.breadFrames;
            WaxFrames = i.waxFrames;

            return inspections;
        });

        YesButtonClicked = ReactiveCommand.Create(() =>
        {
            currentIndex++;
            var inspections = mongoDbConnection.GetInspectionDataByBeehiveId(InspectionData);
            if (inspections.Count > 0)
            {
                Action onNextInspectionClicked = () =>
                {
                    Console.WriteLine(currentIndex);
                    if (currentIndex < inspections.Count)
                    {
                        var i = inspections[currentIndex];
                        UpdateInspectionData(i);
                    }
                };

                onNextInspectionClicked(); // Wyświetlenie pierwszej inspekcji

                YesButtonClicked.Subscribe(_ => onNextInspectionClicked());
            }
        });

        NoButtonClicked = ReactiveCommand.Create(() =>
        {
            currentIndex--;
            var frames = InspectionData;
            var inspections = mongoDbConnection.GetInspectionDataByBeehiveId(InspectionData);
            if (inspections.Count > 0)
            {
                // var currentIndex = 0;
                var i = inspections[currentIndex];

                UpdateInspectionData(i);

                Action onNextInspectionClicked = () =>
                {
                    // currentIndex--;
                    if (currentIndex >= 0)
                    {
                        i = inspections[currentIndex];
                        UpdateInspectionData(i);
                    }
                };

                NoButtonClicked.Subscribe(_ => onNextInspectionClicked());
            }
        });
    }

    private void UpdateInspectionData(InspectionModel inspection)
    {
        InspectionDate = inspection.inspectionDate;
        QueenBee = inspection.queenBee;
        QueenCells = inspection.queenCells;
        Eggs = inspection.eggs;
        OpenBrood = inspection.openBrood;
        ClosedBrood = inspection.closedBrood;
        DroneBrood = inspection.droneBrood;
        FreshHoney = inspection.freshHoney;
        CappedHoney = inspection.cappedHoney;
        BeeBread = inspection.beeBread;
        Frames = inspection.frames;
        BeehiveBoxes = inspection.beehiveBoxes;
        HoneyFrames = inspection.honeyFrames;
        BroodFrames = inspection.broodFrames;
        BreadFrames = inspection.breadFrames;
        WaxFrames = inspection.waxFrames;
    }


    public ReactiveCommand<Unit, InspectionModel> SaveInspection { get; }

    public string BeehiveId
    {
        get => _beehiveId;
        set => this.RaiseAndSetIfChanged(ref _beehiveId, value);
    }

    public DateTime InspectionDate
    {
        get => _inspectionDate;
        set => this.RaiseAndSetIfChanged(ref _inspectionDate, value);
    }

    public bool QueenBee
    {
        get => _queenBee;
        set => this.RaiseAndSetIfChanged(ref _queenBee, value);
    }

    public bool QueenCells
    {
        get => _queenCells;
        set => this.RaiseAndSetIfChanged(ref _queenCells, value);
    }

    public bool Eggs
    {
        get => _eggs;
        set => this.RaiseAndSetIfChanged(ref _eggs, value);
    }

    public bool OpenBrood
    {
        get => _openBrood;
        set => this.RaiseAndSetIfChanged(ref _openBrood, value);
    }

    public bool ClosedBrood
    {
        get => _closedBrood;
        set => this.RaiseAndSetIfChanged(ref _closedBrood, value);
    }

    public bool DroneBrood
    {
        get => _droneBrood;
        set => this.RaiseAndSetIfChanged(ref _droneBrood, value);
    }

    public bool FreshHoney
    {
        get => _freshHoney;
        set => this.RaiseAndSetIfChanged(ref _freshHoney, value);
    }

    public bool CappedHoney
    {
        get => _cappedHoney;
        set => this.RaiseAndSetIfChanged(ref _cappedHoney, value);
    }

    public bool BeeBread
    {
        get => _beeBread;
        set => this.RaiseAndSetIfChanged(ref _beeBread, value);
    }

    public int Frames
    {
        get => _frames;
        set => this.RaiseAndSetIfChanged(ref _frames, value);
    }

    public int BeehiveBoxes
    {
        get => _beehiveBoxes;
        set => this.RaiseAndSetIfChanged(ref _beehiveBoxes, value);
    }

    public int HoneyFrames
    {
        get => _honeyFrames;
        set => this.RaiseAndSetIfChanged(ref _honeyFrames, value);
    }

    public int BroodFrames
    {
        get => _broodFrames;
        set => this.RaiseAndSetIfChanged(ref _broodFrames, value);
    }

    public int BreadFrames
    {
        get => _breadFrames;
        set => this.RaiseAndSetIfChanged(ref _breadFrames, value);
    }

    public int WaxFrames
    {
        get => _waxFrames;
        set => this.RaiseAndSetIfChanged(ref _waxFrames, value);
    }

    public string InspectionData
    {
        get { return _inspectionData; }
        set => this.RaiseAndSetIfChanged(ref _inspectionData, value);
    }

    public bool IsShowButtonClicked
    {
        get => _isShowButtonClicked;
        set => this.RaiseAndSetIfChanged(ref _isShowButtonClicked, value);
    }

    public ObservableCollection<string> BeehiveIds
    {
        get => _beehiveIds;
        set => this.RaiseAndSetIfChanged(ref _beehiveIds, value);
    }

    public string SelectedBeehiveId
    {
        get => _selectedBeehiveId;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedBeehiveId, value);
            BeehiveId = value;
        }
    }

    private void LoadBeehiveIdsFromDatabase()
    {
        var mongoDbConnection = new ApiaryDataAccess();
        var beehiveIds = mongoDbConnection.GetDistinctBeehiveIds();
        BeehiveIds = new ObservableCollection<string>(beehiveIds);
        Console.WriteLine(BeehiveIds);
    }

    public ReactiveCommand<Unit, List<InspectionModel>> ShowCommand { get; }
    public ReactiveCommand<Unit, Unit> YesButtonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> NoButtonClicked { get; set; }
}