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
    public class CarRepairRepository : Repository<CarRepair>, ICarRepairRepository
    {
        private ApplicationDbContext _db;

        public CarRepairRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(CarRepair obj)
        {
            _db.CarRepairs.Update(obj);
            _db.SaveChanges();
        }
    }
}
