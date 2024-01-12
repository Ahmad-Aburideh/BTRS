using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class bus
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "BusID must be a valid integer.")]
        public int BusID { get; set; }

        [Required(ErrorMessage = "CaptainName is required")]
        public string CaptainName { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "NumberOfSeats must be a valid integer.")]
        public int NumberOfSeats { get; set; }
    }
}
