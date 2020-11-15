using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dalgucci
{

    public class Database
    {
        SqlConnection conn = null; 
        private object lockObject = new object();

        public Database()
        {
            string strConn = "Server=127.0.0.1;Database=SF1team;User Id=sa;Password=1234;";
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public int OrdersCountResult()
        {
			lock (lockObject)
			{
                int OrderCnt = 0;
                SqlDataReader rdr = null;

                try
                {

                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select count(*) as count from Orders;";
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string cnt = rdr["count"].ToString();
                        OrderCnt = Convert.ToInt32(cnt);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(MethodBase.GetCurrentMethod().Name + ex.Message);
                }

                return OrderCnt;
            }
        }

        public string OrderSelectResult()
        {
            lock (lockObject)
            {
                string result = null;
                SqlDataReader rdr = null;

                try
                {

                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "select Product_Code from Orders where Order_No = (select min(Order_No) from Orders);";
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        result = rdr["Product_Code"].ToString();
                    }

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(MethodBase.GetCurrentMethod().Name + ex.Message);
                }

                return result;
            }
        }

        public void RowDelete()
        {
			try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "delete from Orders where Order_No = (select min(Order_No) from Orders);";
                cmd.ExecuteNonQuery();
            }
			catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name + ex.Message);
            }
        }

        public void insertValue(string product_code)
		{
            try
            {

                if (conn.State != ConnectionState.Open)
                    conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = $"insert into Input_Log values (3,'{product_code}',getdate());";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name + ex.Message);
            }
        }

		public DataTable InProdHistory()
		{
			lock (lockObject)
			{
				DataTable table = new DataTable();
				SqlDataReader rdr = null;

				if (table != null)
					table.Clear();

				try
				{
					SqlCommand cmd = new SqlCommand();
					cmd.Connection = conn;

					cmd.CommandText = "select * from Input_Log";

					rdr = cmd.ExecuteReader();

					if (table.Columns.Count == 0)
					{
						table.Columns.Add("입고번호");
						table.Columns.Add("제품코드");
						//table.Columns.Add("제품위치");
						table.Columns.Add("입고시간");
					}

					while (rdr.Read())
					{

						string InProduct_No = rdr["Input_No"].ToString();
						string Product_Code = rdr["Product_Code"] as string;
						//string Product_Place = rdr["Product_Place"].ToString();
						string In_Time = rdr["In_Time"].ToString();

						string[] Input_Log = new string[] { InProduct_No, Product_Code, /*Product_Place,*/ In_Time };

						table.Rows.Add(Input_Log);
					}
                    rdr.Close();
                }

				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				return table;
			}
		}

		public DataTable OutProdHistory()
		{
			lock (lockObject)
			{
				DataTable table = new DataTable();
				SqlDataReader rdr = null;

				try
				{
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    SqlCommand cmd = new SqlCommand();
					cmd.Connection = conn;

					cmd.CommandText = "select * from Output_Log";

					rdr = cmd.ExecuteReader();

					if (table.Columns.Count == 0)
					{
						table.Columns.Add("출고번호");
						table.Columns.Add("제품코드");
						table.Columns.Add("제품위치");
						table.Columns.Add("출고시간");
					}

					while (rdr.Read())
					{

						string OutProduct_No = rdr["Output_No"].ToString();
						string Product_Code = rdr["Product_Code"] as string;
						string Product_Place = rdr["Product_Place"].ToString();
						string Out_Time = rdr["Out_Time"].ToString();

						string[] Output_Log = new string[] { OutProduct_No, Product_Code, Product_Place, Out_Time };

						table.Rows.Add(Output_Log);
                    }
                    rdr.Close();
                }
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}

				return table;
			}
		}

		public DataTable Orders()
        {
            lock (lockObject)
            {
                DataTable table = new DataTable();
                SqlDataReader rdr = null;

                if (table != null)
                    table.Clear();

                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "select * from Orders";
                    rdr = cmd.ExecuteReader();

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

                    rdr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(MethodBase.GetCurrentMethod().Name + ex.Message);
                }

                return table;
            }
        }
    }
}
