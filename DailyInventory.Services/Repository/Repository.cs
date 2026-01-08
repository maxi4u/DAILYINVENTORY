using DailyInventory.DataAccess;
using DailyInventory.Services.IRepository;

namespace DailyInventory.Services.Repository;

public class Repository<T>(IDataBase DB) : IRepository<T> where T : class
{
    public IDataBase _DB { get; } = DB;
}