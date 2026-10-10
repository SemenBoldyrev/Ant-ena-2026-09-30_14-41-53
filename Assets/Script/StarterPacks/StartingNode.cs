using Assets.Script.Busses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.StarterPacks
{
    public class StartingNode: MonoBehaviour
    {
        private void Start()
        {
            SignalBus.AntCreateRequestEmit(ManagerBus.AntHolder.Items[0]); // so player will always have an ant
        }
    }
}
