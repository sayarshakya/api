using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Amount
{
    public class CreateAmountRequestDto
    {
        [Required]
        [MinLength(4, ErrorMessage = "Name must be 4 Characteres")]
        [MaxLength(10, ErrorMessage = "Name must be less than 10 Characteres")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 10000)]
        public decimal Deposit { get; set; }
        public DateTime DepositDate { get; set; }
    }
}
