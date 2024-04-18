using DailyInventory.DataAccess;
using DailyInventory.Services.IRepository;

namespace DailyInventory.Services.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    public Repository(IDataBase DB)
    {
        _DB = DB;
    }

    public IDataBase _DB { get; }
}