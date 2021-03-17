using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyResourcesApp.Models
{
    public class DepositAdvanceHistory
    {
        [Key]
        [Required(ErrorMessage = "Site id is required")]
        public int DepositeID { set; get; }
        
        public DateTime DepositTime { set; get; }
        public decimal DepositAmount { set; get; }
        public decimal BalanceAmount { set; get; }
        public decimal DebitAmount { set; get; }
        public decimal CreditAmount { set; get; }
        public String CustomerCID { set; get; }
    }
}
