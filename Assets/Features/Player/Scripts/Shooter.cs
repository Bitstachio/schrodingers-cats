using UnityEngine;

namespace Features.Player.Scripts
{
    public sealed class Shooter : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private GameObject bullet;

        private float _timer;

        //===== Lifecycle =====

        private void Update()
        {
            _timer += Time.deltaTime;
            if (!(_timer >= stats.bulletInterval)) return;

            var shot = Instantiate(bullet, transform.position, Quaternion.identity);
            if (shot.TryGetComponent<Bullet>(out var behaviour)) behaviour.Launch(Vector2.up, stats.bulletSpeed);

            _timer = 0f;
        }
    }
}