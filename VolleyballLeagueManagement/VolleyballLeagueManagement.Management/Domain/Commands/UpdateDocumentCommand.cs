using VolleyballLeagueManagement.Common.Interfaces.Messaging;

namespace VolleyballLeagueManagement.Management.Domain.Commands
{
    public class UpdateDocumentCommand : ICommand
    {
        public int RegulationsId { get; set; }

        public string MIMEType { get; set; }

        public int Size { get; set; }

        public byte[] Content { get; set; }

        public string Extension { get; set; }
    }
}
