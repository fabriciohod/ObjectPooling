using System;
using System.Collections;
using FahodDev.PoolingSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FahodDev
{
    public class SpawnObjectInArea : MonoBehaviour
    {
        [SerializeField] private Vector2 size;
        [SerializeField] private ObjectPool objectPool;
        [SerializeField] private float timeBtwSpawn = 3f;

        private void OnEnable()
        {
            InvokeRepeating(nameof(SpawnObject),timeBtwSpawn, timeBtwSpawn / 2 );
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, size);
        }

        private void SpawnObject()
        {
            var pos = transform.position + new Vector3
            (
                Random.Range(-size.x / 2, size.x / 2),
                Random.Range(-size.y / 2, size.y / 2), 
                0
            );
            
            PoolingManager.SpawnObject(objectPool.PoolName, pos, Quaternion.identity);
        }
    }
}