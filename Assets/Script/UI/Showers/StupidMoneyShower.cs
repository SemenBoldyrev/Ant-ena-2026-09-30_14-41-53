using Assets.Script.Busses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Script.UI.Showers
{
    public class StupidMoneyShower: MonoBehaviour
    {
        [SerializeField] private TMP_Text textContainer;

        private void Awake()
        {
            SignalBus.FoodAmountChanged += SignalBus_FoodAmountChanged;
            textContainer.text = ManagerBus.MoneyStorage.CurMoneyAmount.ToString();
        }

        private void SignalBus_FoodAmountChanged(int obj)
        {
            textContainer.text = obj.ToString();
        }
    }
}
