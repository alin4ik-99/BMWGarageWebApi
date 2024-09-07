using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.Domain.Enum
{
    public enum StatusCarRecord
    {
        [Display(Name = "Запис підтверджено")]
        Confirmed,

        [Display(Name = "Запис не підтверджено")]
        NotConfirmed

    }
}
