﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace DataCenterConnectDB.Models
{
    public class LoginContact
    {
        public int LoginNum { get; set; }
        public string INDO { get; set; }
        public string PW { get; set; }
    }
}
