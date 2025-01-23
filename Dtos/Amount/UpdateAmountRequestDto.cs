namespace api.Dtos.Amount
{
    public class UpdateAmountRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Deposit { get; set; }
        public DateTime DepositDate { get; set; }
    }
}
