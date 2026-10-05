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
using UnityEngine.UI;

namespace Assets.Script.UI.Buttons
{
    public class ButtonRequestAntCreation: MonoBehaviour, IAntDataShower, IPointerClickHandler
    {
        [SerializeField] private int ovverideAntInButton = -1;

        [SerializeField] private TMP_Text text;

        private AntStruct curAntDt;
        public AntStruct CurAntStruct { get => curAntDt; set => ChangeAntData(value); }

        private void ChangeAntData(AntStruct value)
        {
            curAntDt = value;
            SetName(CurAntStruct.Name);
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

        public void OnPress()
        {

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            try { SignalBus.AntCreateRequestEmit(CurAntStruct); } // I need to read about nullable types
            catch (Exception e) { SharedBus.CustomDebugger.ShowInConsole("req_but", e.Message); }
            
        }
    }
}
