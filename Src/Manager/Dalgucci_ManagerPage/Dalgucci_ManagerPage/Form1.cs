using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;




namespace Dalgucci_ManagerPage
{
    public partial class Form1 : MaterialForm
    {
        string strConn = "Server=192.168.131.13;Database=SF1team;User Id=sa;Password=0924;";
        DataTable table = new DataTable();
        BindingSource bs = new BindingSource();

        public void Orders()
        {
            // List<Donation> donationList = new List<Donation>();

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

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

                Order_View.DataSource = bs;
                bs.DataSource = table;
                //Order_View.CurrentCell = Order_View.SelectedRows[0].Cells[0]
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

        }
        //class Donation
        //{
        //    public int Order_No { get; set; }
        //    public string Product_Code { get; set; }

        //    public int User_No { get; set; }

        //    public DateTime Order_Time { get; set; }
        //}
        public void Robot()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

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
                    Robot_View.Rows.Add(Robot);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Grid_Style()
        {
            Order_View.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Robot_View.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Order_View.RowHeadersVisible = false;
            Robot_View.RowHeadersVisible = false;

            Order_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Robot_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //Order_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Robot_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Order_View.AllowUserToAddRows = false;
            Robot_View.AllowUserToAddRows = false;


            //AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }



        public Form1()
        {
            InitializeComponent();


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Grid_Style();
            Orders();
            Robot();


        }

        private void Order_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Data_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Robot_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Orders();
        }
    }
}

