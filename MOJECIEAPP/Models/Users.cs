using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MOJECIEAPP.Models
{
    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        public string Fullname { get; set; }
    }
}