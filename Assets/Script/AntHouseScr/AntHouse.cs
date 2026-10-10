using Assets.Script.AntScr;
using Assets.Script.Busses;
using Assets.Script.FoodRelatedScr;
using Assets.Script.StateMachineScr.StatesGrammarHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Script.AntHouseScr
{
    public class AntHouse: MonoBehaviour // works as constructor, atleast for now
    {
        [SerializeField] private Transform keyPoint;
        [SerializeField] public GameObject antPrefab;

        private List<AntBase> ants = new List<AntBase>();

        public Vector3 KeyPoint => keyPoint.position;

        private void OnEnable()
        {
            SignalBus.AntCreateRequest += SignalBus_AntCreateRequest;
            //
            SignalBus.FoodAppear += SignalBus_FoodAppear;
            SignalBus.FoodDisappear += SignalBus_FoodDisappear;
            StartTimer();
        }

        private void OnDisable()
        {
            SignalBus.AntCreateRequest -= SignalBus_AntCreateRequest;
            //
            SignalBus.FoodAppear -= SignalBus_FoodAppear;
            SignalBus.FoodDisappear -= SignalBus_FoodDisappear;
            StopTimer();
        }

        private void SignalBus_AntCreateRequest(AntStruct obj)
        {
            SpawnAnt(obj);
        }

        public void SpawnAnt(AntStruct data)
        {
            GameObject tmp = Instantiate(antPrefab, keyPoint.transform.position, Quaternion.identity); ;
            AntBase ant =  tmp.GetComponent<AntBase>();
            data.House = this;
            ant.LoadAntData(data);
            ants.Add(ant);
        }

        public List<AntBase> GetAnts() => ants;



        //I will leave this script here, at least for now
        [Header("Work assigning related script")]

        [SerializeField] private float TimeToAssignWork = 2f;

        private List<FoodBase> food = new List<FoodBase>();

        private void StartTimer() // does unity has timers?
        {
            InvokeRepeating(nameof(OnAssignWorkTimeout), TimeToAssignWork, TimeToAssignWork);
        }

        private void StopTimer()
        {
            CancelInvoke(nameof(OnAssignWorkTimeout)); // is it ok?
        }

        private void OnAssignWorkTimeout()
        {
            SharedBus.CustomDebugger.ShowInConsole("ant_house","Time to work little ones");
            if (food.Count <= 0) return;
            List<AntBase> accessibleAnts = GetAccessibleAnts();
            GiveThemWork(accessibleAnts);
        }

        private void GiveThemWork(List<AntBase> antsList)
        {
            // Basically will assign one ant to one food every timer timeout
            int n = 0;
            for (int i = 0; i < antsList.Count; i++)
            {
                antsList[i].ChangeTarget(food[n]);

                if (n >= food.Count - 1)
                {
                    n = 0;
                    continue;
                }
                n++;
            }
        }

        private List<AntBase> GetAccessibleAnts()
        {
            List<AntBase> ans = ants.Where(a => a.StateMachine.CurStateName == AntStateNames.IDLE_STATE).ToList();
            return ans != null ? ans: new List<AntBase>();
        }

        private void SignalBus_FoodDisappear(FoodBase obj)
        {
            if (food.Contains(obj)) food.Remove(obj);
        }

        private void SignalBus_FoodAppear(FoodBase obj)
        {
            food.Add(obj);
        }
    }
}
