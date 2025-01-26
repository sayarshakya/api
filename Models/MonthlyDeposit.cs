using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class MonthlyDeposit 
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public string? Month {get; set; }
        public int Year { get; set; }
        public DateTime DepositedDate { get; set; }

    }
}
