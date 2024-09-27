using BMW_GarageWebApi.DAL.Data;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;

namespace BMW_GarageWebApi.DAL.Repositories
{
    public class CarRepairRepository : Repository<CarRepair>, ICarRepairRepository
    {
        private ApplicationDbContext _db;
        public CarRepairRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(CarRepair obj)
        {
            _db.CarRepairs.Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}
