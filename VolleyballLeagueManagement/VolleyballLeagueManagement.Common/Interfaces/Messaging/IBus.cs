using System;

namespace VolleyballLeagueManagement.Common.Interfaces.Messaging
{
    /// <summary>
    /// Bus interface
    /// </summary>
    public interface IBus : ICommandSender, IEventPublisher
    {
        void RegisterHandler<T>(Action<T> handler) where T : IMessage;
    }
}
