using DailyInventory.Models.Models;
using DailyInventory.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DailyInventory.Services.Repository;

public class CreditCardRepository : ICreditCardRepository
{
    private readonly DailyInventoryContext _dbContext;

    public CreditCardRepository(DailyInventoryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddAsync(CreditCard newCreditInfo)
    {
        _dbContext.AddAsync(newCreditInfo);
        _dbContext.SaveChanges();
    }

    public Task<List<CreditCard>> GetAllCreditCards()
    {
        return _dbContext.CreditCards.ToListAsync();
    }
}