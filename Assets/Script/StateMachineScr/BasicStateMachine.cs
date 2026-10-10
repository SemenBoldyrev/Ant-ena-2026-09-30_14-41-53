using Assets.Script.StateMachineScr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.StateMachineScr
{
    public class BasicStateMachine: MonoBehaviour, IStateMachine
    {
        [SerializeField] private MonoBehaviour initialStateNode; 
        // if its work, i may change to unity
        // p.s. no, it still cant access nodes as interfaces :(


        private Dictionary<string, IStateNode> states = new();


        private bool isActive = false;
        public bool IsActirve { get => isActive; set => isActive = value; }


        private IStateNode curState = null;
        public IStateNode CurState => curState;
        public string CurStateName => curState.StateName;


        private IStateNode nextState;


        private void Start()
        {
            InitializeStates();
            EnterState(initialStateNode.GetComponent<IStateNode>());
        }

        private void Update()
        {
            if (!IsActirve || CurState == null) return;
            CurState.OnUpdate();
        }

        private void InitializeStates()
        {
            IStateNode[] stateNodes = this.GetComponentsInChildren<IStateNode>();

            states.Clear();
            for (int i = 0; i < stateNodes.Length; i++)
            {
                states[stateNodes[i].StateName] = stateNodes[i];
            }
        }

        private void EnterState(IStateNode state)
        {
            curState = state;

            ConnectState(state);

            state.OnStart();
        }

        private void ConnectState(IStateNode state)
        {
            state.RequestStateChange += OnStateChangeRequest;
            state.Finished += OnStateFinished;
        }

        private void DisconnectState(IStateNode state)
        {
            state.RequestStateChange -= OnStateChangeRequest;
            state.Finished -= OnStateFinished;
        }

        private void OnStateChangeRequest(string nextStateName)
        {
            if (!states.ContainsKey(nextStateName)) return;

            nextState = states[nextStateName];
            CurState.OnExit();
        }

        private void OnStateFinished()
        {
            if (nextState == null)
            {
                return; // maybe signal to debuger too
            }

            DisconnectState(curState);
            EnterState(nextState);
            nextState = null;
        }
    }
}
