using System;
using System.Runtime.Serialization;

namespace VolleyballLeagueManagement.Common.Infrastructure
{
    [Serializable]
    public class ServerSideException : Exception
    {
        public ServerSideException(string message) : base(message) { }

        public ServerSideException(string message, Exception innerException) : base(message, innerException) { }

        public ServerSideException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
