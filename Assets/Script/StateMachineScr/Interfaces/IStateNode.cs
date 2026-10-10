using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.StateMachineScr.Interfaces
{
    public interface IStateNode
    {
        public string StateName { get; }

        public event Action<string> RequestStateChange;
        public event Action Finished;

        public void OnStart();
        public void OnExit(); // this is optional, but needed for state forsing
        public void OnUpdate();
        //public void OnInput(); // does it really needed, especially in unity?
    }
}
