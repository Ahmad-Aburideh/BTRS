using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTRS.Models
{
    public class BookingTrips
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TripID { get; set; }
       
        public string Destination { get; set; }
    }
}
