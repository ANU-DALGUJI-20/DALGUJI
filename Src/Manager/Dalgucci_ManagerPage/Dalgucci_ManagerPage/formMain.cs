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
        private void Input_Click(object sender, EventArgs e)
        {
        }

        private void Order_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Robot1_Click(object sender, EventArgs e)
        {

        }

        private void Robot2_Click(object sender, EventArgs e)
        {

        }

        private void Robot_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void test_TextChanged(object sender, EventArgs e)
        {

        }

        public void Grid_Style()
        {
            Order_View.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Robot_View.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Order_View.RowHeadersVisible = false;
            Robot_View.RowHeadersVisible = false;

            Order_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Robot_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Order_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Robot_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Order_View.AllowUserToAddRows = false;
            Robot_View.AllowUserToAddRows = false;


            //AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }

        Dictionary<string, Point> m_Robot1_Location = new Dictionary<string, Point>();
        Point Robot1_Current_Location = new Point(0, 0);
        Point Robot1_Target_Location = new Point(0, 0);

        public frmMain()
        {
            InitializeComponent();

            m_Robot1_Location.Add("WIN01", new Point(1160, 344));
            m_Robot1_Location.Add("WOUT01", new Point(648, 344));
            m_Robot1_Location.Add("WMS03", new Point(1000, 344));
            m_Robot1_Location.Add("WMS02", new Point(912, 344));
            m_Robot1_Location.Add("WMS01", new Point(816, 344));
            m_Robot1_Location.Add("WSTG03", new Point(1000, 290));
            m_Robot1_Location.Add("WSTG02", new Point(912, 290));
            m_Robot1_Location.Add("WSTG01", new Point(816, 290));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Order_View.DataSource = Program.data.Orders();
            timer1.Enabled = true;
            timer1.Start();
            Grid_Style();
        }

        private void Data_Click(object sender, EventArgs e)
        {
            frmInOutHistory inOutHistory = new frmInOutHistory();
            inOutHistory.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Order_View.DataSource = Program.data.Orders();

            //Robot_View.Rows.Clear();
            //List<string[]> robot_list = Program.data.Robot();
            //foreach (var item in robot_list)
            //{
            //    Robot_View.Rows.Add(item);
            //}
        }

        private void Output_Click(object sender, EventArgs e)
        {
            //string text = test.Text;
            string Robot1_location = test.Text;
            Robot1_Current_Location = Robot1.Location;
            Robot1_Target_Location = m_Robot1_Location[Robot1_location];

        }

        

        private void CCTV_Click(object sender, EventArgs e)
        {
            formRobotCom Form = new formRobotCom();
            Form.Show();
        }

        

        private void tmr_RobotAnimation_Tick(object sender, EventArgs e)
        {
            int x = Robot1.Location.X;
            int y = Robot1.Location.Y;

            if (x != Robot1_Target_Location.X)
            {
                if (Robot1_Current_Location.X < Robot1_Target_Location.X)
                {
                    x = Robot1.Location.X + 1;
                    y = Robot1.Location.Y;
                }
                if (Robot1_Current_Location.X > Robot1_Target_Location.X)
                {
                    x = Robot1.Location.X - 1;
                    y = Robot1.Location.Y;
                }
            }

            if (y != Robot1_Target_Location.Y)
            {
                if (Robot1_Current_Location.Y < Robot1_Target_Location.Y)
                {
                    x = Robot1.Location.X;
                    y = Robot1.Location.Y + 1;
                }
                if (Robot1_Current_Location.Y > Robot1_Target_Location.Y)
                {
                    x = Robot1.Location.X;
                    y = Robot1.Location.Y - 1;
                }
            }

			if (TcpIpServer.Position_Value() == "WIN01")
               move(ref x, ref y, "WIN01");
            if(TcpIpServer.Position_Value() == "WOUT01")
                move(ref x, ref y, "WOUT01");

            if(TcpIpServer.Position_Value() == "WSTG01")
                move(ref x, ref y, "WSTG01");
            if(TcpIpServer.Position_Value() == "WSTG02")
                move(ref x, ref y, "WSTG02");
            if(TcpIpServer.Position_Value() == "WSTG03")
                move(ref x, ref y, "WSTG03");

            if(TcpIpServer.Position_Value() == "WMS01")
                move(ref x, ref y, "WMS01");
            if(TcpIpServer.Position_Value() == "WMS02")
                move(ref x, ref y, "WMS02");
            if(TcpIpServer.Position_Value() == "WMS03")
                move(ref x, ref y, "WMS03");
            Robot1.Location = new Point(x, y);
            Update();
        }

        private void move(ref int x, ref int y, string position)
		{
            string Robot1_location = position;
            Robot1_Current_Location = Robot1.Location;
            Robot1_Target_Location = m_Robot1_Location[Robot1_location];

            TcpIpServer.Position_End();
        }
	}
}

