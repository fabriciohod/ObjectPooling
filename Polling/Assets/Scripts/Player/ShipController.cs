using UnityEngine;

namespace FahodDev.Player
{
    public class ShipController : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        private Vector3 movementVector;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            movementVector.x = Input.GetAxisRaw("Horizontal");
            movementVector.y = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            rb.velocity = (Vector2) movementVector * speed;
        }
    }
}