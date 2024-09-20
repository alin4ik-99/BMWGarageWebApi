using BMW_GarageWebApi.Domain.Enum;
using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMW_GarageWebApi.Domain.DTOModels.DTOCarRecord
{
    public class CarRecordDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateOnly DateOfVisit { get; set; }
        public StatusCarRecord StatusCarRecord { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

    }
}
