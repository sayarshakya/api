using System.ComponentModel.DataAnnotations;

namespace api.Dtos.MonthlyDeposit
{
    public class CreateMonthlyDepositRequestDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [Range(1, 10000)]
        public decimal Amount { get; set; }
        [Required]
        public string? Month { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public DateTime DepositedDate { get; set; }
    }
}
