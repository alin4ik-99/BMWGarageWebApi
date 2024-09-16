using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICarRecordRepository CarRecord { get; }

        ICarRepairRepository CarRepair { get; }

        IEmployeeRepository Employee { get; }

    }
}
