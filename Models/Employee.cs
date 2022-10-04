using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewGen.Models
{
    public class Employee
    {   
        [Key]
        [Required]
        public int MyProperty { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Department { get; set; }
    }
}