using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class methodSelection
    {
        [Required]
        public string SelectedMethod { get; set; }
    }
}
