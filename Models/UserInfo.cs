using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyResourcesApp.Models
{
    public class UserInfo
    {
        [Key]
        [Required]
        public String UserID { get; set; }
        public String UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public String EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int LoginCout { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
