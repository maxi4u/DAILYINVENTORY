using Microsoft.Data.SqlClient;

namespace DailyInventory.DataAccess;

public interface IDataBase
{
    Task<T> GetCustomerDashBoard<T>(string SPName) where T : new();

    Task<T> GetCustomerDashBoardByID<T>(string SPName, List<dynamic> SqlParams) where T : new();

    string GetDBConnection();

    SqlConnection OpenDB();

    Task SaveAsync();
}