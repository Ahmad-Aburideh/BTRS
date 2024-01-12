using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "PassengerID must be a valid integer.")]
        public int PassengerID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "EmailAddress is required")]
        [Remote("IsEmailAddressAvailable", "Passenger", ErrorMessage = "EmailAddress already in use.")]
        public string EmailAddress { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "PhoneNumber must be a valid integer.")]
        [Remote("IsPhoneNumberAvailable", "Passenger", ErrorMessage = "Phone number already in use.")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Remote("IsUsernameAvailable", "Passenger", ErrorMessage = "Username already in use.")]
        public string Username { get; set; }
        public string Gender { get; set; }
        public List<trip> Trips { get; set; }
    }
}

