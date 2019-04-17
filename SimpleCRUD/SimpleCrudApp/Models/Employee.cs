using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleCrudApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(30)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(30)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        public string Address { get; set; }

        public string Code { get; set; }

        public string City { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "Wrong e-mail address.")]
        public string Email { get; set; }
    }
}