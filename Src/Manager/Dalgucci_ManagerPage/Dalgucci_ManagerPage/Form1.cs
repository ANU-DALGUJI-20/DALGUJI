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




namespace Dalgucci_ManagerPage
{
    public partial class Form1 : Form
    {
        string strConn = "Server=192.168.0.30;Database=SF1team;User Id=sa;Password=0924;";
        
        public void Orders()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

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
                    Order_View.Rows.Add(Order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

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
            Robot_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Order_View.AllowUserToAddRows = false;
            Robot_View.AllowUserToAddRows = false;
        }

  

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
       {

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
    
    }
}
