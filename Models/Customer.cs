using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyResourcesApp.Models
{
    public class Customer
    {
        [Key]
        [Required(ErrorMessage = "CID is required")]
        public String CID { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [Display(Name = "Customer Name")]
        public String CustomerName { get; set; }

        [Required(ErrorMessage = "Moile number is required")]
        [Display(Name = "Mobile Number")]
        public String MobileNo { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }
    }
}
