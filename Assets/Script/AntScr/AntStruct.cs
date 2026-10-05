using Assets.Script.AntHouseScr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.AntScr
{
    [System.Serializable]
    public struct AntStruct
    {
        [SerializeField] private string name;
        [SerializeField] private float speed;

        private AntHouse antHouse;

        //

        public string Name { get { return name; } set { name = value; } }
        public float Speed { get { return speed; } set { speed = value; } }
        public AntHouse House { get { return antHouse; } set { antHouse = value; } }
    }
}
