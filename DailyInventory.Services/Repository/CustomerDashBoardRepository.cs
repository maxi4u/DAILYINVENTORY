using System.Data.SqlClient;
using DailyInventory.DataAccess;
using DailyInventory.Models;
using DailyInventory.Services.IRepository;

namespace DailyInventory.Services.Repository;

public class CustomerDashBoardRepository : Repository<CustomerDashBoardModel>, ICustomerDashBoardRepository
{
    private readonly IDataBase _DB;

    public CustomerDashBoardRepository(IDataBase DB) : base(DB)
    {
        _DB = DB;
    }

    public async Task<CustomerDashBoardModel> GetCustomerDashBoard(string CustID)
    {
        var SqlParams = new List<dynamic>();
        var Result = new CustomerDashBoardModel();

        SqlParams.Add(new SqlParameter("@CustID", "9899408686"));

        Result = await _DB.GetCustomerDashBoard<CustomerDashBoardModel>("SP_GetCustomerDashBoard", SqlParams);

        if (Result != null)
        {
            Result.TotalAccount = Result.Accounts.Count();
            Result.TotalCreditCard = Result.CreditCards.Count();
        }

        return Result;
    }
}