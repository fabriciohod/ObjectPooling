using System;
using UnityEngine;

namespace FahodDev.PoolingSystem
{
    [CreateAssetMenu(fileName = "NewObjectPool", menuName = "Create Object Pool", order = 0)]
    [Serializable]
    public class ObjectPool : ScriptableObject
    {
        [SerializeField] [InspectorName("Starting Quantity")]
        private int initCount;

        [SerializeField] private string poolName;
        [SerializeField] private bool canExpend = true;
        [SerializeField] private GameObject objectPrefab;

        public int InitCount => initCount;
        public bool CanExpend => canExpend;
        public string PoolName => poolName;
        public GameObject ObjectPrefab => objectPrefab;
    }
}