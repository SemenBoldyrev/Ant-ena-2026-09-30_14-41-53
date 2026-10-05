using Assets.Script.AntScr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Script.StupidDataStoreges.Interfaces
{
    public interface IHaveAntsInside
    {
        public List<AntStruct> GetAntList();
        public void SetAntList(List<AntStruct> antList);
    }
}
