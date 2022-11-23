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

    public void NewLoginContact(LoginContact loginContact) {

        SqlConnection sqlConnection = new SqlConnection(Connstr);
        SqlCommand sqlCommand = new SqlCommand(
            @"INSERT INTO loginContact (LoginNum, INDO, PW)
             VALUES(@LoginNum, @INDO, @PW)");
        SqlCommand.Connection = sqlConnection;
        SqlCommand.Parameters.Add(new SqlParameter("@LoginNum", loginContact.LoginNum));
        SqlCommand.Parameters.Add(new SqlParameter("@INDO", loginContact.INDO));
        SqlCommand.Parameters.Add(new SqlParameter("@PW", loginContact.PW));
        SqlConnection.Open();
        SqlCommand.ExecuteNonQuery();
        SqlConnection.Close();
    }
}
