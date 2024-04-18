using DailyInventory.DataAccess.IRepository;
using DailyInventory.Models;
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

        DashBoardData = await _IUnitOfWork.CustomerDashBoard.GetCustomerDashBoard(ID);

        return View(DashBoardData);
    }
}