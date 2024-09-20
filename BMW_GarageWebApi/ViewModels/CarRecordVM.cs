using BMW_GarageWebApi.Domain.Enum;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.ViewModels
{
    public class CarRecordVM
    {
        //  public CarRecord CarRecord { get; set; }

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "Повне ім'я (ПІБ)")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Опис послуг")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Дата візиту")]
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly DateOfVisit { get; set; }

        [Required]
        [Display(Name = "Статус підтвердження")]
        public StatusCarRecord StatusCarRecord { get; set; } = StatusCarRecord.NotConfirmed;

        [Display(Name = "Працівник сервісу")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? EmployeeList { get; set; }
    }
}
