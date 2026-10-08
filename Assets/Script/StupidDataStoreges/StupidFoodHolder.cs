using Assets.Script.AntScr;
using Assets.Script.FoodRelatedScr;
using Rubic1.Script.Shared.Sets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.StupidDataStoreges
{
    public class StupidFoodHolder : MonoBehaviour, IItemHolder<FoodStruct>
    {
        [SerializeField] private List<FoodStruct> foodStructs = new List<FoodStruct>();

        public int ItemAmount => Items.Count;

        public List<FoodStruct> Items { get => foodStructs; set => foodStructs = value; }

        public bool ContainsKey(int key)
        {
            return key < Items.Count && 0 < key; //???
        }

        public FoodStruct GetItemByIndex(int key)
        {
            return Items[key];
        }

        private void Awake()
        {
            ManagerBus.FoodHolder = this; // keeping relevant, ok for this project
        }


    }
}
