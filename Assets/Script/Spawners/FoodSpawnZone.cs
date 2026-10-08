using Assets.Script.Busses;
using Assets.Script.FoodRelatedScr;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Spawners
{
    public class FoodSpawnZone: MonoBehaviour
    {
        [SerializeField] private Collider2D spawnZone;
        [SerializeField] private GameObject foodPrefab;

        private List<FoodBase> spawnedFood = new(); // if something...

        public List<FoodBase> SpawnedFood { get => spawnedFood; }

        private void OnEnable()
        {
            SignalBus.FoodCreateRequest += SignalBus_FoodCreateRequest;
        }

        private void OnDisable() // maybe not the best for this
        {
            SignalBus.FoodCreateRequest += SignalBus_FoodCreateRequest;
        }

        private void SignalBus_FoodCreateRequest(FoodRelatedScr.FoodStruct obj)
        {
            SpawnFood(obj);
        }

        private Vector3 RandomDotInCollider()
        {
            Bounds bounds = spawnZone.bounds;

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);

            return new Vector3(randomX, randomY, randomZ);
        }

        private void SpawnFood(FoodStruct data)
        {
            GameObject tmp = Instantiate(foodPrefab, RandomDotInCollider(), Quaternion.identity); ;
            FoodBase food = tmp.GetComponent<FoodBase>();
            food.LoadData(data);
            spawnedFood.Add(food);
        }
    }
}
