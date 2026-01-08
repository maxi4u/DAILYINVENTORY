using DailyInventory.Models.Models;

namespace DailyInventory.Services.IRepository;

public interface ICreditCardRepository
{
    void AddAsync(CreditCard CardInfo);

    Task<List<CreditCard>> GetAllCreditCards();

    //Task<CreditCard> GetCreditCardById(int id);
    //Task<CreditCard> CreateCreditCard(CreditCard creditCard);
    //Task<CreditCard> UpdateCreditCard(CreditCard creditCard);
    //Task<CreditCard> DeleteCreditCard(int id);
}