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
    public MainWindowViewModel()
    {
        var inspectionWindow = new InspectionViewModel();
    }
    
    public InspectionViewModel inspectionWindow { get; }

}