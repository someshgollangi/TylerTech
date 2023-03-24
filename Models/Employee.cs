using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TylerTech.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string Firstname { get; set; }

        public string Roles { get; set; }

        public string ManagerName { get; set; }

    }
}