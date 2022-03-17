namespace WebApiBook.Repositories.Interfaces
{
    public interface IGeneric<T>
        where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);

        Task Create(T entity);
    }
}
