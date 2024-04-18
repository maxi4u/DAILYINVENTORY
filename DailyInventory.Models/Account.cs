namespace DailyInventory.Models
{
    public class Accounts
    {
        public string? AccountDescription { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountNo { get; set; }
        public string? AccountType { get; set; }
        public string? BankName { get; set; } = string.Empty;
        public string? CustomerID { get; set; }
    }
}