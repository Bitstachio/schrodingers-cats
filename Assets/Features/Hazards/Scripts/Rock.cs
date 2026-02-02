using UnityEngine;

namespace Features.Hazards.Scripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public sealed class Rock : MonoBehaviour
    {
        [SerializeField] private float targetBounceHeight = 5f;

        private Rigidbody2D _rb;

        //===== Lifecycle =====

        private void Awake() => _rb = GetComponent<Rigidbody2D>();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Ground")) ApplyKineticImpulse();
            else if (other.transform.CompareTag("Bullet"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }

        //===== Utilities =====

        // Applies a bounce such that the object always goes up to a fixed height
        private void ApplyKineticImpulse()
        {
            var gravity = Mathf.Abs(Physics2D.gravity.y * _rb.gravityScale);
            var requiredVelocity = Mathf.Sqrt(2 * gravity * targetBounceHeight);
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, requiredVelocity);
        }
    }
}