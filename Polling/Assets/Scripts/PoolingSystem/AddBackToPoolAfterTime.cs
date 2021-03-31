using UnityEngine;

namespace FahodDev.PoolingSystem
{
    public class AddBackToPoolAfterTime : MonoBehaviour
    {
        [SerializeField] private ObjectPool pool;
        [SerializeField] private float timeInSeconds = 3f;

        private void OnEnable()
        {
            Invoke(nameof(AddBackToPool), timeInSeconds);
        }

        private void AddBackToPool()
        {
            PoolingManager.AddObjectToPool(pool.PoolName, gameObject);
        }
    }
}