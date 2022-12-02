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
                @"INSERT INTO loginContact (INDO, PW) VALUES( @INDO, @PW)");
            sqlCom.Connection = sqlConn;
            sqlCom.Parameters.Add(new SqlParameter("@INDO", loginContact.INDO));
            sqlCom.Parameters.Add(new SqlParameter("@PW", loginContact.PW));
            sqlConn.Open();
            sqlCom.ExecuteNonQuery();
            sqlConn.Close();
        }

        public LoginContact GetLoginContactById(int id)
        {
            LoginContact loginContact = new LoginContact();
            SqlConnection sqlConn = new SqlConnection(ConnStr);
            SqlCommand sqlCom = new SqlCommand("SELECT * FROM LoginContact WHERE LoginNum = @id");
            sqlCom.Connection = sqlConn;
            sqlCom.Parameters.Add(new SqlParameter("@id", id));
            sqlConn.Open();
            SqlDataReader reader = sqlCom.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    loginContact = new LoginContact
                    {
                        LoginNum = reader.GetInt32(reader.GetOrdinal("LoginNum")),
                        INDO = reader.GetString(reader.GetOrdinal("INDO")),
                        PW = reader.GetString(reader.GetOrdinal("PW")),
                    };
                }
            }
            else
            {
                loginContact.INDO = "未找到該筆資料";//借放
            }
            sqlConn.Close();
            return loginContact;
        }
        public void UpdateLoginContact(LoginContact loginContact)
        {
            SqlConnection sqlConn = new SqlConnection(ConnStr);
            SqlCommand sqlCom = new SqlCommand(
               @"UPDATE LoginContact SET INDO = @INDO, PW = @PW WHERE LoginNum = @id");
            sqlCom.Connection = sqlConn;
            sqlCom.Parameters.Add(new SqlParameter("@INDO", loginContact.INDO));
            sqlCom.Parameters.Add(new SqlParameter("@PW", loginContact.PW));
            sqlCom.Parameters.Add(new SqlParameter("@id", loginContact.LoginNum));
            sqlConn.Open();
            sqlCom.ExecuteNonQuery();
            sqlConn.Close();
        }

        public void DeleteLoginContactById(int id)
        {
            SqlConnection sqlConn = new SqlConnection(ConnStr);
            SqlCommand sqlCom = new SqlCommand(
               @"DELETE FROM LoginContact WHERE LoginNum = @id");
            sqlCom.Connection = sqlConn;
            sqlCom.Parameters.Add(new SqlParameter("@id", id));
            sqlConn.Open();
            sqlCom.ExecuteNonQuery();
            sqlConn.Close();
        }


        public List<Form> GetForm()
        {
            List<Form> forms = new List<Form>();
            using (SqlConnection myConnection = new SqlConnection(ConnStr))
            {
                myConnection.Open();
                using (SqlCommand command1 = new SqlCommand("SELECT * FROM Contact", myConnection))
                {
                    SqlDataReader reader = command1.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Form form = new Form
                            {
                                INDO = reader.GetString(reader.GetOrdinal("INDO")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Department = reader.GetString(reader.GetOrdinal("Department")),
                                Position = reader.GetString(reader.GetOrdinal("Position")),
                                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                            };
                            forms.Add(form);
                        }
                    }
                    else
                    {
                        Console.WriteLine("資料庫為空！");
                    }
                }
                using (SqlCommand command2 = new SqlCommand("SELECT * FROM ApplyTable", myConnection))
                {
                    SqlDataReader reader = command2.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Form form = new Form
                            {
                                ApplyID = reader.GetInt32(reader.GetOrdinal("ApplyID")),
                                ApplyDate = reader.GetString(reader.GetOrdinal("ApplyDate")),
                                ApplyIDNO = reader.GetString(reader.GetOrdinal("ApplyIDNO")),
                                ContractIDNO = reader.GetString(reader.GetOrdinal("ContractIDNO")),
                                ApplyType = reader.GetString(reader.GetOrdinal("ApplyType")),
                                ApplyName = reader.GetString(reader.GetOrdinal("ApplyName")),
                                ApplyStartDate = reader.GetString(reader.GetOrdinal("ApplyStartDate")),
                                ApplyEndDate = reader.GetString(reader.GetOrdinal("ApplyEndDate")),
                                ApplyDescribe = reader.GetString(reader.GetOrdinal("ApplyDescribe")),
                                ApplyContent = reader.GetString(reader.GetOrdinal("ApplyContent")),

                            };
                            forms.Add(form);
                        }
                    }
                    else
                    {
                        Console.WriteLine("資料庫為空！");
                    }
                }
                myConnection.Close();
                return forms;
            }
        }
    }
}