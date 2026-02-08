namespace Features.Shared.EventBus.Interfaces
{
    /// <summary>
    /// Marker interface for classes that listen to events.
    /// 
    /// This interface has no methods or properties. It is used by the global dependency injector to identify  classes
    /// that require event-related dependencies to be injected. Refer to <see cref="Installers.GlobalInjectionConfig"/>.
    /// </summary>
    public interface IEventListener
    {
    }
}