using System;
using UnityEngine;

namespace FahodDev.Player
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D rb;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.velocity = Vector2.up * speed;
        }

        private void OnEnable()
        {
            Invoke(nameof(DeActive), 3f);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        private void DeActive()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.TryGetComponent<MeteorController>(out var meteor))
                return;
            
            meteor.OnReceiveHit();
        }
    }
}