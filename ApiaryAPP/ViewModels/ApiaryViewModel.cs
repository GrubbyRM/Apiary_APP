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
    private string _apiaryData;
    private bool _isShowButtonClicked;

    private string _beehiveIdApiaryShow;
    private string _queenBeeApiaryShow;
    private int _queenBeeYearShow;
    private string _queenBeeProviderShow;
    private string _queenBeeTypeShow;

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

        SaveBeehive.Subscribe(beehive => { mongoDbConnection.AddBeehive(beehive); });

        DeleteBeehive = ReactiveCommand.Create(() => { mongoDbConnection.DeleteByBeehiveId(BeehiveId); });

        ShowCommand = ReactiveCommand.Create(() =>
        {
            IsShowButtonClicked = true;
            var beehives = mongoDbConnection.GetApiary();
            var b = beehives[0];
            BeehiveId = b.beehiveId;
            QueenBee = b.queenBee;
            QueenBeeYear = b.queenBeeYear;
            QueenBeeProvider = b.queenBeeProvider;
            QueenBeeType = b.queenBeeType;

            return beehives;
        });
        YesButtonClicked = ReactiveCommand.Create(() =>
        {
            var inspections = mongoDbConnection.GetApiary();
            if (inspections.Count > 0)
            {
                var currentIndex = 0;
                var i = inspections[currentIndex];

                UpdateApiaryData(i);

                Action onNextInspectionClicked = () =>
                {
                    currentIndex++;
                    if (currentIndex < inspections.Count)
                    {
                        Console.WriteLine(i.beehiveId);
                        i = inspections[currentIndex];
                        UpdateApiaryData(i);
                    }
                };

                YesButtonClicked.Subscribe(_ => onNextInspectionClicked());
            }
        });

        NoButtonClicked = ReactiveCommand.Create(() =>
        {
            var beehives = mongoDbConnection.GetApiary();
            if (beehives.Count > 0)
            {
                var currentIndex = 0;
                var i = beehives[currentIndex];

                UpdateApiaryData(i);

                Action onNextInspectionClicked = () =>
                {
                    currentIndex--;
                    if (currentIndex >= 0)
                    {
                        i = beehives[currentIndex];
                        UpdateApiaryData(i);
                    }
                };

                NoButtonClicked.Subscribe(_ => onNextInspectionClicked());
            }
        });
        //TODO: Update Beehive
    }

    private void UpdateApiaryData(ApiaryModel beehive)
    {
        BeehiveId = beehive.beehiveId;
        QueenBee = beehive.queenBee;
        QueenBeeYear = beehive.queenBeeYear;
        QueenBeeProvider = beehive.queenBeeProvider;
        QueenBeeType = beehive.queenBeeType;
    }

    public ReactiveCommand<Unit, ApiaryModel> SaveBeehive { get; }
    public ReactiveCommand<Unit, Unit> DeleteBeehive { get; set; }
    public ReactiveCommand<Unit, List<ApiaryModel>> ShowCommand { get; }

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

    public string ApiaryData
    {
        get { return _apiaryData; }
        set => this.RaiseAndSetIfChanged(ref _apiaryData, value);
    }

    public bool IsShowButtonClicked
    {
        get => _isShowButtonClicked;
        set => this.RaiseAndSetIfChanged(ref _isShowButtonClicked, value);
    }

    public ReactiveCommand<Unit, Unit> YesButtonClicked { get; set; }
    public ReactiveCommand<Unit, Unit> NoButtonClicked { get; set; }
}