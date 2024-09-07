using BMW_GarageWebApi.Domain.Enum;
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
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Номер телефону")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Дата візиту")]
        public DateOnly DateOfVisit { get; set; }

        [Required]
        [Display(Name = "Статус підтвердження")]
        public StatusCarRecord StatusCarRecord{ get; set; } = StatusCarRecord.NotConfirmed;



        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

    }
}
