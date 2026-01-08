using DailyInventory.Models;

namespace DailyInventory.Services.IRepository;

public interface ICustomerDashBoardRepository : IRepository<CustomerDashBoardModel>
{
    Task<CustomerDashBoardModel> GetCustomerDashBoard();

    Task<CustomerDashBoardModel> GetCustomerDashBoardByID(string CustID);
}