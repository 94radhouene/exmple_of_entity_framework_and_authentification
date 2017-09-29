using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboradRh.Models
{
    public interface IEmployee
    {
         string Name_Employee { get; set; }
         int Age_Employee { get; set; }
         string Poste_Employee { get; set; }
    }

    [Table("Employe_Biwam")]
    [Bind(Exclude = "id_Employee")]
    public partial class EmployeeApp : IEmployee
    {
        [Key]
        public int id_Employee { get; set; }
        public string Name_Employee { get; set; }
        public int Age_Employee { get; set; }
        public string Poste_Employee { get; set; }
    }
}