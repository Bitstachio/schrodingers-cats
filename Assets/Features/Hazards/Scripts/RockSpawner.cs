using Shared.Providers;
using UnityEngine;

namespace Features.Hazards.Scripts
{
    public sealed class RockSpawner : MonoBehaviour
    {
        [SerializeField] private Rock rock;
        [SerializeField] private float interval = 3f;

        private HorizontalBoundsProvider _boundsProvider;
        private float _timer;

        //===== Lifecycle =====

        private void Awake() => _boundsProvider = HorizontalBoundsProvider.Instance;

        private void Update()
        {
            _timer += Time.deltaTime;
            if (!(_timer >= interval)) return;

            var position = transform.position;
            position.x = Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            Instantiate(rock, position, Quaternion.identity);

            _timer = 0f;
        }
    }
}