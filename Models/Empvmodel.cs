using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TylerTech.Models
{
    public class Empvmodel
    {
        public Employee employee { get; set; }
        public IEnumerable<Employee> emplist { get; set; }
    }
}