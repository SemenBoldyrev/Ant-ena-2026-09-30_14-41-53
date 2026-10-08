using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.FoodRelatedScr
{
    [Serializable]
    public class FoodStruct //so i could nullify it, sadly needs to be monobehavior then
    {
        [SerializeField] private string structName;
        [SerializeField] private int foodAmount;
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private bool destroyOnEmpty;


        public string Name { get => structName; set => structName = value; }
        public int FoodAmount { get => foodAmount; set => foodAmount = value; }
        public List<Sprite> Sprites { get => sprites; set => sprites = value; }
        public bool DestroyOnEmpty { get => destroyOnEmpty; set => destroyOnEmpty = value; }
    }
}
