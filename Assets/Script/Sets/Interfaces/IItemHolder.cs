using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubic1.Script.Shared.Sets.Interfaces
{
    public interface IItemHolder<T>
    {
        int ItemAmount { get; }
        List<T> Items { get; set; }
        public T GetItemByIndex(int key);
        public bool ContainsKey(int key);
    }
}
