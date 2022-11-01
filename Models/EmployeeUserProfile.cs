using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewGen.Models
{
    public class EmployeeUserProfile
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        public IFormFile Photo { get; set; }
    }
}