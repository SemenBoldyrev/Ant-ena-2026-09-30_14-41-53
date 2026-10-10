using Assets.Script.AntScr;
using Assets.Script.Busses;
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
    public class ButtonRequestAntCreationCapitalistic : MonoBehaviour, IAntDataShower, IPointerClickHandler
    {
        //!
        // May be better as abs class
        //!

        [Tooltip("-1 for if you dont want to,\nany other id, if you want it to be shown")]
        [SerializeField] private int ovverideAntInButton = -1;

        [SerializeField] private TMP_Text text;
        [SerializeField] private TMP_Text priceText;

        private AntStruct curAntDt;
        public AntStruct CurAntStruct { get => curAntDt; set => ChangeAntData(value); }

        private void ChangeAntData(AntStruct value)
        {
            curAntDt = value;
            SetName(CurAntStruct.Name);
            SetPrice(CurAntStruct.Price);
        }

        private void SetPrice(int price)
        {
            priceText.text = price.ToString();
        }

        private void Start()
        {
            if (ovverideAntInButton < 0 && !ManagerBus.AntHolder.ContainsKey(ovverideAntInButton)) return;

            CurAntStruct = ManagerBus.AntHolder.GetItemByIndex(ovverideAntInButton);
        }

        private void SetName(string name)
        {
            text.text = name;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (ManagerBus.MoneyStorage.CanSpent(CurAntStruct.Price))
            {
                ManagerBus.MoneyStorage.RemoveMoney(CurAntStruct.Price);
                SignalBus.AntCreateRequestEmit(CurAntStruct);
            }
            //try { SignalBus.AntCreateRequestEmit(CurAntStruct); } // I need to read about nullable types
            //catch (Exception e) { SharedBus.CustomDebugger.ShowInConsole("req_but_ant", e.Message); }

        }
    }
}
