using BMW_GarageWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.DAL.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void Update(Employee obj);
       
    }
}
