using Assets.Script.AntScr;
using Assets.Script.FoodRelatedScr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Busses
{
    public static class SignalBus
    {
        public static event Action<AntStruct> AntCreateRequest;
        public static event Action<FoodStruct> FoodCreateRequest;

        public static event Action<FoodBase> FoodAppear;
        public static event Action<FoodBase> FoodDisappear;

        public static event Action<int> GiveFood;
        public static event Action<int> TakeFood;
        public static event Action<int> FoodAmountChanged;

        public static void AntCreateRequestEmit(AntStruct data)
        {
            AntCreateRequest?.Invoke(data);
            SharedBus.CustomDebugger.ShowInConsole("signal_bus", $"AntCreateRequest emited: {data.Name}");
        }

        public static void FoodCreateRequestEmit(FoodStruct data)
        {
            FoodCreateRequest?.Invoke(data);
            SharedBus.CustomDebugger.ShowInConsole("signal_bus", $"FoodCreateRequest emited: {data.Name}");
        }

        public static void FoodAppearEmit(FoodBase data)
        {
            FoodAppear?.Invoke(data);
            SharedBus.CustomDebugger.ShowInConsole("signal_bus", $"FoodAppear emited: {data.LoadedFoodStruct.Name}");
        }

        public static void FoodDisappearEmit(FoodBase data)
        {
            FoodDisappear?.Invoke(data);
            SharedBus.CustomDebugger.ShowInConsole("signal_bus", $"FoodDisappear emited: {data.LoadedFoodStruct.Name}");
        }

        public static void GiveFoodEmit(int data)
        {
            GiveFood?.Invoke(data);
            SharedBus.CustomDebugger.ShowInConsole("signal_bus", $"GiveFood emited: {data}");
        }

        public static void TakeFoodEmit(int data)
        {
            TakeFood?.Invoke(data);
            SharedBus.CustomDebugger.ShowInConsole("signal_bus", $"TakeFood emited: {data}");
        }

        public static void FoodAmountChangedEmit(int data)
        {
            FoodAmountChanged?.Invoke(data);
            SharedBus.CustomDebugger.ShowInConsole("signal_bus", $"FoodAmountChanged emited: {data}");
        }
    }
}
