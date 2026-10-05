using Assets.Script.AntScr;
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

        public static void AntCreateRequestEmit(AntStruct data)
        {
            AntCreateRequest?.Invoke(data);
            SharedBus.CustomDebugger.ShowInConsole("signal_bus", $"AntCreateRequest emited: {data.Name}");
        }
    }
}
