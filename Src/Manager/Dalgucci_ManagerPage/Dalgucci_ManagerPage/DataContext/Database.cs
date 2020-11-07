



using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Dalgucci
{

    public class Database
    {
        SqlConnection conn = null;

        public Database()
        {
            string strConn = "Server=127.0.0.1;Database=SF1team;User Id=sa;Password=0924;";
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public void Order_View()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from Orders";
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Order_No = rdr["Order_No"].ToString();
                    string Product_Code = rdr["Product_Code"] as string;
                    string User_No = rdr["User_No"].ToString();
                    string Order_Time = rdr["Order_Time"].ToString();

                    string[] Order = new string[] { Order_No, Product_Code, User_No, Order_Time };

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void InsertMember(string MemberID, string Password, string User_name, string Tel, string RRN, string Address, string Email)
        {
            try
            {
                // 명령 객체 생성
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = $"insert into user_table values ('{MemberID}','{Password}','{User_name}','{Tel}','{RRN}','{Address}','{Email}')";
                cmd.ExecuteNonQuery();

                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public bool Sign_in(string MemberID, string Password)
        {
            try
            {
                // 명령 객체 생성
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = $"select count(*) from user_table where user_id = '{MemberID}' and pwd = '{Password}'";
                //int r = cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                var s = rdr["COUNT(*)"];
                int o = Convert.ToInt32(s);
                return o > 0 ? true : false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Login_state(string MemberID, string Password, string User_name, string Tel, string RRN, string Address, string Email)
        {
            try
            {
                // 명령 객체 생성
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = $"insert into user_table values ('{MemberID}','{Password}','{User_name}','{Tel}','{RRN}','{Address}','{Email}')";
                cmd.ExecuteNonQuery();

                //conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void update()
        {
            // 오라클 연결
            //
            try
            {


                // 명령 객체 생성
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "insert into product values (1236,'bbbb','205',1)";
                cmd.ExecuteNonQuery();

                //conn.Close();
            }
            catch (Exception ex)
            {
                int ttt = 0;
            }

        }
    }
}
