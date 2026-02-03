using Shared.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Features.Hazards.Scripts
{
    public sealed class RockSpawner : ITickable
    {
        private readonly IBoundsProvider _boundsProvider;
        private readonly RockFactory _rockFactory;
        private readonly Vector3 _originPosition;
        private readonly float _interval;

        private float _timer;

        public RockSpawner(
            IBoundsProvider boundsProvider,
            RockFactory rockFactory,
            Vector3 originPosition,
            float interval)
        {
            _boundsProvider = boundsProvider;
            _rockFactory = rockFactory;
            _originPosition = originPosition;
            _interval = interval;
        }

        public void Tick()
        {
            _timer += Time.deltaTime;
            if (_timer < _interval) return;

            var x = Random.Range(_boundsProvider.Min, _boundsProvider.Max);
            var position = new Vector3(x, _originPosition.y, 0);
            _rockFactory.Create(position);

            _timer = 0f;
        }
    }
}