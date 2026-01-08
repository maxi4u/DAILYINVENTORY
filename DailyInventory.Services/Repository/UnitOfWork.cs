using DailyInventory.DataAccess.IRepository;
using DailyInventory.Models.Models;
using DailyInventory.Services.IRepository;
using DailyInventory.Services.Repository;

namespace DailyInventory.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDataBase _DB;
    private readonly DailyInventoryContext _dbContext;

    public UnitOfWork(IDataBase DB, DailyInventoryContext dbContext)
    {
        _DB = DB;
        _dbContext = dbContext;
        CustomerDashBoard = new CustomerDashBoardRepository(_DB);
        CreditCard = new CreditCardRepository(_dbContext);
    }

    //CustomerDashBoard
    public ICustomerDashBoardRepository CustomerDashBoard { get; set; }

    public ICustomerDashBoardRepository CustomerDashBoardByID { get; set; }

    //CreditCard
    public ICreditCardRepository CreditCard { get; set; }

    public ICreditCardRepository CreditCardByID { get; set; }

    public async Task SaveAsync()
    {
        await _DB.SaveAsync();
    }
}