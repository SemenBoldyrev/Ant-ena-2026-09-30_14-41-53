using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Script.CustomDebug
{
    public class CustomDebugger : ICustomDebugger
    {
        public void ShowInConsole(string key, string msg)
        {
            Debug.Log($"[{key.ToUpper()}] {msg}");
        }
    }
}
