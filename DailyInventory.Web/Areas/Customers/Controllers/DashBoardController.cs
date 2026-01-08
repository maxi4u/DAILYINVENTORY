using System.Net;
using System.Net.Mail;
using DailyInventory.DataAccess.IRepository;
using DailyInventory.Models;
using DailyInventory.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DailyInventory.Web.Areas.Customers.Controllers;

public class DashBoardController : Controller
{
    private readonly IUnitOfWork _IUnitOfWork;
    private readonly ILogger<DashBoardController> _Logger;

    public DashBoardController(ILogger<DashBoardController> logger, IUnitOfWork iUnitOfWork)
    {
        _Logger = logger;
        _IUnitOfWork = iUnitOfWork;
    }

    public IActionResult Create()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Index(string ID)
    {
        var DashBoardData = new CustomerDashBoardModel();
        DashBoardData.CustomerID = ID;

        if (string.IsNullOrEmpty(ID))
            DashBoardData = await _IUnitOfWork.CustomerDashBoard.GetCustomerDashBoard();
        else
            DashBoardData = await _IUnitOfWork.CustomerDashBoard.GetCustomerDashBoardByID(ID);

        using (var context = new DailyInventoryContext())
        {
            var account = context.Accounts.ToList();
            var cards = context.CreditCards.ToList();
        }

        return View(DashBoardData);
    }

    public IActionResult GoTo()
    {
        return RedirectToAction(nameof(Index), "CreditCard", new { area = "Customers" });
    }

    //public async Task<IActionResult> SendEmail()
    //{
    //    try
    //    {
    //        // Read Azure AD app credentials from environment (or secure configuration)
    //        var clientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
    //        var tenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
    //        var clientSecret = Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");

    //        var confidentialClient = Microsoft.Identity.Client.ConfidentialClientApplicationBuilder
    //            .Create(clientId)
    //            .WithTenantId(tenantId)
    //            .WithClientSecret(clientSecret)
    //            .Build();

    //        var authProvider = new Microsoft.Graph.Auth.ClientCredentialProvider(confidentialClient);
    //        var graphClient = new Microsoft.Graph.GraphServiceClient(authProvider);

    //        var message = new Microsoft.Graph.Message
    //        {
    //            Subject = "Hi",
    //            Body = new Microsoft.Graph.ItemBody
    //            {
    //                ContentType = Microsoft.Graph.BodyType.Text,
    //                Content = "Doc"
    //            },
    //            ToRecipients = new List<Microsoft.Graph.Recipient>
    //        {
    //            new Microsoft.Graph.Recipient
    //            {
    //                EmailAddress = new Microsoft.Graph.EmailAddress
    //                {
    //                    Address = "mohankumar786@gmail.com"
    //                }
    //            }
    //        }
    //        };

    //        // Send as the sender mailbox (requires the app to have appropriate delegated/application permissions)
    //        await graphClient.Users["maxismums@outlook.com"].SendMail(message, true).Request().PostAsync();

    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch (Exception ex)
    //    {
    //        _Logger.LogError(ex, "Error sending email via Microsoft Graph");
    //        return RedirectToAction(nameof(Index));
    //    }
    //}

    //public async Task<IActionResult> SendEmail()
    //{
    //    try
    //    {
    //        var confidentialClient = ConfidentialClientApplicationBuilder
    //        .Create(clientId)
    //        .WithTenantId(tenantId)
    //        .WithClientSecret(clientSecret)
    //        .Build();

    //        var authProvider = new ClientCredentialProvider(confidentialClient);
    //        var graph = new GraphServiceClient(authProvider);

    //        var message = new Message
    //        {
    //            Subject = "Hi",
    //            Body = new ItemBody { ContentType = BodyType.Text, Content = "Doc" },
    //            ToRecipients = new[] {
    //                new Recipient { EmailAddress = new EmailAddress { Address = "mohankumar786@gmail.com" } }
    //            }
    //        };

    //        // Send as the sender mailbox (requires the app to have appropriate delegated/application permissions)
    //        await graph.Users["maxismums@outlook.com"].SendMail(message, true).Request().PostAsync();

    //        return RedirectToAction(nameof(Index));
    //    }
    //    catch (Exception ex)
    //    {
    //        _Logger.LogError(ex, "Error sending email via Microsoft Graph");
    //        return RedirectToAction(nameof(Index));
    //    }
    //}

    public IActionResult SendEmail()
    {
        try
        {
            var message = new MailMessage
            {
                From = new MailAddress("maxismums@outlook.com"),
                To = { "mohankumar786@gmail.com" },
                Subject = "Hi",
                Body = "Doc"
            };

            using (var smtpClient = new SmtpClient("smtp-mail.outlook.com")
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("maxismums@outlook.com", "Mynamemaxi7"),
                EnableSsl = true,
                Port = 587
            })

                //SmtpClient smtpClient = new SmtpClient("smtp.office365.com", 587); // Use port 587
                //smtpClient.EnableSsl = true; // Use TLS/StartTLS
                //smtpClient.UseDefaultCredentials = false; // Must be false to use specific credentials
                //smtpClient.Credentials = new System.Net.NetworkCredential("maxismums@outlook.com", "Mynamemaxi7");

                smtpClient.Send(message);
            return RedirectToAction(nameof(Index));
        }
        catch (SmtpException ex)
        {
            _Logger.LogError(ex, "Error sending email");
            return RedirectToAction(nameof(Index));
        }
    }

    public ActionResult SendEmail_000()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient();
        mail.From = new MailAddress("maxismums@outlook.com");
        mail.To.Add("mohankumar786@gmail.com");
        mail.Subject = "Hi";
        mail.Body = "Doc";
        SmtpServer.UseDefaultCredentials = false;
        NetworkCredential NetworkCred = new NetworkCredential("maxismums@outlook.com", "Mynamemaxi7");
        SmtpServer.Credentials = NetworkCred;
        SmtpServer.EnableSsl = true;
        SmtpServer.Port = 587;
        SmtpServer.Host = "smtp-mail.outlook.com";
        SmtpServer.Send(mail);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult SendEmail_001()
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress("maxismums@outlook.com"),
            Subject = "Hi",
            Body = "Doc"
        };
        mailMessage.To.Add("mohankumar786@gmail.com");

        var smtpClient = new SmtpClient("smtp-mail.outlook.com")
        {
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("maxismums@outlook.com", "Mynamemaxi7"),
            EnableSsl = true,
            Port = 587
        };

        smtpClient.Send(mailMessage);
        return RedirectToAction(nameof(Index));
    }
}