using System.ComponentModel.DataAnnotations;
using BMW_GarageWebApi.Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BMW_GarageWebApi.Domain.DTOModels
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateOfHiring { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string? ImageUrl { get; set; }
        public string? Notes { get; set; }

    }
}
