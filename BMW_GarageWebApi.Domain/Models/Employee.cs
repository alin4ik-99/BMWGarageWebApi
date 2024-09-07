using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMW_GarageWebApi.Domain.Enum;

namespace BMW_GarageWebApi.Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "Повне ім'я (ПІБ)")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Дата народження")]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Дата початку співпраці")]
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
        [MaxLength(30)]
        [Display(Name = "Посада")]
        public string Position { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Характеристика")]
        public string Notes { get; set; }


    }
}
