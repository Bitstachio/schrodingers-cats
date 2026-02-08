using Features.Shared.EventBus.Interfaces;
using UnityEngine;
using VContainer;

namespace Features.Shared.EventBus.Implementation
{
    public abstract class EventListenerBehaviour<T> : MonoBehaviour, IEventListener
    {
        private IEvent<T> _event;

        [Inject]
        public void Construct(IEvent<T> @event) => _event = @event;

        private void OnEnable() => _event.Invoked += OnInvoked;

        private void OnDisable() => _event.Invoked -= OnInvoked;

        protected abstract void OnInvoked(T e);
    }
}