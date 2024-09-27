using BMW_GarageWebApi.Domain.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BMW_GarageWebApi.ViewModels
{
    public class EmployeeVM_Contacts
    {
        [Required]
        [MaxLength(40)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }
        public string? Notes { get; set; }
    }
}
