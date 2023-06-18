// using System.Reactive;
// using ApiaryAPP.DataAccess;
// using ApiaryAPP.Models;
// using ReactiveUI;
//
// namespace ApiaryAPP.ViewModels;
//
// public class ApiaryAPPViewModel : ViewModelBase
// {
//     InspectionDataAccess dataAccess = new InspectionDataAccess();
//     private string beehiveId;
//     private string inspectionDate;
//     private string queenBee;
//     private string queenCells;
//
//     public class ApiaryAPPViewModel : ViewModelBase
//     {
//         InspectionDataAccess dataAccess = new InspectionDataAccess();
//         private string beehiveId;
//         private string inspectionDate;
//         private string queenBee;
//         private string queenCells;
//
//         public ApiaryAPPViewModel()
//         {
//
//             Ok = ReactiveCommand.CreateFromTask<InspectionModel>(async () =>
//             {
//                 var inspection = new InspectionModel
//                 {
//                     BeehiveId = BeehiveId,
//                     InspectionDate = InspectionDate,
//                     QueenBee = QueenBee,
//                     QueenCells = QueenCells
//                 };
//
//                 await dataAccess.AddInspection(inspection);
//
//                 return inspection;
//             });
//
//             Cancel = ReactiveCommand.Create(() => { });
//         }
//
//         public string BeehiveId
//         {
//             get => beehiveId;
//             set => this.RaiseAndSetIfChanged(ref beehiveId, value);
//         }
//
//         public string InspectionDate
//         {
//             get => inspectionDate;
//             set => this.RaiseAndSetIfChanged(ref inspectionDate, value);
//         }
//
//         public string QueenBee
//         {
//             get => queenBee;
//             set => this.RaiseAndSetIfChanged(ref queenBee, value);
//         }
//
//         public string QueenCells
//         {
//             get => queenCells;
//             set => this.RaiseAndSetIfChanged(ref queenCells, value);
//         }
//
//         public ReactiveCommand<Unit, InspectionModel> Ok { get; }
//         public ReactiveCommand<Unit, Unit> Cancel { get; }
//     }
// }