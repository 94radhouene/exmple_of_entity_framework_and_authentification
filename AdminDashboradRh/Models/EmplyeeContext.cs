using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdminDashboradRh.Models
{
    public class EmplyeeContext : DbContext
    {
        public EmplyeeContext()
            : base("name=RhAppContext")
        {
        }



      

      
        public class Employeeviewmodel
        {
            public EmployeeApp Employee { get; set; }
        }

        public virtual DbSet<EmployeeApp> Employees { get; set; }
    }
}