using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUsingWebApi.Models
{
    public class Employee
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public int id { get; set; }
    }
}
