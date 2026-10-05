using Assets.Script.CustomDebug;
using Assets.Script.RayMousePosScr;
using Assets.Script.RayMousePosScr.Interfaces;
using Assets.Script.StupidMathScr;
using Assets.Script.StupidMathScr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Busses
{
    public static class SharedBus
    {
        private static IRelativeMousePos relativeMousePos = new RelativeMousePos();
        private static IStupidMath stupidMath = new StupidMath();
        private static ICustomDebugger customDebugger = new CustomDebugger();

        public static IRelativeMousePos RelativeMousePos => relativeMousePos;
        public static IStupidMath StupidMath => stupidMath;
        public static ICustomDebugger CustomDebugger => customDebugger;
    }
}
