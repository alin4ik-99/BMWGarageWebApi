﻿using BMW_GarageWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.DAL.Interfaces
{
    public interface ICarRepairRepository : IRepository<CarRepair>
    {
        Task UpdateAsync(CarRepair obj);
    }
}
