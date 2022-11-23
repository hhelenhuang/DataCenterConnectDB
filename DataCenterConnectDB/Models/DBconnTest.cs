using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace WebApplication1.Models
{

    public class LoginContact
    {
        public int LoginNum { get; set; }
        public string INDO { get; set; }
        public string PW { get; set; }
    }
}