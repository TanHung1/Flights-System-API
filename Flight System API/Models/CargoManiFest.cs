using System.ComponentModel.DataAnnotations;

namespace FlightSystemAPI.Models
{
    public class CargoManiFest
    {

        [Key]
        public int Id { get; set; }
        public string FlightNo { get; set; }

        public string PointofLoading { get; set; }

        public string PointofUploading { get; set; }

        public float Version { get; set; }
        public int TypeId { get; set; }

        public string Note { get; set; }
        public int GroupId { get; set; }
        public int DocumentTypeId { get; set; }

    }
}
