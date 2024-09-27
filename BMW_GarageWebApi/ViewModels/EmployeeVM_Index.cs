using BMW_GarageWebApi.Domain.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BMW_GarageWebApi.ViewModels
{
    public class EmployeeVM_Index
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [BindProperty]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Date of hiring")]
        [BindProperty]
        public DateOnly DateOfHiring { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Position")]
        public string Position { get; set; }        
    }
}
