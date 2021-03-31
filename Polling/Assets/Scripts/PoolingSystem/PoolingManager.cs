using System.Collections.Generic;
using UnityEngine;

namespace FahodDev.PoolingSystem
{
    public class PoolingManager : MonoBehaviour
    {
        [SerializeField] private List<ObjectPool> objectPools = new List<ObjectPool>();

        private readonly Dictionary<string, Queue<GameObject>> ObjectsInstance =
            new Dictionary<string, Queue<GameObject>>();

        public static PoolingManager Instance { get; private set; }

        private void Awake()
        {
            if (!(Instance is null) && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            foreach (var pool in objectPools)
            {
                var tempQueue = new Queue<GameObject>();

                for (var j = 0; j < pool.InitCount; j++)
                {
                    var obj = Instantiate(pool.ObjectPrefab);
                    obj.SetActive(false);
                    tempQueue.Enqueue(obj);
                }

                ObjectsInstance.Add(pool.PoolName, tempQueue);
            }
        }

        public static void SpawnObject(string poolName, Vector3 position, Quaternion rotation)
        {
            var queue = Instance.ObjectsInstance[poolName];

            if (queue.Count > 0)
            {
                var obj = queue.Dequeue();

                obj.transform.position = position;
                obj.transform.rotation = rotation;

                obj.SetActive(true);
                return;
            }

            if (!Instance.PoolCanExpand(poolName)) return;

            Instantiate(Instance.GetPool(poolName).ObjectPrefab, position, rotation);
        }

        public static void AddObjectToPool(string poolName, GameObject obj)
        {
            obj.SetActive(false);
            Instance.ObjectsInstance[poolName].Enqueue(obj);
        }

        private bool PoolCanExpand(string poolName)
        {
            return GetPool(poolName).CanExpend;
        }

        private ObjectPool GetPool(string poolName)
        {
            return objectPools.Find(pool => pool.PoolName == poolName);
        }
    }
}