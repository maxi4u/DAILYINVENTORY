using DailyInventory.Services.IRepository;

namespace DailyInventory.DataAccess.IRepository;

public interface IUnitOfWork
{
    //CustomerDashBoard
    ICustomerDashBoardRepository CustomerDashBoard { get; }

    ICustomerDashBoardRepository CustomerDashBoardByID { get; }

    //CreditCard
    ICreditCardRepository CreditCard { get; }

    ICreditCardRepository CreditCardByID { get; }

    Task SaveAsync();
}