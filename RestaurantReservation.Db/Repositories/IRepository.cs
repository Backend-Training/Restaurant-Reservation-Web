namespace RestaurantReservation.Db.Repositories;

public interface IRepository<T>
{
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(int id);
    public IQueryable<T> Entities();    
}