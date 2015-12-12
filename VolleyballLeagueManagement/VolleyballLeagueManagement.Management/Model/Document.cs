using System.ComponentModel.DataAnnotations;

namespace VolleyballLeagueManagement.Management.Model
{
    public class Document
    {
        public int Id { get; set; }

        public int RegulationsId { get; set; }

        private string mime;

        public string MIMEType
        {
            get { return mime; }
            set
            {
                // some versions of FF sends mime type with quotes eg: "application/png"
                mime = value.Replace("\"", "");
            }
        }

        public int Size { get; set; }

        // 1 MB
        [MaxLength(1024 * 1024 * 1)]
        public byte[] Content { get; set; }

        // . + max 4 chars extension
        [MaxLength(5)]
        public string Extension { get; set; }


        public virtual Regulations Regulations { get; set; }
    }
}
