using System;
using System.Collections.Generic;
using System.Data;
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
            string strConn = "Server=127.0.0.1;Database=SF1team;User Id=sa;Password=1234;";
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int OrdersCountResult()
        {
            int OrderCnt = 0;

            try
			{
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select count(*) from Orders;";
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    OrderCnt = Convert.ToInt32(rdr["count(*)"].ToString());
                }

                return OrderCnt;
            }
			catch (Exception)
			{
                return OrderCnt;
            }
        }


        public string SqlOrderResult()
        {
            string result = null;

			try
			{
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select Product_Code from Orders where Order_No = (select min(Order_No) from Orders);";
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    result = rdr["Product_Code"].ToString();
                }

                return result;
            }
			catch (Exception)
			{
                return result;
			}
        }

        public void SqlDeleteResult()
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "delete from Orders where Order_No = (select min(Order_No) from Orders);";
            cmd.ExecuteNonQuery();
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

        public DataTable Orders()
        {
            DataTable table = new DataTable();

            if (table != null)
                table.Clear();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from Orders";

                SqlDataReader rdr = cmd.ExecuteReader();

                if (table.Columns.Count == 0)
                {
                    table.Columns.Add("주문번호");
                    table.Columns.Add("제품코드");
                    table.Columns.Add("사용자번호");
                    table.Columns.Add("주문시간");
                }

                while (rdr.Read())
                {

                    string Order_No = rdr["Order_No"].ToString();
                    string Product_Code = rdr["Product_Code"] as string;
                    string User_No = rdr["User_No"].ToString();
                    string Order_Time = rdr["Order_Time"].ToString();

                    string[] Order = new string[] { Order_No, Product_Code, User_No, Order_Time };

                    table.Rows.Add(Order);
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return table;
        }

        public List<string[]> Robot()
        {
            List<string[]> list = new List<string[]>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select Robot_No, Robot_Name, Robot_Part, Robot_State from Robot_i";
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Robot_No = rdr["Robot_No"].ToString();
                    string Robot_Code = rdr["Robot_Name"] as string;
                    string Robot_Part = rdr["Robot_Part"] as string;
                    string Robot_State = rdr["Robot_State"] as string;

                    string[] Robot = new string[] { Robot_No, Robot_Code, Robot_Part, Robot_State };
                    list.Add(Robot);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }
    }
}
