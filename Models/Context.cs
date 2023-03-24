using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TylerTech.Models
{
    public class Context: DbContext
    {
        public Context():base("EmployeeEntity") 
        { 

        }
        public DbSet<Employee> Employees { get; set; }
    }
}