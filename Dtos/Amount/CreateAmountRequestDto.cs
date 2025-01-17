namespace api.Dtos.Amount
{
    public class CreateAmountRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Deposit { get; set; }
        public DateTime DepositDate { get; set; }
    }
}
