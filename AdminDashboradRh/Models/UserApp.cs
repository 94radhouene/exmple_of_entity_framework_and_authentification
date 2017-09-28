using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdminDashboradRh.Models
{
    [Table("User_Application")]
    public class UserApp
    {
        [Key]
        [Display(Name = "Name_User")]
        public string username { get; set; }
        [Display(Name = "Password_User")]
        public string Password { get; set; }
        public string[] Roles { get; set; }

    }
}