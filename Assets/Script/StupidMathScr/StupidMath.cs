using Assets.Script.StupidMathScr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.StupidMathScr
{
    public class StupidMath : IStupidMath
    {
        //partly done by ai
        public float AngleTo(Vector3 from, Vector3 to)
        {
            return Vector3.Angle(from, to);
        }

        public float NormalVectorAngle(Vector3 vec)
        {
            // probably worst one here
            return Vector2.SignedAngle(Vector3.up, vec);
        }

        public Vector3 VectorTo(Vector3 from, Vector3 to)
        {
            //idk, just for beeing here
            return to - from;
        }


    }
}
