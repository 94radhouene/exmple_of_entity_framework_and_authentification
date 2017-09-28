using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboradRh.Models
{
    [Bind(Exclude = "id_Employee")]
    [Table("Employe_Biwam")]
    public partial class EmployeeApp
    {
        [Key]
        public int id_Employee { get; set; }
        public string Name_Employee { get; set; }
        public int Age_Employee { get; set; }
        public string Poste_Employee { get; set; }
    }
}