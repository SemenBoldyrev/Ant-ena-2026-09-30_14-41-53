using Assets.Script.AntScr;
using Assets.Script.Busses;
using Assets.Script.FoodRelatedScr;
using Assets.Script.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Script.UI.Buttons
{
    internal class ButtonRequestFoodCreation : MonoBehaviour, IFoodDataShower, IPointerClickHandler
    {
        [Tooltip("-1 for if you dont want to,\nany other id, if you want it to be shown")]
        [SerializeField] private int ovverideFoodInButton = -1;

        [SerializeField] private TMP_Text text;

        private FoodStruct curFoodDt;
        public FoodStruct CurFoodStruct { get => curFoodDt; set => ChangeFoodData(value); }

        private void ChangeFoodData(FoodStruct value)
        {
            curFoodDt = value;
            SetName(CurFoodStruct.Name);
        }

        private void Start()
        {
            if (ovverideFoodInButton < 0 && !ManagerBus.AntHolder.ContainsKey(ovverideFoodInButton)) return;

            CurFoodStruct = ManagerBus.FoodHolder.GetItemByIndex(ovverideFoodInButton);
        }

        private void SetName(string name)
        {
            text.text = name;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            try { SignalBus.FoodCreateRequestEmit(CurFoodStruct); } // i can use classes instead of structs, if they may be nullable (and i love nullables!)
            catch (Exception e) { SharedBus.CustomDebugger.ShowInConsole("req_but_food", e.Message); }

        }
    }
}
