using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class ViewSelection
    {
        [Required]
        public string SelectedView { get; set; }
    }
}
