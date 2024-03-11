namespace UdemyCarBook.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
