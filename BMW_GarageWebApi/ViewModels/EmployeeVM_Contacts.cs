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
        [Display(Name = "Повне ім'я (ПІБ)")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }

        [Display(Name = "Характеристика")]
        public string? Notes { get; set; }
    }
}
