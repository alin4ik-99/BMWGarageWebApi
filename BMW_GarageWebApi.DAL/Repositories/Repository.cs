using BMW_GarageWebApi.DAL.Data;
using BMW_GarageWebApi.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BMW_GarageWebApi.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        internal DbSet<T> dbSet;
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
            _db.CarRecords.Include(u => u.Employee).Include(u => u.EmployeeId).Include(u => u.ApplicationUser).Include(u=>u.ApplicationUserId);
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) 
            {  
                query = query.Where(filter); 
            }          

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
            await _db.SaveChangesAsync();
        }
    }
}
