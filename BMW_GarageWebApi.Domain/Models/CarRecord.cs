using BMW_GarageWebApi.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.Domain.Models
{
    public class CarRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "Повне ім'я (ПІБ)")]
        public string ?FullName { get; set; }

        [Required]
        public string ?Email { get; set; }

        [Required]
        [Display(Name = "Номер телефону")]
        public string ?PhoneNumber { get; set; }


        [Display(Name = "Опис")]
        public string ?Description { get; set; }

        [Required]
        [Display(Name = "Дата візиту")]
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly DateOfVisit { get; set; }

        [Required]
        [Display(Name = "Статус підтвердження")]
        public StatusCarRecord StatusCarRecord{ get; set; }


        [Display(Name = "Працівник сервісу")]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        [ValidateNever]
        public Employee ?Employee { get; set; }

    }
}
