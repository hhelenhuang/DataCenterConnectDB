using System;
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

    public class Form
    {
        // Contact
        //public string INDO { get; set; }
        //public string Name { get; set; }
        //public string Department { get; set; }
        //public string Position { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }

        // Apply Contract

        public string ApplyIDNO { get; set; }
        public string ApplyName { get; set; }
        public string ContractName { get; set; }
        public string ContractIDNO { get; set; }
        public string ApplyStartDate { get; set; }
        public string ApplyEndDate { get; set; }
        public string ApplyDescribe { get; set; }
        public string ApplyContent { get; set; }

        // ApplyTable
        public int ApplyID { get; set; }
        public string ApplyDate { get; set; }
        public string ApplyType { get; set; }

    }
}
