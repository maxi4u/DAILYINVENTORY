using DailyInventory.DataAccess.IRepository;
using DailyInventory.Services.IRepository;
using DailyInventory.Services.Repository;

namespace DailyInventory.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDataBase _DB;

    public UnitOfWork(IDataBase DB)
    {
        _DB = DB;
        CustomerDashBoard = new CustomerDashBoardRepository(_DB);
    }

    public ICustomerDashBoardRepository CustomerDashBoard { get; set; }
}