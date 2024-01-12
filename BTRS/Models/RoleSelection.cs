using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BTRS.Models
{
    public class RoleSelection
    {
        [Required]
        public string SelectedRole { get; set; }

       
    }
}
