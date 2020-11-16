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
            TcpIpServer.SendCmdToMan("SIMUL", "PROD_PLACEMENT");
        }

        private void Output_Click(object sender, EventArgs e)
        {
            TcpIpServer.SendCmdToWoman("SIMUL", "PROD_PLACEMENT");
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

            Order_View.RowHeadersVisible = false;

            Order_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Order_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Order_View.AllowUserToAddRows = false;

            //AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
        }

        Dictionary<string, Point> m_Robot1_Location = new Dictionary<string, Point>();
        Point Robot1_Current_Location = new Point(0, 0);
        Point Robot1_Target_Location = new Point(0, 0);
        
        Dictionary<string, Point> m_Robot2_Location = new Dictionary<string, Point>();
        Point Robot2_Current_Location = new Point(0, 0);
        Point Robot2_Target_Location = new Point(0, 0);

        List<string> list_Console_Output = new List<string>();

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
            string strWoman = TcpIpServer.Position_Value();
            Robot_move_1(strWoman);

            // 남자 한복
            string strMan = TcpIpServer.Position_Value();
            Robot_move_2(strMan);

            Robot1.Location = new Point(x1, y1);
            Robot2.Location = new Point(x2, y2);
            Update();
        }

        private void Robot_move_1(string position)
		{
            if(position == "" || position == null)
                return;

            string Robot1_location = position;
            Robot1_Current_Location = Robot1.Location;
            Robot1_Target_Location = m_Robot1_Location[Robot1_location];

            TcpIpServer.Position_End();
        }
        
        private void Robot_move_2(string position)
		{
            if (position == "" || position == null)
                return;

            string Robot2_location = position;
            Robot2_Current_Location = Robot2.Location;
            Robot2_Target_Location = m_Robot2_Location[Robot2_location];

            TcpIpServer.Position_End();
        }

        public void AddConsoleOutput( string _log )
		{
            string date = System.DateTime.Now.ToString("[hh:mm:ss] ");

            list_Console_Output.Add(date + _log);
        }
        
		private void trmConsloeOutput_Tick(object sender, EventArgs e)
		{
            if( list_Console_Output.Count > 0)
			{
                Console_output.Items.Add(list_Console_Output[0]);
                list_Console_Output.RemoveAt(0);
                this.Console_output.SelectedIndex = this.Console_output.Items.Count - 1;
            }

            if( Console_output.Items.Count > 5000)
			{
                Console_output.Items.RemoveAt(0);
            }

        }

		private void Console_output_DrawItem(object sender, DrawItemEventArgs e)
		{
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Black);//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(Console_output.Items[e.Index].ToString(), e.Font, Brushes.Lime, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void QRcode_Read_Tick(object sender, EventArgs e)
        {
          
        }

        private void Robot1_read_Click(object sender, EventArgs e)
        {

        }
    }
}
