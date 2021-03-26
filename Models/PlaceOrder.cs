using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyResourcesApp.Models
{
    public class PlaceOrder
    {
        [Key]
        [Required(ErrorMessage = "Site id is required")]
        public int OrderID { set; get; }

        [Required(ErrorMessage = "CID is required")]
        public String CID { get; set; }

        public String CustomerName { set; get; }

        [Required(ErrorMessage = "Product name is required")]
        public String productName { get; set; }
        //public String CustomerName { get; set; }

        [Required(ErrorMessage = "Site id is required")]
        public int SiteID { set; get; }

        public String SiteName { set; get; }

        //public string SiteName { set; get; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        public decimal TransportAmount { set; get; }
        public decimal AdvanceBalance { set; get; }
        public decimal PriceAmount { set; get; }

        public Char OrderStatusID { set; get; }

        public String OrderStatusName { set; get; }



    }
}
