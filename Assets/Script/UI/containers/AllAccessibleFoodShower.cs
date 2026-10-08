using Assets.Script.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.UI.containers
{
    public class AllAccessibleFoodShower : MonoBehaviour
    {
        [SerializeField] private GameObject prefabFoodShower;


        public void Start()
        {
            Reload();
        }

        public void Reload()
        {
            RemoveChildren();
            Populate();
        }

        public void Populate()
        {
            for (int i = 0; i < ManagerBus.FoodHolder.ItemAmount; i++)
            {
                GameObject child = Instantiate(prefabFoodShower, transform);
                IFoodDataShower foodShower = child.GetComponent<IFoodDataShower>();
                foodShower.CurFoodStruct = ManagerBus.FoodHolder.GetItemByIndex(i);
            }
        }

        public void RemoveChildren()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                GameObject child = transform.GetChild(i).gameObject;
                Destroy(child);
            }
        }
    }
}
