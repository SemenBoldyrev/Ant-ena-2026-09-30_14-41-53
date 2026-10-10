using Assets.Script.Busses;
using Assets.Script.MoneyStorageScr.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.MoneyStorageScr
{
    public class MoneyStorage : IMoneyStorage
    {
        private int curMoneyAmount = 0;
        public int CurMoneyAmount => curMoneyAmount;

        public MoneyStorage()
        {
            SignalBus.GiveFood += SignalBus_GiveFood;
            SignalBus.TakeFood += SignalBus_TakeFood;
        }

        private void SignalBus_TakeFood(int obj)
        {
            RemoveMoney(obj);
        }

        private void SignalBus_GiveFood(int obj)
        {
            AddMoney(obj);
        }

        public void AddMoney(int amount)
        {
            if (amount <= 0) return;
            curMoneyAmount += amount;
            SignalBus.FoodAmountChangedEmit(curMoneyAmount);
        }

        public void RemoveMoney(int amount)
        {
            if (amount <= 0) return;
            if (amount > curMoneyAmount) curMoneyAmount = 0;
            curMoneyAmount -= amount;
            SignalBus.FoodAmountChangedEmit(curMoneyAmount);
        }

        public bool CanSpent(int amount)
        {
            return curMoneyAmount >= amount;
        }
    }
}
