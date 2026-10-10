using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.MoneyStorageScr.Interface
{
    public interface IMoneyStorage
    {
        public int CurMoneyAmount { get; }

        public void AddMoney(int amount);
        public void RemoveMoney(int amount);

        public bool CanSpent(int amount);
    }
}
