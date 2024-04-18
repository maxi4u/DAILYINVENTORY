using System.Data;
using System.Data.SqlClient;
using DailyInventory.Models;
using DailyInventory.Utilities;
using Microsoft.Extensions.Configuration;

namespace DailyInventory.DataAccess;

public class DataBase : IDataBase
{
    private readonly IConfiguration _Configuration;
    private readonly string DBConn = string.Empty;

    public DataBase(IConfiguration configuration)
    {
        _Configuration = configuration;
        DBConn = _Configuration.GetConnectionString("DailyInventory") ?? string.Empty;
    }

    public async Task<T> Add2DB<T>(string SPName, List<dynamic> SqlParams)
    {
        var oDS = await PerformAction(SPName, SqlParams);

        if (oDS.Tables.Count > 0 && oDS.Tables[0].Rows.Count > 0)
        {
        }

        return default;
    }

    public async Task<T> GetCustomerDashBoard<T>(string SPName, List<dynamic> SqlParams) where T : new()
    {
        dynamic Result = new T();
        var oDS = await PerformAction(SPName, SqlParams);

        if (oDS.Tables.Count > 0 && oDS.Tables[0].Rows.Count > 0)
        {
            var Acc = CommonFunction.ConvertDataTable<Accounts>(oDS.Tables[0]);
            var CC = CommonFunction.ConvertDataTable<CreditCards>(oDS.Tables[1]);

            Result.Accounts = Acc;
            Result.CreditCards = CC;
        }

        return Result;
    }

    public string GetDBConnection()
    {
        return DBConn;
    }

    public SqlConnection OpenDB()
    {
        var Conn = new SqlConnection(DBConn);
        if ((Conn.State & ConnectionState.Open) != 0)
        {
            Conn.Open();
        }

        return Conn;
    }

    private async Task<DataSet> PerformAction(string SPName, List<dynamic> SqlParams)
    {
        var oDS = new DataSet();
        try
        {
            await using var oSqlConn = OpenDB();
            await using var oCmd = new SqlCommand(SPName, oSqlConn);
            oCmd.CommandType = CommandType.StoredProcedure; oCmd.Parameters.AddRange(SqlParams.ToArray());
            using var oSDA = new SqlDataAdapter(oCmd);
            oSDA.Fill(oDS);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }

        return oDS;
    }
}