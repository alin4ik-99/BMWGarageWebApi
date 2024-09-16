using BMW_GarageWebApi.DAL.Data;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.DAL.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Employee obj)
        {
            _db.Employees.Update(obj);
            _db.SaveChanges();
        }
    }
}
