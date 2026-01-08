using DailyInventory.DataAccess.IRepository;
using DailyInventory.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DailyInventory.Web.Areas.Customers.Controllers;

public class CreditCardController : Controller
{
    private readonly IUnitOfWork _IUnitOfWork;

    public CreditCardController(IUnitOfWork iUnitOfWork)
    {
        _IUnitOfWork = iUnitOfWork;
    }

    // GET: CreditCardController
    public async Task<IActionResult> Index()
    {
        var creditCardModel = await _IUnitOfWork.CreditCard.GetAllCreditCards();
        return View(creditCardModel);
    }

    // GET: CreditCardController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: CreditCardController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CreditCardController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(IFormCollection collection)
    {
        try
        {
            var CreditCardInfo = new CreditCard
            {
                BankName = collection["BankName"],
                CreditCardDescription = collection["CreditCardDescription"],
                CcunUsedAmount = Convert.ToDecimal(collection["CcunUsedAmount"]),
                CcusedAmount = Convert.ToDecimal(collection["CcusedAmount"]),
                CreditCardHolderName = collection["CreditCardHolderName"],
                CreditCardLimit = Convert.ToDecimal(collection["CreditCardLimit"]),
                CreditCardNo = collection["CreditCardNo"],
                CreditCardType = collection["CreditCardType"],
                CustomerId = "7011120421",
                CreatedBy = "45698",
                CreatedOn = DateTime.Now
            };

            _IUnitOfWork.CreditCard.AddAsync(CreditCardInfo);
            await _IUnitOfWork.SaveAsync();
        }
        catch
        {
            throw;
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: CreditCardController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: CreditCardController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CreditCardController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: CreditCardController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}