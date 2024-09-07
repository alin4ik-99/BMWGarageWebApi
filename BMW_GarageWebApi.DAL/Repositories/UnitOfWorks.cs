using BMW_GarageWebApi.DAL.Data;
using BMW_GarageWebApi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMW_GarageWebApi.DAL.Repositories
{
    public class UnitOfWorks : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ICarRecordRepository CarRecord { get; private set; }

        public ICarRepairRepository CarRepair { get; private set; }

        public IEmployeeRepository Employee { get; private set; }

        public UnitOfWorks(ApplicationDbContext db)
        {
            _db = db;
            CarRecord = new CarRecordRepository(_db);
            CarRepair = new CarRepairRepository(_db);
            Employee = new EmployeeRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
