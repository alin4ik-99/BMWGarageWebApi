using System.ComponentModel.DataAnnotations;
using BMW_GarageWebApi.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BMW_GarageWebApi.Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [BindProperty]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [BindProperty]
        public DateOnly DateOfHiring { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Position { get; set; }

        [ValidateNever]
        public byte[]? ImageDate { get; set; }
        public string? Notes { get; set; }

    }
}
