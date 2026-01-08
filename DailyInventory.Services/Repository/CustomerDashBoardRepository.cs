using DailyInventory.DataAccess;
using DailyInventory.Models;
using DailyInventory.Models.Models;
using DailyInventory.Services.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DailyInventory.Services.Repository;

public class CustomerDashBoardRepository : Repository<CustomerDashBoardModel>, ICustomerDashBoardRepository
{
    private readonly IDataBase _DB;
    private readonly DailyInventoryContext _dbContext;

    public CustomerDashBoardRepository(IDataBase DB) : base(DB)
    {
        _DB = DB;
    }

    public async Task<CustomerDashBoardModel> GetCustomerDashBoard()
    {
        var SqlParams = new List<dynamic>();
        var Result = new CustomerDashBoardModel();

        Result = await _DB.GetCustomerDashBoard<CustomerDashBoardModel>("SP_GetCustomerDashBoard");

        if (Result != null)
        {
            Result.TotalAccount = Result.Accounts.Count();
            Result.TotalCreditCard = Result.CreditCards.Count();
        }

        return Result;
    }

    public async Task<CustomerDashBoardModel> GetCustomerDashBoardByID(string CustID)
    {
        var SqlParams = new List<dynamic>();
        var Result = new CustomerDashBoardModel();

        SqlParams.Add(new SqlParameter("@CustID", CustID));

        Result = await _DB.GetCustomerDashBoardByID<CustomerDashBoardModel>("SP_GetCustomerDashBoard", SqlParams);

        if (Result != null)
        {
            Result.TotalAccount = Result.Accounts.Count();
            Result.TotalCreditCard = Result.CreditCards.Count();
        }

        return Result;
    }
}