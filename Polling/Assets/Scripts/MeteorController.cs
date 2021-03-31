using FahodDev.PoolingSystem;
using UnityEngine;

namespace FahodDev
{
    public class MeteorController : MonoBehaviour
    {
        [SerializeField] private ObjectPool objectPool;

        public void OnReceiveHit()
        {
            PoolingManager.AddObjectToPool(objectPool.PoolName, gameObject);
        }
    }
}