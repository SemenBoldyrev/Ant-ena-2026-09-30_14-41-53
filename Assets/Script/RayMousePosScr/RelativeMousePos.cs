using Assets.Script.RayMousePosScr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Script.RayMousePosScr
{
    public class RelativeMousePos: IRelativeMousePos
    {
        Camera cam;

        public Vector3 GetRalativeMousePosition()
        {
            if (cam == null)
            {
                try { cam = Camera.main; }
                catch { return Vector3.zero; }
            }

            Vector3 target = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            target.z = 0;

            return target;
        }

    }
}
