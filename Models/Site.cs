using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyResourcesApp.Models
{
    public class Site
    {
        [Key]
        [Required(ErrorMessage = "Site id is required")]
        public int SiteID { set; get; }

        [Required(ErrorMessage = "Site name is required")]
        public string SiteName { set; get; }

        [Required(ErrorMessage = "Customer id is required")]
        public string CustomerID { set; get; }

        [Required(ErrorMessage = "Distance is required")]
        public decimal Distance { set; get; }
    }
}
