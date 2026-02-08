namespace Features.Shared.EventBus.Interfaces
{
    public interface IEventPublisher<in T>
    {
        void Invoke(T content);
    }
}