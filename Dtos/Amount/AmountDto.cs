using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Amount
{
    public class AmountDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Deposit { get; set; }
        public DateTime DepositDate { get; set; }
    }
}
