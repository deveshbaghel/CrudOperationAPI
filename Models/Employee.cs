using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Employee :WebApiApplication
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Int64 Mobile { get; set; }
        public string Address { get; set; }
    }
}