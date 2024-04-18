using System.Net;
using Microsoft.AspNetCore.Http;

namespace DailyInventory.Models;

public class Login
{
    static Login()
    {
        var client = new HttpClient();
    }

    public bool isLoggedIn { get; set; } = false;

    public string? LoginID { get; set; }

    public LoginLogoutModel LoginLogouInfo { get; set; } = new LoginLogoutModel();

    public NewUserModel NewUserInfo { get; set; } = new NewUserModel();

    public string? Password { get; set; }

    public UserSystemModel UserSystemInfo { get; set; } = new UserSystemModel();
}

public class LoginLogoutModel
{
    public DateTime LastLoginTime { get; set; }
    public DateTime LastLogOutTime { get; set; }
    public DateTime LogInTime { get; set; }
}

public class UserSystemModel
{
    public string? BrowserInfo { get; set; }

    public string IPAddress { get; set; } = Dns.GetHostAddresses(Dns.GetHostName())[3].ToString();
    public string UserDomain { get; set; } = Dns.GetHostName();//System.Net.IPAddress.Any

    private string GetBrowserType(IHttpContextAccessor? context)
    {
        string browserType = string.Empty;
        if (context.HttpContext.Request != null)
        {
            var request = context.HttpContext.Request;
            browserType = request.Headers["User-Agent"].ToString();
        }
        return browserType;
    }
}

public class NewUserModel
{
    public string? Email { get; set; }
    public string? MobileNo { get; set; }
    public Guid UserID { get; set; } = Guid.NewGuid();
    public string? UserName { get; set; }
    public string? UserType { get; set; }
}