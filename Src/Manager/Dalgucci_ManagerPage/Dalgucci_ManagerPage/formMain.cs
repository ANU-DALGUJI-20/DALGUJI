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




        Dictionary<string, Point> m_Robot1_Location = new Dictionary<string, Point>();
        Point Robot1_Current_Location = new Point(0, 0);
        Point Robot1_Target_Location = new Point(0, 0);

        //----------------------------------------------------------------------------------------------------------------------------
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

        private void Order_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Data_Click(object sender, EventArgs e)
        {
            frmInOutHistory inOutHistory = new frmInOutHistory();
            inOutHistory.Show();

        }

        private void Robot_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void Output_Click(object sender, EventArgs e)
        {
            //string text = test.Text;
            string Robot1_location = test.Text;
            Robot1_Current_Location = Robot1.Location;
            Robot1_Target_Location = m_Robot1_Location[Robot1_location];



            //1001
            //if (po == 0)
            //WMS03();
            //else if(po == 1)
            //WMS02();
            //else if(po == 2)
            //WMS01();
            //else if(po == 3)
            //Robot1_Up();
            //else if(po == 4)
            //Robot1_Back();
            //else if(po ==5)
            //Robot1_OUTPlace();
            //else if(po == 6)
            //WMS01_Back();
            //else if(po==7)
            //WMS02_Back();
            //else if(po == 8)
            //WMS03_Back();
            //else if (po == 9)
            //Robot1_INPlace();


            //// 1002
            //WMS03();
            //WMS02();
            //Robot1_Up();
            //Robot1_Back();
            //WMS01();

            //Robot1_OUTPlace();
            //WMS01_Back();
            //WMS02_Back();
            //WMS03_Back();
            //Robot1_INPlace();

            //// 1003
            //WMS03();
            //Robot1_Up();
            //Robot1_Back();
            //WMS02();
            //WMS01();
            //Robot1_OUTPlace();
            //WMS01_Back();
            //WMS02_Back();
            //WMS03_Back();
            //Robot1_INPlace();

            //// 2001
            //MMS03();
            //MMS02();
            //MMS01();
            //Robot2_Down();
            //Robot2_Back();

            //Robot2_OUTPlace();
            //MMS01_Back();
            //MMS02_Back();
            //MMS03_Back();
            //Robot2_INPlace();

            //// 2002
            //MMS03();
            //MMS02();
            //Robot2_Down();
            //Robot2_Back();
            //MMS01();

            //Robot2_OUTPlace();
            //MMS01_Back();
            //MMS02_Back();
            //MMS03_Back();
            //Robot2_INPlace();

            //// 2003
            //MMS03();
            //Robot2_Down();
            //Robot2_Back();
            //MMS02();
            //MMS01();

            //Robot2_OUTPlace();
            //MMS01_Back();
            //MMS02_Back();
            //MMS03_Back();
            //Robot2_INPlace();




        }

        private void Robot1_Click(object sender, EventArgs e)
        {

        }

        private void Robot2_Click(object sender, EventArgs e)
        {

        }

        private void CCTV_Click(object sender, EventArgs e)
        {
            formRobotCom Form = new formRobotCom();
            Form.Show();
        }

        private void test_TextChanged(object sender, EventArgs e)
        {

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

            Robot1.Location = new Point(x, y);
            Update();
        }

        private void Input_Click(object sender, EventArgs e)
        {

        }
    }
}
