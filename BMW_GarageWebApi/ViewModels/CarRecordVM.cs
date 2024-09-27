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
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Date Of Visit")]
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly DateOfVisit { get; set; }

        [Required]
        [Display(Name = "Verification Status")]
        public StatusCarRecord StatusCarRecord { get; set; } = StatusCarRecord.NotConfirmed;

        [Display(Name = "Service Worker")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? EmployeeList { get; set; }
        public string? ApplicationUserId { get; set; }

    }
}
