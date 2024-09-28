using BMW_GarageWebApi.Domain.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BMW_GarageWebApi.ViewModels
{
    public class EmployeeVM
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
        [Display(Name = "Date Of Hiring")]
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

        [ValidateNever]
        public string? ImageBase64 { get; set; }

        [Display(Name = "Notes")]
        public string? Notes { get; set; }
    }
}
