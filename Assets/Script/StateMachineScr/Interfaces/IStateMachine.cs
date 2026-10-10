using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.StateMachineScr.Interfaces
{
    public interface IStateMachine
    {
        public bool IsActirve { get; set; }
        public IStateNode CurState { get; }
        public string CurStateName { get; }
        //public bool ForceChangeStateTo(string stateName); // i wont set it as setter for CurState, so it will be understandable
    }
}
