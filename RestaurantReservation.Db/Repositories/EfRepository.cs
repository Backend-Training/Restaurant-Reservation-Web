using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories;

public class EfRepository<T> : IRepository<T> where T : class
{
    private readonly RestaurantReservationDbContext  _context;
    private readonly DbSet<T> _dbSet;

    public EfRepository(RestaurantReservationDbContext  context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public void Create(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity == null) return;
        
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
    
    public IQueryable<T> Entities()
    {
        return _dbSet.AsNoTracking().AsQueryable();
    }   
    
}