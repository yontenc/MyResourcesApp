using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyResourcesApp.Models
{
    public class DepositAdance
    {
        [Key]
        [Required(ErrorMessage = "Customer ID is required")]
        public String CustomerCID { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { set; get; }

        public decimal Balance { set; get; }
    }
}
