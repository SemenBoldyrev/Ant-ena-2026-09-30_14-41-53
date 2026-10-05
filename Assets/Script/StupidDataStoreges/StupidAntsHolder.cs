using Assets.Script.AntScr;
using Assets.Script.StupidDataStoreges.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rubic1.Script.Shared.Sets.Interfaces;
using UnityEditor;
using UnityEngine;

namespace Assets.Script.StupidDataStoreges
{
    public class StupidAntsHolder: MonoBehaviour, IItemHolder<AntStruct>
    {
        [SerializeField] private List<AntStruct> antStructs = new List<AntStruct>();

        public int ItemAmount => Items.Count;

        public List<AntStruct> Items { get => antStructs; set => antStructs = value; }

        public bool ContainsKey(int key)
        {
            return key < Items.Count && 0 < key; //???
        }

        public AntStruct GetItemByIndex(int key)
        {
            return Items[key];
        }

        private void Awake()
        {
            ManagerBus.AntHolder = this; // keeping relevant, ok for this project
        }

        
    }
}
