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
    public class CarRecordRepository : Repository<CarRecord>, ICarRecordRepository
    {
        private ApplicationDbContext _db;

        public CarRecordRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(CarRecord obj)
        {
            var objFromDb = _db.CarRecords.FirstOrDefault(p => p.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.FullName = obj.FullName;
                objFromDb.Email = obj.Email;
                objFromDb.PhoneNumber = obj.PhoneNumber;
                objFromDb.Description = obj.Description;
                objFromDb.DateOfVisit = obj.DateOfVisit;
                objFromDb.StatusCarRecord = obj.StatusCarRecord;
                objFromDb.EmployeeId = obj.EmployeeId;

            }
        }
    }
}
