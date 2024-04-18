namespace DailyInventory.Models
{
    public class CustomerDashBoardModel
    {
        public Login? _login { get; set; }
        public IEnumerable<Accounts>? Accounts { get; set; }

        public IEnumerable<CreditCards>? CreditCards { get; set; }
        public string? CustomerID { get; set; }
        public int TotalAccount { get; set; }
        public int TotalCreditCard { get; set; }
    }
}