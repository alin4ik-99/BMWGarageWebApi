using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.Domain.Enum
{
    public enum Gender
    {
        [Display(Name = "Чоловік")]
        Male, 

        [Display(Name = "Жінка")]
        Female2
 
    }
}
