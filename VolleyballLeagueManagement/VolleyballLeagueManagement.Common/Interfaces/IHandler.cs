namespace VolleyballLeagueManagement.Common.Interfaces
{
    /// <summary>
    /// Generic handler interface
    /// </summary>
    /// <typeparam name="TCommandType">message/command type</typeparam>
    public interface IHandler<in TCommandType>
    {
        void Handle(TCommandType command);
    }
}
