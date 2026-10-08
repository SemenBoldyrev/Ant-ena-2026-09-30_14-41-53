using Assets.Script.Busses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Script.FoodRelatedScr
{
    public class FoodBase: MonoBehaviour
    {
        //[SerializeField] private bool destroyOnEmpty = false; Not now
        [SerializeField] private bool hideOnEmpty = false;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Transform pointOfInterest;

        private FoodStruct loadedFoodStruct = null;

        private int curFoodAmount = 0;

        public FoodStruct LoadedFoodStruct { get => loadedFoodStruct; }
        public Vector3 PointPosition { get => pointOfInterest.position; }

        public void LoadData(FoodStruct data)
        {
            if (data == loadedFoodStruct) return; // will not work properly, better with id check
            if (data == null)
            {
                Clear(); return;
            }

            loadedFoodStruct = data;
            curFoodAmount = loadedFoodStruct.FoodAmount;
            ChangeSpriteFoodBased();

            SignalBus.FoodAppearEmit(this);
        }

        private void Clear()
        {
            SignalBus.FoodDisappearEmit(this);

            spriteRenderer.sprite = null;
            curFoodAmount = 0;
        }

        private void ChangeSpriteFoodBased()
        {
            if (loadedFoodStruct == null) return;

            int nextSprite = loadedFoodStruct.Sprites.Count - (int)(((float)curFoodAmount / (float)loadedFoodStruct.FoodAmount) * loadedFoodStruct.Sprites.Count);

            if (hideOnEmpty && nextSprite == loadedFoodStruct.Sprites.Count)
            {
                Clear();
            }

            Debug.Log(nextSprite);
            spriteRenderer.sprite = loadedFoodStruct.Sprites[nextSprite]; // it will ramain as integer because a and b are?
        }

        public bool HasFood()
        {
            return curFoodAmount > 0; 
        }

        public int TakeFood(int food)
        {
            if (!HasFood()) return 0;

            int toGive;
            if (food > curFoodAmount)
            {
                toGive = curFoodAmount;
            }
            else
            {
                toGive = food;
            }
            curFoodAmount -= toGive;

            ChangeSpriteFoodBased();

            return toGive;
        }
    }
}
