using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.StupidMathScr.Interfaces
{
    public interface IStupidMath
    {
        //No out? do i need out? do YOU need it?
        public Vector3 VectorTo(Vector3 from, Vector3 to);
        public float AngleTo(Vector3 from, Vector3 to);
        public float NormalVectorAngle(Vector3 vec);
    }
}
