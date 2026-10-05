using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.CustomDebug
{
    public interface ICustomDebugger
    {
        public void ShowInConsole(string key, string msg);
    }
}
