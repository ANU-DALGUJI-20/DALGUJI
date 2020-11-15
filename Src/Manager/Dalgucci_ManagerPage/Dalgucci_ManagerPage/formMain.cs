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
        
        Dictionary<string, Point> m_Robot2_Location = new Dictionary<string, Point>();
        Point Robot2_Current_Location = new Point(0, 0);
        Point Robot2_Target_Location = new Point(0, 0);

        public frmMain()
        {
            InitializeComponent();

            // 그림 바뀌면 좌표 수정!!!!!!!!!!!!!!!!!!
            m_Robot1_Location.Add("WIN01", new Point(1160, 344));
            m_Robot1_Location.Add("WOUT01", new Point(648, 344));
            m_Robot1_Location.Add("WMS03", new Point(1000, 344));
            m_Robot1_Location.Add("WMS02", new Point(912, 344));
            m_Robot1_Location.Add("WMS01", new Point(816, 344));
            m_Robot1_Location.Add("WSTG03", new Point(1000, 290));
            m_Robot1_Location.Add("WSTG02", new Point(912, 290));
            m_Robot1_Location.Add("WSTG01", new Point(816, 290));
            
            m_Robot2_Location.Add("MIN01", new Point(1408, 488));
            m_Robot2_Location.Add("MOUT01", new Point(648, 488));
            m_Robot2_Location.Add("MMS03", new Point(1000, 344));
            m_Robot2_Location.Add("MMS02", new Point(912, 344));
            m_Robot2_Location.Add("MMS01", new Point(816, 344));
            m_Robot2_Location.Add("MSTG03", new Point(1000, 290));
            m_Robot2_Location.Add("MSTG02", new Point(912, 290));
            m_Robot2_Location.Add("MSTG01", new Point(816, 290));
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
            int x1 = Robot1.Location.X;
            int y1 = Robot1.Location.Y;
            
            int x2 = Robot2.Location.X;
            int y2 = Robot2.Location.Y;

            // Robot 1
            if (x1 != Robot1_Target_Location.X)
            {
                if (Robot1_Current_Location.X < Robot1_Target_Location.X)
                {
                    x1 = Robot1.Location.X + 1;
                    y1 = Robot1.Location.Y;
                }
                if (Robot1_Current_Location.X > Robot1_Target_Location.X)
                {
                    x1 = Robot1.Location.X - 1;
                    y1 = Robot1.Location.Y;
                }
            }

            if (y1 != Robot1_Target_Location.Y)
            {
                if (Robot1_Current_Location.Y < Robot1_Target_Location.Y)
                {
                    x1 = Robot1.Location.X;
                    y1 = Robot1.Location.Y + 1;
                }
                if (Robot1_Current_Location.Y > Robot1_Target_Location.Y)
                {
                    x1 = Robot1.Location.X;
                    y1 = Robot1.Location.Y - 1;
                }
            }

            // Robot 2
            if (x2 != Robot2_Target_Location.X)
            {
                if (Robot2_Current_Location.X < Robot2_Target_Location.X)
                {
                    x2 = Robot2.Location.X + 1;
                    y2 = Robot2.Location.Y;
                }
                if (Robot2_Current_Location.X > Robot2_Target_Location.X)
                {
                    x2 = Robot2.Location.X - 1;
                    y2 = Robot2.Location.Y;
                }
            }

            if (y2 != Robot2_Target_Location.Y)
            {
                if (Robot2_Current_Location.Y < Robot2_Target_Location.Y)
                {
                    x2 = Robot2.Location.X;
                    y2 = Robot2.Location.Y + 1;
                }
                if (Robot2_Current_Location.Y > Robot2_Target_Location.Y)
                {
                    x2 = Robot2.Location.X;
                    y2 = Robot2.Location.Y - 1;
                }
            }

            // 여자 한복
			if (TcpIpServer.Position_Value() == "WIN01")
               Robot_move_1(ref x1, ref y1, "WIN01");
            if(TcpIpServer.Position_Value() == "WOUT01")
                Robot_move_1(ref x1, ref y1, "WOUT01");

            if(TcpIpServer.Position_Value() == "WSTG01")
                Robot_move_1(ref x1, ref y1, "WSTG01");
            if(TcpIpServer.Position_Value() == "WSTG02")
                Robot_move_1(ref x1, ref y1, "WSTG02");
            if(TcpIpServer.Position_Value() == "WSTG03")
                Robot_move_1(ref x1, ref y1, "WSTG03");

            if(TcpIpServer.Position_Value() == "WMS01")
                Robot_move_1(ref x1, ref y1, "WMS01");
            if(TcpIpServer.Position_Value() == "WMS02")
                Robot_move_1(ref x1, ref y1, "WMS02");
            if(TcpIpServer.Position_Value() == "WMS03")
                Robot_move_1(ref x1, ref y1, "WMS03");
            
            // 남자 한복
            if (TcpIpServer.Position_Value() == "MIN01")
               Robot_move_2(ref x2, ref y2, "MIN01");
            if(TcpIpServer.Position_Value() == "MOUT01")
                Robot_move_2(ref x2, ref y2, "MOUT01");

            if(TcpIpServer.Position_Value() == "MSTG01")
                Robot_move_2(ref x2, ref y2, "MSTG01");
            if(TcpIpServer.Position_Value() == "MSTG02")
                Robot_move_2(ref x2, ref y2, "MSTG02");
            if(TcpIpServer.Position_Value() == "MSTG03")
                Robot_move_2(ref x2, ref y2, "MSTG03");

            if(TcpIpServer.Position_Value() == "MMS01")
                Robot_move_2(ref x2, ref y2, "MMS01");
            if(TcpIpServer.Position_Value() == "MMS02")
                Robot_move_2(ref x2, ref y2, "MMS02");
            if(TcpIpServer.Position_Value() == "MMS03")
                Robot_move_2(ref x2, ref y2, "MMS03");


            Robot1.Location = new Point(x1, y1);
            Robot2.Location = new Point(x2, y2);
            Update();
        }

        private void Robot_move_1(ref int x1, ref int y1, string position)
		{
            string Robot1_location = position;
            Robot1_Current_Location = Robot1.Location;
            Robot1_Target_Location = m_Robot1_Location[Robot1_location];

            TcpIpServer.Position_End();
        }
        
        private void Robot_move_2(ref int x2, ref int y2, string position)
		{
            string Robot2_location = position;
            Robot2_Current_Location = Robot2.Location;
            Robot2_Target_Location = m_Robot2_Location[Robot2_location];

            TcpIpServer.Position_End();
        }
	}
}
