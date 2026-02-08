using Features.Shared.EventBus.Interfaces;
using VContainer;

namespace Features.Shared.EventBus.Implementation
{
    public class EventPublisherService<T>
    {
        protected IEventPublisher<T> Publisher;

        [Inject]
        public void Construct(IEventPublisher<T> publisher) => Publisher = publisher;
    }
}