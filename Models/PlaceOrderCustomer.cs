﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyResourcesApp.Models
{
    public class PlaceOrderCustomer
    {
        [Key]
        [Required(ErrorMessage = "CID is required")]
        public String CID { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public String productName { get; set; }
        //public String CustomerName { get; set; }

        [Required(ErrorMessage = "Site id is required")]
        public int SiteID { set; get; }

        //public string SiteName { set; get; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        public decimal TransportAmount { set; get; }
        public decimal AdvanceBalance{ set; get; }
        public decimal PriceAmount{ set; get; }



    }
}
