using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Dalgucci_ManagerPage
{
	public partial class formRobotCom_2 : Form
	{
        BarcodeReader barcodeReader = new BarcodeReader();

        MJPEGStream Robot3;
        MJPEGStream Robot4;

        struct stTarget_02
        {
            public string input;
            public string Route;
            public string Dest;
            public string output;
            public stTarget_02(string _input, string _Route, string _Dest, string _output)
            {
                input = _input;
                Route = _Route;
                Dest = _Dest;
                output = _output;
            }

        }
        Dictionary<string, stTarget_02> DicmanTarget = new Dictionary<string, stTarget_02>();

        stTarget_02 target_man = new stTarget_02();
        string man_route_code = "";
        int man_seq_step = 0;
        int man_tickcount_ms = 0;

        public bool man_tick_start = false;
        public string man_INPUT_OUTPUT = "";
        public string man_product_code = "";

        public delegate void Del_SendCommand_man(string _in_out, string _prod_code);
        public Del_SendCommand_man fnSendCommand_manCallback;

        public formRobotCom_2()
		{
            DicmanTarget.Add("2001", new stTarget_02("MIN01", "MMS01", "MSTG01", "MOUT01"));
            DicmanTarget.Add("2002", new stTarget_02("MIN01", "MMS02", "MSTG02", "MOUT01"));
            DicmanTarget.Add("2003", new stTarget_02("MIN01", "MMS03", "MSTG03", "MOUT01"));

            InitializeComponent();
            Robot3 = new MJPEGStream("http://192.168.0.9:8081");
            Robot3.NewFrame += Robot1_NewFrame;
            Robot3.Start();
            Robot2_floor_timer.Start();


            Robot4 = new MJPEGStream("http://192.168.0.9:8083");
            Robot4.NewFrame += Robot2_NewFrame;
            Robot4.Start();
            Robot2_prod_timer.Start();


            fnSendCommand_manCallback += SendCommand_man;
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        private void Robot2_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            CCTV3.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Robot1_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            CCTV4.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void formRobotCom_2_Load(object sender, EventArgs e)
		{
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        private void QR_test2_TextChanged(object sender, EventArgs e)
        {

        }

  

        private void formRobotCom_2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Robot3.IsRunning)
                Robot3.Stop();

            else if (Robot4.IsRunning)
                Robot4.Stop();
        }

        private static string sQRcode = "";
        public static string QRcode_Value()
        {
            return sQRcode;
        }
        public static string QRcode_End()
        {
            sQRcode = "";
            return sQRcode;
        }

        public void SendCommand_man(string _in_out, string _prod_code)
        {
            if (tmr_man_seq.Enabled == false)
            {
                tmr_man_seq.Stop();
                tmr_man_seq.Enabled = false;

                target_man = DicmanTarget[_prod_code];

                man_product_code = _prod_code;
                man_INPUT_OUTPUT = _in_out;

                man_seq_step = 0;
                tmr_man_seq.Enabled = true;

                tmr_man_seq.Interval = 100;

                tmr_man_seq.Start();
            }
        }

        private void Robot2_floor_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 바닥
                if (CCTV3.Image != null)
                {
                    Result result = barcodeReader.Decode((Bitmap)CCTV3.Image);
                    if (result != null)
                    {
                        QR_test1.Text = result.ToString();
                        sQRcode = result.ToString();
                        man_route_code = sQRcode;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Robot2_prod_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 물품
                if (CCTV4.Image != null)
                {
                    Result result = barcodeReader.Decode((Bitmap)CCTV4.Image);

                    if (result != null)
                    {
                        QR_test2.Text = result.ToString();
                        sQRcode = result.ToString();
                        SendCommand_man("INPUT", sQRcode);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void tmr_man_seq_Tick(object sender, EventArgs e)
        {
            switch (man_seq_step)
            {
                case 0:
                    {
                        if (target_man.Route == null || target_man.Dest == null)
                        {
                            tmr_man_seq.Enabled = false;
                            tmr_man_seq.Stop();
                        }

                        if (target_man.Route == "" || target_man.Dest == "")
                        {
                            tmr_man_seq.Enabled = false;
                            tmr_man_seq.Stop();
                        }

                        man_seq_step = 5;
                    }
                    break;
                case 5:
                    {
                        if (man_INPUT_OUTPUT == "INPUT")
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "UP");
                        }
                        else if (man_INPUT_OUTPUT == "OUTPUT")
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "DOWN");
                        }

                        man_tickcount_ms = Environment.TickCount;
                        man_seq_step = 6;
                    }
                    break;
                case 6:
                    {
                        int now_tickcount = Environment.TickCount;
                        if (now_tickcount > man_tickcount_ms + 3000)
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "FORWARD");
                            man_seq_step = 20;
                        }
                    }
                    break;
                case 20:
                    {
                        if (man_route_code == target_man.Route)
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "STOP");
                            man_seq_step = 30;
                        }
                    }
                    break;
                case 30:
                    {
                        TcpIpServer.SendCmdToMan("MOVE", "LEFT_TURN_90");
                        man_seq_step = 40;
                    }
                    break;
                case 40:
                    {
                        if (man_route_code == target_man.Dest)
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "STOP");
                            man_seq_step = 50;
                        }
                    }
                    break;
                case 50:
                    {
                        if (man_INPUT_OUTPUT == "INPUT")
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "DOWN");
                        }
                        else if (man_INPUT_OUTPUT == "OUTPUT")
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "UP");
                        }

                        man_tickcount_ms = Environment.TickCount;
                        man_seq_step = 60;
                    }
                    break;
                case 60:
                    {
                        int now_tickcount = Environment.TickCount;
                        if (now_tickcount > man_tickcount_ms + 3000)
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "RIGHT_TURN_180");
                            man_seq_step = 70;
                        }
                    }
                    break;
                case 70:
                    {
                        if (man_route_code == target_man.Route)
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "STOP");
                            man_seq_step = 75;
                        }
                    }
                    break;
                case 75:
                    {
                        if (man_INPUT_OUTPUT == "INPUT")
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "RIGHT_TURN_90");
                        }
                        else if (man_INPUT_OUTPUT == "OUTPUT")
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "LEFT_TURN_90");
                        }
                    }
                    break;
                case 80:
                    {
                        TcpIpServer.SendCmdToMan("MOVE", "FORWARD");
                        man_seq_step = 90;
                    }
                    break;
                case 90:
                    {
                        if (man_INPUT_OUTPUT == "INPUT")
                        {
                            if (man_route_code == target_man.input)
                            {
                                TcpIpServer.SendCmdToMan("MOVE", "STOP");
                                tmr_man_seq.Enabled = false;
                                tmr_man_seq.Stop();
                                Program.g_frmMain.AddConsoleOutput("작업 완료/입고 완료");

                                Program.data.insertValue(man_product_code, target_man.Dest);
                                Program.g_frmMain.AddConsoleOutput("입고기록 삽입");
                            }
                        }
                        else if (man_INPUT_OUTPUT == "OUTPUT")
                        {
                            if (man_route_code == target_man.output)
                            {
                                TcpIpServer.SendCmdToMan("MOVE", "STOP");
                                man_seq_step = 100;
                            }
                        }
                    }
                    break;
                case 100:
                    {
                        TcpIpServer.SendCmdToMan("MOVE", "DOWN");

                        man_tickcount_ms = Environment.TickCount;
                        man_seq_step = 105;
                    }
                    break;
                case 105:
                    {
                        TcpIpServer.SendCmdToMan("MOVE", "LEFT_TURN_90");
                        man_seq_step = 110;
                    }
                    break;
                case 110:
                    {
                        int now_tickcount = Environment.TickCount;
                        if (now_tickcount > man_tickcount_ms + 3000)
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "FORWARD");
                            man_seq_step = 120;
                        }
                    }
                    break;
                case 120:
                    {
                        if (man_route_code == target_man.input)
                        {
                            TcpIpServer.SendCmdToMan("MOVE", "STOP");
                            tmr_man_seq.Enabled = false;
                            tmr_man_seq.Stop();
                            Program.g_frmMain.AddConsoleOutput("작업 완료/출고 완료");

                            Program.data.RowDelete();
                            Program.g_frmMain.AddConsoleOutput("주문 테이블 삭제");

                            Program.data.insertValue(man_product_code, target_man.Dest);
                            Program.g_frmMain.AddConsoleOutput("출고기록 삽입");
                        }
                    }
                    break;
            }
        }

        private void tmr_man_Tick(object sender, EventArgs e)
        {
            if (man_tick_start == true && tmr_man_seq.Enabled == false)
            {
                man_tick_start = false;
                SendCommand_man(man_INPUT_OUTPUT, man_product_code);
            }
        }
    }
}
