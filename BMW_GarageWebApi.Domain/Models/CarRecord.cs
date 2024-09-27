using BMW_GarageWebApi.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_GarageWebApi.Domain.Models
{
    public class CarRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? Description { get; set; }

        [Required]
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly DateOfVisit { get; set; }

        [Required]
        public StatusCarRecord StatusCarRecord{ get; set; } = StatusCarRecord.NotConfirmed; 

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        [ValidateNever]
        public Employee? Employee { get; set; }

        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
