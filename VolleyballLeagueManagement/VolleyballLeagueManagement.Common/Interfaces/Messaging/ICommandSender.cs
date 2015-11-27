namespace VolleyballLeagueManagement.Common.Interfaces.Messaging
{
    /// <summary>
    /// Command sender interface
    /// </summary>
    public interface ICommandSender
    {
        void Send<T>(T command) where T : ICommand;
    }
}
