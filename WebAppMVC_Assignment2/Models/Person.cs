using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC_Assignment2.Models
{
    public class Person
    {
        [Display(Name = "Person ID")]
        [Range(100, 10000)]
        public int PersonID { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string PhoneNumber { get; set;}

        [Required]
        [StringLength(80, MinimumLength = 5)]
        public string Address { get; set; }

    }
}
