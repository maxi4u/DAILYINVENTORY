namespace DailyInventory.Models.Models;

public partial class Account
{
    public long RowId { get; set; }

    public string CustomerId { get; set; } = null!;

    public string? BankName { get; set; }

    public string? AccountType { get; set; }

    public string? AccountNo { get; set; }

    public string? AccountHolderName { get; set; }

    public string? AccountDescription { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public bool? IsActive { get; set; }
}