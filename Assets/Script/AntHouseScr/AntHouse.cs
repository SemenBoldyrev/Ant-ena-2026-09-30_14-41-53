using Assets.Script.AntScr;
using Assets.Script.Busses;
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

        private void OnEnable()
        {
            SignalBus.AntCreateRequest += SignalBus_AntCreateRequest;
        }

        private void OnDisable()
        {
            SignalBus.AntCreateRequest -= SignalBus_AntCreateRequest;
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
    }
}
