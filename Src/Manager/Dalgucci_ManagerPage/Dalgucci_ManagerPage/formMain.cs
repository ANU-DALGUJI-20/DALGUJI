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
using System.Threading;

namespace Dalgucci_ManagerPage
{
    public partial class frmMain : MaterialForm
    {
        string strConn = "Server=192.168.0.30;Database=SF1team;User Id=sa;Password=0924;";
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

        //로봇 1 -------------------------------------------------------------------------------------------------------

        // 경로 이동
   
        public void WMS01()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            Robot1.Location = new Point(i, j);

            while (i > 750)
            {
                i -= 1;
                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }

        public void WMS02()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            Robot1.Location = new Point(i, j);

            while (i > 845)
            {
                i -= 1;
                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }

        public void WMS03()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            Robot1.Location = new Point(i, j);

            while (i > 940)
            {
                i -= 1;
                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }

        // 물품으로 이동
        public void Robot1_Up()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            while (j > 250)
            {
                j -= 1;

                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }
        //돌아옴
        public void Robot1_Back()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            while (j < 300)
            {
                j += 1;

                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }

        //출고 위치로
        public void Robot1_OUTPlace()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            Robot1.Location = new Point(i, j);

            while (i > 590)
            {
                i -= 1;
                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }

        // 돌아가는 경로
        public void WMS01_Back()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            Robot1.Location = new Point(i, j);

            while (i < 750)
            {
                i += 1;
                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }

        public void WMS02_Back()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            Robot1.Location = new Point(i, j);

            while (i < 845)
            {
                i += 1;
                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }

        public void WMS03_Back()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            Robot1.Location = new Point(i, j);

            while (i < 940)
            {
                i += 1;
                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }

        // 입고 장소로
        public void Robot1_INPlace()
        {
            int i, j;
            i = Robot1.Location.X.GetHashCode();
            j = Robot1.Location.Y.GetHashCode();

            Robot1.Location = new Point(i, j);

            while (i < 1100)
            {
                i += 1;
                Thread.Sleep(5);
                Robot1.Location = new Point(i, j);
                Update();
            }
        }


        //로봇2 ------------------------------------------------------------------------------------------------------

        //경로이동
        public void MMS01()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            Robot2.Location = new Point(i, j);

            while (i > 750)
            {
                i -= 1;
                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }

        public void MMS02()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            Robot2.Location = new Point(i, j);

            while (i > 845)
            {
                i -= 1;
                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }

        public void MMS03()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            Robot2.Location = new Point(i, j);

            while (i > 940)
            {
                i -= 1;
                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }

        // 물품으로 이동
        public void Robot2_Down()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            while (j < 480)
            {
                j += 1;

                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }

        // 돌아옴
        public void Robot2_Back()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            while (j > 427)
            {
                j -= 1;

                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }

        // 출고 위치로
        public void Robot2_OUTPlace()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            Robot2.Location = new Point(i, j);

            while (i > 590)
            {
                i -= 1;
                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }


        // 돌아가기 경로

        public void MMS01_Back()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            Robot2.Location = new Point(i, j);

            while (i < 750)
            {
                i += 1;
                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }

        public void MMS02_Back()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            Robot2.Location = new Point(i, j);

            while (i < 845)
            {
                i += 1;
                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }

        public void MMS03_Back()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            Robot2.Location = new Point(i, j);

            while (i < 940)
            {
                i += 1;
                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }

        // 입고 장소로
        public void Robot2_INPlace()
        {
            int i, j;
            i = Robot2.Location.X.GetHashCode();
            j = Robot2.Location.Y.GetHashCode();

            Robot2.Location = new Point(i, j);

            while (i < 1100)
            {
                i += 1;
                Thread.Sleep(5);
                Robot2.Location = new Point(i, j);
                Update();
            }
        }




        //----------------------------------------------------------------------------------------------------------------------------
        public frmMain()
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
            frmInOutHistory form2 = new frmInOutHistory();
            form2.Show();
        }

        private void Robot_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Orders();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

     

        private void Output_Click(object sender, EventArgs e)
        {
            WMS03();
            WMS02();
            Robot1_Up();
            Robot1_Back();
            WMS01();
            
            Robot1_OUTPlace();
            WMS01_Back();
            WMS02_Back();
            WMS03_Back();
            Robot1_INPlace();



        }

        private void Robot1_Click(object sender, EventArgs e)
        {

        }

        private void Robot2_Click(object sender, EventArgs e)
        {

        }
    }
}

