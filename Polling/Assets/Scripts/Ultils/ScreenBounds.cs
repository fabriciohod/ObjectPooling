using UnityEngine;

namespace FahodDev.Ultils
{
    public class ScreenBounds : MonoBehaviour
    {
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (mainCamera is null) return;

            var position = transform.position;

            var xAxisClamped = Mathf.Clamp(
                position.x,
                mainCamera.ViewportToWorldPoint(Vector3.zero).x,
                mainCamera.ViewportToWorldPoint(Vector3.one).x
            );

            var yAxisClamped = Mathf.Clamp(
                position.y,
                mainCamera.ViewportToWorldPoint(Vector3.zero).y,
                mainCamera.ViewportToWorldPoint(Vector3.one).y
            );

            position = new Vector3(xAxisClamped, yAxisClamped, 0);
            transform.position = position;
        }
    }
}