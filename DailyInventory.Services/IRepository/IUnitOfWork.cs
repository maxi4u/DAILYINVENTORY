using DailyInventory.Services.IRepository;

namespace DailyInventory.DataAccess.IRepository;

public interface IUnitOfWork
{
    ICustomerDashBoardRepository CustomerDashBoard { get; }
}