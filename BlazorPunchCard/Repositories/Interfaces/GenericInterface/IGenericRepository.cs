namespace BlazorPunchCard.Repositories.Interfaces.GenericInterface
{
    public interface IGenericRepository<T, TKey> where T : class
    {
        Task<T?> GetById(TKey id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);  
        Task DeleteByIdAsync(int id);
        Task SaveAsync();

    }
    public interface IGenericRepository<T> : IGenericRepository<T, int> where T : class 
    {
        
    }
}
