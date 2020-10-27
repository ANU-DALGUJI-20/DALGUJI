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
    public partial class Form2 : Form
    {
        string strConn = "Server=192.168.0.30;Database=SF1team;User Id=sa;Password=0924;";
        public Form2()
        {
            InitializeComponent();
        }
        public void Input_Log()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from Input_Log";
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Input_No = rdr["Input_No"].ToString();
                    string Product_Code = rdr["Product_Code"] as string;
                    string In_Time = rdr["In_Time"].ToString();
                   

                    string[] Input_Log = new string[] { Input_No, Product_Code, In_Time };
                    dataGridView1.Rows.Add(Input_Log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void Output_Log()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from Output_Log";
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string Output_No = rdr["Output_No"].ToString();
                    string Product_Code = rdr["Product_Code"] as string;
                    string Out_Time = rdr["Out_Time"].ToString();
                    

                    string[] Output_Log = new string[] { Output_No, Product_Code, Out_Time };
                    dataGridView2.Rows.Add(Output_Log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //맨 앞 열 삭제
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            // 그리드뷰 컬럼폭 채우기
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // 데이터 그리드 뷰 가득 채우기
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //마지막행 삭제
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
