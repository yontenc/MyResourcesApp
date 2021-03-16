using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyResourcesApp.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "Product name is required")]
        public string productName { get; set; }
       // public string productSearch { get; set; }

        [Required(ErrorMessage = "Price per unit is required")]
        public decimal PricePerUnit { set; get; }

        [Required(ErrorMessage = "Transport rate is required")]
        public decimal TransportRate { set; get; }
       
    }
    
}

