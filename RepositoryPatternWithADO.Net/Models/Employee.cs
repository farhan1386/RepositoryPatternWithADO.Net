using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepositoryPatternWithADO.Net.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your position")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Enter your office")]
        public string Office { get; set; }

        [Required(ErrorMessage = "Enter your age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter your salary")]
        public decimal Salary { get; set; }
    }
}