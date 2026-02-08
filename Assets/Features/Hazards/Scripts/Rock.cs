using UnityEngine;

namespace Features.Hazards.Scripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public sealed class Rock : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag("Bullet")) return;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}