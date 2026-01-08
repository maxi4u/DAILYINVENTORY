namespace DailyInventory.Models.Models;

public partial class CreditCard
{
    public long RowId { get; set; }

    public string CustomerId { get; set; } = null!;

    public string? BankName { get; set; }

    public string? CreditCardType { get; set; }

    public string? CreditCardNo { get; set; }

    public string? CreditCardHolderName { get; set; }

    public string? CreditCardDescription { get; set; }

    public decimal? CreditCardLimit { get; set; }

    public decimal? CcusedAmount { get; set; }

    public decimal? CcunUsedAmount { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; } = DateTime.Now;

    public bool? IsActive { get; set; } = true;
}