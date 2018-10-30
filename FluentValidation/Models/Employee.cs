using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentValidation.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Mail_Id { get; set; }
        public string Password { get; set; }

        public string Confirm_Password { get; set; }
    }
}