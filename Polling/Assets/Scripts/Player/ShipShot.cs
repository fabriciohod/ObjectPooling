using FahodDev.PoolingSystem;
using UnityEngine;

namespace FahodDev.Player
{
    public class ShipShot : MonoBehaviour
    {
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] private Transform[] firePoint;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) InvokeRepeating(nameof(Shot), fireRate, fireRate);

            if (Input.GetKeyUp(KeyCode.Space)) CancelInvoke(nameof(Shot));
        }

        private void Shot()
        {
            for (var i = 0; i < firePoint.Length; i++)
                PoolingManager.SpawnObject("Bullets", firePoint[i].position, Quaternion.identity);
        }
    }
}