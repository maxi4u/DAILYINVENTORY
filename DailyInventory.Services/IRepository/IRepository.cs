using DailyInventory.DataAccess;

namespace DailyInventory.Services.IRepository;

public interface IRepository<T> where T : class
{
    IDataBase _DB { get; }

    //DailyInventoryContext _dbContext { get; }
    //Task<List<T>> GetAllAsync();
    //Task<T> GetAsync(int id);
    //Task<bool> AddAsync(T entity);
    //Task<bool> UpdateAsync(T entity);
    //Task<bool> DeleteAsync(int id);
    //IDataBase IRepository { get; }
}