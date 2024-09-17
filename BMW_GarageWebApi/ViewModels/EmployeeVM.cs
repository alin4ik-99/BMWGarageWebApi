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
        [Display(Name = "Повне ім'я (ПІБ)")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Дата народження")]
        [BindProperty]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Дата початку співпраці")]
        [BindProperty]
        public DateOnly DateOfHiring { get; set; }

        [Required]
        [Display(Name = "Гендер")]
        public Gender Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Посада")]
        public string Position { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }

        [Display(Name = "Характеристика")]
        public string? Notes { get; set; }
    }
}
