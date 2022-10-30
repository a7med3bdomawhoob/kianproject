using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public  class Employee
    {
        [Required]
        public int Id { get; set; } 
        public  string first_name { get; set; }
        public string last_name { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public double? age { get; set; }
        public string username { get; set; }
        public bool? IsActive { get; set; }


    }
}
