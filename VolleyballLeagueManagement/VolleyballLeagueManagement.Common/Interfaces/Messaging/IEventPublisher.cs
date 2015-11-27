namespace VolleyballLeagueManagement.Common.Interfaces.Messaging
{
    /// <summary>
    /// Event publisher interface
    /// </summary>
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}
