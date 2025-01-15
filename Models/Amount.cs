using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Amount
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Deposit {get;set;}
        public DateTime DepositDate {get; set;}
    }
}