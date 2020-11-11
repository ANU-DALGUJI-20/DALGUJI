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
    public partial class frmInOutHistory : Form
    {
        string strConn = "Server=127.0.0.1;Database=SF1team;User Id=sa;Password=0924;";

        public void In()
        {
            DataTable table = new DataTable();
            BindingSource bs = new BindingSource();

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();


            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from Input_Log";

                SqlDataReader rdr = cmd.ExecuteReader();

                if (table.Columns.Count == 0)
                {
                    table.Columns.Add("입고번호");
                    table.Columns.Add("제품코드");
                    table.Columns.Add("제품위치");
                    table.Columns.Add("입고시간");
                }

                while (rdr.Read())
                {

                    string InProduct_No = rdr["InProduct_No"].ToString();
                    string Product_Code = rdr["Product_Code"] as string;
                    string Product_Place = rdr["Product_Place"].ToString();
                    string In_Time = rdr["In_Time"].ToString();

                    string[] Input_Log = new string[] { InProduct_No, Product_Code, Product_Place, In_Time };

                    table.Rows.Add(Input_Log);
                }

                In_Log.DataSource = bs;
                bs.DataSource = table;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        public void Out()
        {
            DataTable table = new DataTable();
            BindingSource bs = new BindingSource();

            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();


            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from Output_Log";

                SqlDataReader rdr = cmd.ExecuteReader();

                if (table.Columns.Count == 0)
                {
                    table.Columns.Add("출고번호");
                    table.Columns.Add("제품코드");
                    table.Columns.Add("제품위치");
                    table.Columns.Add("출고시간");
                }

                while (rdr.Read())
                {

                    string OutProduct_No = rdr["OutProduct_No"].ToString();
                    string Product_Code = rdr["Product_Code"] as string;
                    string Product_Place = rdr["Product_Place"].ToString();
                    string Out_Time = rdr["Out_Time"].ToString();

                    string[] Output_Log = new string[] { OutProduct_No, Product_Code, Product_Place, Out_Time };

                    table.Rows.Add(Output_Log);
                }

                Out_Log.DataSource = bs;
                bs.DataSource = table;

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        public void Grid_Style()
        {
            In_Log.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Out_Log.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            In_Log.RowHeadersVisible = false;
            Out_Log.RowHeadersVisible = false;

            In_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Out_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            In_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Out_Log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            In_Log.AllowUserToAddRows = false;
            Out_Log.AllowUserToAddRows = false;


            //AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }
        public frmInOutHistory()
        {
            InitializeComponent();
        }

        private void INOUT_Timer_Tick(object sender, EventArgs e)
        {
            In();
            Out();
        }

        private void formInOutHistory_Load(object sender, EventArgs e)
        {
            Grid_Style();
            In();
            Out();
        }

        private void In_Log_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Out_Log_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
