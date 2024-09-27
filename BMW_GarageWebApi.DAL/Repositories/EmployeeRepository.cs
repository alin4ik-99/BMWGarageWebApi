using BMW_GarageWebApi.DAL.Data;
using BMW_GarageWebApi.DAL.Interfaces;
using BMW_GarageWebApi.Domain.Models;

namespace BMW_GarageWebApi.DAL.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Employee obj)
        {
            _db.Employees.Update(obj);
            await _db.SaveChangesAsync();
        }
    }
}
