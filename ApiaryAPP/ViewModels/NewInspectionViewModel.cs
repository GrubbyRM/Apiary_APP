// using System.IO;
// using System.Reactive;
// using System.Threading.Tasks;
// using ReactiveUI;
// using ApiaryAPP.DataAccess;
// using ApiaryAPP.Models;
// using MongoDB.Driver;
// using ZstdSharp.Unsafe;
// using ApiaryAPP.Views;
// using System.Collections.Generic;
// using System.Collections.ObjectModel;
// using ReactiveUI;
// using System.Reactive.Linq;
//
// namespace ApiaryAPP.ViewModels
// {
//     public class InspectionCollection
//     {
//         private List<InspectionModel> inspections;
//
//         public InspectionCollection()
//         {
//             inspections = new List<InspectionModel>();
//         }
//
//         public IEnumerable<InspectionModel> GetItems()
//         {
//             return inspections;
//         }
//
//         public void AddInspection(InspectionModel inspection)
//         {
//             inspections.Add(inspection);
//         }
//     }
//
//     public class NewInspectionViewModel : ViewModelBase
//     {
//         InspectionCollection inspectionCollection = new InspectionCollection();
//         private string beehiveId;
//         private string inspectionDate;
//         private string queenBee;
//         private string queenCells;
//         private ObservableCollection<InspectionModel> inspections;
//
//         public NewInspectionViewModel()
//         {
//             Ok = ReactiveCommand.Create<InspectionModel>(() =>
//             {
//                 var inspection = new InspectionModel
//                 {
//                     BeehiveId = BeehiveId,
//                     InspectionDate = InspectionDate,
//                     QueenBee = QueenBee,
//                     QueenCells = QueenCells
//                 };
//
//                 // Dodanie nowego elementu do kolekcji
//                 inspections.Add(inspection);
//                 Inspections = new ObservableCollection<InspectionModel>(inspections);
//
//                 // Zapisanie danych do pliku
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
//         public ObservableCollection<InspectionModel> Inspections
//         {
//             get => inspections;
//             set => this.RaiseAndSetIfChanged(ref inspections, value);
//         }
//
//         public ReactiveCommand<Unit, InspectionModel> Ok { get; }
//         public ReactiveCommand<Unit, Unit> Cancel { get; }
//         
//     }
// }
//
//
// // using System.Reactive;
// // using System.Threading.Tasks;
// // using ReactiveUI;
// // using ApiaryAPP.DataAccess;
// // using ApiaryAPP.Models;
// // using MongoDB.Driver;
// // using ZstdSharp.Unsafe;
// // using ApiaryAPP.Views;
// // using System.Collections.Generic;
// // using System.Collections.ObjectModel;
// // using ReactiveUI;
// // using System.Reactive.Linq;
// //
// // namespace ApiaryAPP.ViewModels
// // {
// //     
// //     public class InspectionCollection
// //     {
// //         private List<InspectionModel> inspections;
// //
// //         public InspectionCollection()
// //         {
// //             inspections = new List<InspectionModel>();
// //         }
// //
// //         public IEnumerable<InspectionModel> GetItems()
// //         {
// //             return inspections;
// //         }
// //
// //         public void AddInspection(InspectionModel inspection)
// //         {
// //             inspections.Add(inspection);
// //         }
// //     }
// //     public class NewInspectionViewModel : ViewModelBase
// //     {
// //
// //         InspectionCollection inspectionCollection = new InspectionCollection();
// //         private string beehiveId;
// //         private string inspectionDate;
// //         private string queenBee;
// //         private string queenCells;
// //         private ObservableCollection<InspectionModel> inspections;
// //
// //         public NewInspectionViewModel()
// //         {
// //             Ok = ReactiveCommand.Create<InspectionModel>(() =>
// //             {
// //                 var inspection = new InspectionModel
// //                 {
// //                     BeehiveId = BeehiveId,
// //                     InspectionDate = InspectionDate,
// //                     QueenBee = QueenBee,
// //                     QueenCells = QueenCells
// //                 };
// //
// //                 // Dodanie nowego elementu do kolekcji
// //                 inspections.Add(inspection);
// //                 
// //                 Inspections = new ObservableCollection<InspectionModel>(inspections);
// //                 return inspection;
// //             });
// //             ;
// //
// //             Cancel = ReactiveCommand.Create(() => { });
// //         }
// //
// //         public string BeehiveId
// //         {
// //             get => beehiveId;
// //             set => this.RaiseAndSetIfChanged(ref beehiveId, value);
// //         }
// //
// //         public string InspectionDate
// //         {
// //             get => inspectionDate;
// //             set => this.RaiseAndSetIfChanged(ref inspectionDate, value);
// //         }
// //
// //         public string QueenBee
// //         {
// //             get => queenBee;
// //             set => this.RaiseAndSetIfChanged(ref queenBee, value);
// //         }
// //
// //         public string QueenCells
// //         {
// //             get => queenCells;
// //             set => this.RaiseAndSetIfChanged(ref queenCells, value);
// //         }
// //         
// //         public ObservableCollection<InspectionModel> Inspections
// //         {
// //             get => inspections;
// //             set => this.RaiseAndSetIfChanged(ref inspections, value);
// //         }
// //
// //         public ReactiveCommand<Unit, InspectionModel> Ok { get; }
// //         public ReactiveCommand<Unit, Unit> Cancel { get; }
// //     }
// // }