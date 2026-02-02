using UnityEngine;

namespace Features.Hazards.Scripts
{
    public sealed class RockSpawner : MonoBehaviour
    {
        [SerializeField] private Rock rock;
        [SerializeField] private float interval = 3f;

        // Prevent rocks from spawning flush against the screen edges
        private const float XOffset = 1f;

        private Camera _mainCamera;
        private float _timer;
        private float _minX;
        private float _maxX;

        //===== Lifecycle =====

        private void Awake()
        {
            _mainCamera = Camera.main;
            if (!_mainCamera)
            {
                Debug.LogError("Main camera is required but not found", this);
                return;
            }

            _minX = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            _maxX = _mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (!(_timer >= interval)) return;

            var position = transform.position;
            position.x = Random.Range(_minX + XOffset, _maxX - XOffset);
            Instantiate(rock, position, Quaternion.identity);

            _timer = 0f;
        }
    }
}