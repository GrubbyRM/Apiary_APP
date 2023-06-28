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

namespace ApiaryAPP.ViewModels;

public class ApiaryViewModel : ViewModelBase
{
    private string _beehiveIdApiary;
    private string _queenBeeApiary;
    private int _queenBeeYear;
    private string _queenBeeProvider;
    private string _queenBeeType;

    public ApiaryViewModel()
    {
        var mongoDbConnection = new ApiaryDataAccess();
        SaveBeehive = ReactiveCommand.Create(() =>
        {
            var beehive = new ApiaryModel
            {
                beehiveId = BeehiveId,
                queenBee = QueenBee,
                queenBeeYear = QueenBeeYear,
                queenBeeProvider = QueenBeeProvider,
                queenBeeType = QueenBeeType
            };
            return beehive;
        });

        SaveBeehive.Subscribe(beehive =>
        {
            mongoDbConnection.AddBeehive(beehive);
        });
        //TODO: Delete Beehive
        //TODO: Update Beehive
    }
    
    public ReactiveCommand<Unit, ApiaryModel> SaveBeehive { get; }
    public string BeehiveId
    {
        get => this._beehiveIdApiary;
        set => this.RaiseAndSetIfChanged(ref _beehiveIdApiary, value);
    }
    public string QueenBee
    {
        get => _queenBeeApiary;
        set => this.RaiseAndSetIfChanged(ref _queenBeeApiary, value);
    }
    public int QueenBeeYear
    {
        get => _queenBeeYear;
        set => this.RaiseAndSetIfChanged(ref _queenBeeYear, value);
    }

    public string QueenBeeProvider
    {
        get => _queenBeeProvider;
        set => this.RaiseAndSetIfChanged(ref _queenBeeProvider, value);
    }

    public string QueenBeeType
    {
        get => _queenBeeType;
        set => this.RaiseAndSetIfChanged(ref _queenBeeType, value);
    }
}