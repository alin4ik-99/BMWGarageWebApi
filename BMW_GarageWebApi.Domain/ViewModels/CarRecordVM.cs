using BMW_GarageWebApi.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.Domain.ViewModels
{
    public class CarRecordVM
    {
        public CarRecord ?CarRecord { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ?EmployeeList { get; set; }
    }
}
