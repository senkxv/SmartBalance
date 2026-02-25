namespace SmartBalance.Models
{
    class IncomeModel
    {
        public string? Сategory { get; set; }
        public decimal Amount { get; set; } = 0;
        public DateTime Date { get; set; }
        public string? Wallet { get; set; }
        public string? Comment { get; set; } = "коммент";
    }
}
