using System.ComponentModel.DataAnnotations;

namespace FlightSystemAPI.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }

        public string DocumentName { get; set; }

        public DateTime CreateDate { get; set; }

        public string Creator { get; set; }

        public string Permission { get; set; }

        public virtual ICollection<CargoManiFest> CargoManiFests { get; set; }
    }
}
