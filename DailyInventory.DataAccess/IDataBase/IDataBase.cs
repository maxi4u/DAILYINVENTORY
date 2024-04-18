using System.Data.SqlClient;

namespace DailyInventory.DataAccess;

public interface IDataBase
{
    Task<T> GetCustomerDashBoard<T>(string SPName, List<dynamic> SqlParams) where T : new();

    string GetDBConnection();

    SqlConnection OpenDB();
}