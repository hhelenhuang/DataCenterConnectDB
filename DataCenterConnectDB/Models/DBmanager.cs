using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace DataCenterConnectDB.Models
{
    public class DBmanager
    {

        string ConnStr = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=test01;Integrated Security=SSPI;Trusted_Connection=yes;";

        public List<LoginContact> GetLoginContact()
        {
            List<LoginContact> logincontacts = new List<LoginContact>();
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM LoginContact");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LoginContact logincontact = new LoginContact
                    {
                        LoginNum = reader.GetInt32(reader.GetOrdinal("LoginNum")),
                        INDO = reader.GetString(reader.GetOrdinal("INDO")),
                        PW = reader.GetString(reader.GetOrdinal("PW")),
                    };
                    logincontacts.Add(logincontact);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return logincontacts;
        }
        public void NewLoginContact(LoginContact loginContact)
        {
            SqlConnection sqlConn = new SqlConnection(ConnStr);
            SqlCommand sqlCom = new SqlCommand(
                @"INSERT INTO loginContact (INDO, PW)
             VALUES( @INDO, @PW)");
            sqlCom.Connection = sqlConn;
            sqlCom.Parameters.Add(new SqlParameter("@INDO", loginContact.INDO));
            sqlCom.Parameters.Add(new SqlParameter("@PW", loginContact.PW));
            sqlConn.Open();
            sqlCom.ExecuteNonQuery();
            sqlConn.Close();
        }

        public LoginContact GetLoginContactById(int id) {
            LoginContact loginContact = new LoginContact();
            SqlConnection sqlConn = new SqlConnection(ConnStr);
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM LoginContact WHERE  id = @id");
            sqlCom.Connection = sqlConn;
            sqlCom.Parameters.Add(new SqlParameter("@id", id));
            sqlConn.Open();
            SqlDataReader reader = sqlCom.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read())
                {
                    loginContact = new LoginContact
                    {
                        LoginNum = reader.GetInt32(reader.GetOrdinal("id")),
                        INDO = reader.GetString(reader.GetOrdinal("INDO")),
                        PW = reader.GetString(reader.GetOrdinal("PW")),
                    };
                } 
            }
            else{
                loginContact.INDO = "未找到該筆資料";//借放
            }
            sqlConn.Close();
            return loginContact;
        }


    }
}