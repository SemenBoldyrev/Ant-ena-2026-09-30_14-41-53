using Assets.Script.AntScr;
using Assets.Script.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Script.UI.containers
{
    public class AllAccesibleAntsShower: MonoBehaviour
    {
        [SerializeField] private GameObject prefabAntShower;


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
            for (int i = 0; i < ManagerBus.AntHolder.ItemAmount; i++)
            {
                GameObject child = Instantiate(prefabAntShower, transform);
                IAntDataShower antShower = child.GetComponent<IAntDataShower>();
                antShower.CurAntStruct = ManagerBus.AntHolder.GetItemByIndex(i);
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
