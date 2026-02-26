namespace SmartBalance.Models
{
    internal class WalletModel
    {
        public string Name { get; set; } = "Новый кошелек";
        public PaymentType PaymentType { get; set; }
        public decimal Balance { get; set; }
    }
}
