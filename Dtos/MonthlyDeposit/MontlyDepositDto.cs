namespace api.Dtos.MonthlyDeposit
{
    public class MontlyDepositDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string? Month { get; set; }
        public int Year { get; set; }
        public DateTime DepositedDate { get; set; }
    }
}
