using Assets.Script.AntScr;
using Assets.Script.FoodRelatedScr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.UI.Interfaces
{
    public interface IFoodDataShower
    {
        public FoodStruct CurFoodStruct { get; set; }
    }
}
