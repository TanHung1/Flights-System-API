using System.ComponentModel.DataAnnotations;

namespace FlightSystemAPI.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int Member { get; set; }

        public DateTime CreateDate { get; set; }

        public string Note { get; set; }



        public virtual ICollection<CargoManiFest> CargoManiFests { get; set; } = new List<CargoManiFest>();

    }
}
