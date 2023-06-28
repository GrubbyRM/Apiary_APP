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

    public InspectionViewModel()
    {
        var mongoDbConnection = new InspectionDataAccess();
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

        SaveInspection.Subscribe(inspection =>
        {
            mongoDbConnection.AddInspection(inspection);
        });

        ShowCommand = ReactiveCommand.Create(() =>
        {
            IsShowButtonClicked = true;
            var frames = InspectionData;
            var inspections = mongoDbConnection.GetInspectionDataByBeehiveId(InspectionData);

            foreach (var i in inspections)
            {
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
            }

            return inspections;
        });

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
    public int InspectionIter
    {
        get => _inspectionIter;
        set => this.RaiseAndSetIfChanged(ref _inspectionIter, value);
    }
    public ReactiveCommand<Unit, List<InspectionModel>> ShowCommand { get; }
}