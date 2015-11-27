using System;
using System.Collections.Generic;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Common.Infrastructure
{
    public class MessageBus : IBus
    {
        readonly Dictionary<Type, List<Action<IMessage>>> _handlers = new Dictionary<Type, List<Action<IMessage>>>();

        /// <summary>
        /// Sends a command to the handler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        public void Send<T>(T command) where T : ICommand
        {
            List<Action<IMessage>> handlers;
            var typeName = command.GetType().Name;

            if (_handlers.TryGetValue(command.GetType(), out handlers))
            {
                if (handlers.Count != 1)
                    throw new InvalidOperationException(
                        String.Format("Too many handlers. Command: {0} can have only one command handler", typeName));
                handlers[0](command);
                return;
            }

            throw new InvalidOperationException(
                String.Format("No handlers for command {0} registered", typeName));
        }

        /// <summary>
        /// Does publish an event to event handlers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        public void Publish<T>(T @event) where T : IEvent
        {
            List<Action<IMessage>> handlers;
            if (!_handlers.TryGetValue(@event.GetType(), out handlers)) return;

            foreach (var handler in handlers)
            {
                handler(@event);
            }
        }

        /// <summary>
        /// Registers a <see cref="ICommand"/> or <see cref="IEvent"/> hanlder
        /// </summary>
        public void RegisterHandler<T>(Action<T> handler) where T : IMessage
        {
            List<Action<IMessage>> handlers;
            if (!_handlers.TryGetValue(typeof(T), out handlers))
            {
                handlers = new List<Action<IMessage>>();
                _handlers.Add(typeof(T), handlers);
            }
            handlers.Add(new Action<IMessage>(x => handler((T)x)));
        }
    }
}
