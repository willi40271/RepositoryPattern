using System;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternApp.WebUI.Models.Employee
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Last Name", Prompt = "Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "First Name", Prompt = "Required")]
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
    }
}