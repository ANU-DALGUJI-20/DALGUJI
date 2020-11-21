using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace Dalgucci_ManagerPage
{
    public partial class formRobotCom : Form
    {
        BarcodeReader barcodeReader = new BarcodeReader();

        MJPEGStream Robot1;
        MJPEGStream Robot2;

        struct stTarget
        {
            public string input;
            public string Route;
            public string Dest;
            public string output;
            public stTarget(string _input, string _Route, string _Dest, string _output)
            {
                input = _input;
                Route = _Route;
                Dest = _Dest;
                output = _output;
            }
        }

        Dictionary<string, stTarget> DicWomanTarget = new Dictionary<string, stTarget>();

        stTarget target_woman = new stTarget();
        string woman_route_code = "";
        int woman_seq_step = 0;
        int woman_tickcount_ms = 0;
        string woman_INPUT_OUTPUT = "";
        string woman_product_code = "";


        public formRobotCom()
        {
            DicWomanTarget.Add("1001", new stTarget("WIN01","WMS01", "WSTG01","WOUT01"));
            DicWomanTarget.Add("1002", new stTarget("WIN01","WMS02", "WSTG02","WOUT01"));
            DicWomanTarget.Add("1003", new stTarget("WIN01","WMS03", "WSTG03","WOUT01"));

            InitializeComponent();
            Robot1 = new MJPEGStream("http://192.168.0.154:8081");
            Robot1.NewFrame += Robot1_NewFrame;
            Robot1.Start();
            Robot1_floor_timer.Start();


            Robot2 = new MJPEGStream("http://192.168.0.154:8083");
            Robot2.NewFrame += Robot2_NewFrame;
            Robot2.Start();
            Robot1_prod_timer.Start();
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        private void Robot1_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            CCTV.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Robot2_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            CCTV2.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void formRobotCom_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        private void formRobotCom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Robot1.IsRunning)
                Robot1.Stop();

            else if (Robot2.IsRunning)
                Robot2.Stop();
        }

        private void CCTV2_Click(object sender, EventArgs e)
        {

        }

        private void TextTest2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

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

        public void SendCommand_Woman(string _in_out, string _prod_code)
        {
            if (tmr_woman_seq.Enabled == false)
            {
                target_woman = DicWomanTarget[_prod_code];
                woman_product_code = _prod_code;

                woman_INPUT_OUTPUT = _in_out;

                woman_seq_step = 0;
                tmr_woman_seq.Enabled = true;
                tmr_woman_seq.Start();
            }
        }

        private void Robot1_floor_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 바닥
                if (CCTV.Image != null)
                {
                    Result result = barcodeReader.Decode((Bitmap)CCTV.Image);
                    if (result != null)
                    {
                        testTextBox.Text = result.ToString();
                        sQRcode = result.ToString();
                        woman_route_code = sQRcode;
                    }
                }
            }
            catch( Exception ex)
            {

            }
        }

        private void Robot1_prod_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 물품
                if (CCTV2.Image != null)
                {
                    Result result = barcodeReader.Decode((Bitmap)CCTV2.Image);

                    if (result != null)
                    {
                        TextTest2.Text = result.ToString();
                        sQRcode = result.ToString();
                        SendCommand_Woman("INPUT", sQRcode);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void tmr_woman_seq_Tick(object sender, EventArgs e)
        {
            switch(woman_seq_step)
            {
                case 0:
                    {
                        if (target_woman.Route == null || target_woman.Dest == null)
                        {
                            tmr_woman_seq.Enabled = false;
                            tmr_woman_seq.Stop();
                        }

                        if (target_woman.Route == "" || target_woman.Dest == "")
                        {
                            tmr_woman_seq.Enabled = false;
                            tmr_woman_seq.Stop();
                        }

                        woman_seq_step = 5;
                    }
                    break;
                case 5:
                    {
                        if(woman_INPUT_OUTPUT == "INPUT")
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "UP");
                        }
                        else if (woman_INPUT_OUTPUT == "OUTPUT")
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "DOWN");
                        }
                        
                        woman_tickcount_ms = Environment.TickCount;
                        woman_seq_step = 6;
                    }
                    break;
                case 6:
                    {
                        int now_tickcount = Environment.TickCount;
                        if (now_tickcount > woman_tickcount_ms + 3000)
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "FORWARD");
                            woman_seq_step = 20;
                        }
                    }
                    break;
                case 20:
                    {
                        if(woman_route_code == target_woman.Route)
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "STOP");
                            woman_seq_step = 30;
                        }
                    }
                    break;
                case 30:
                    {
                        TcpIpServer.SendCmdToWoman("MOVE", "RIGHT");
                        woman_seq_step = 40;
                    }
                    break;
                case 40:
                    {
                        if (woman_route_code == target_woman.Dest)
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "STOP");
                            woman_seq_step = 50;
                        }
                    }
                    break;
                case 50:
                    {
                        if (woman_INPUT_OUTPUT == "INPUT")
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "DOWN");
                        }
                        else if (woman_INPUT_OUTPUT == "OUTPUT")
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "UP");
                        }
                        
                        woman_tickcount_ms = Environment.TickCount;
                        woman_seq_step = 60;
                    }
                    break;
                case 60:
                    {
                        int now_tickcount = Environment.TickCount;
                        if (now_tickcount > woman_tickcount_ms + 3000)
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "LEFT");
                            woman_seq_step = 70;
                        }
                    }break;
                case 70:
                    {
                        if (woman_route_code == target_woman.Route)
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "STOP");
                            woman_seq_step = 80;
                        }
                    }
                    break;
                case 80:
                    {
                        TcpIpServer.SendCmdToWoman("MOVE", "FORWARD");
                        woman_seq_step = 90;
                    }
                    break;
                case 90:
                    {
                        if (woman_INPUT_OUTPUT == "INPUT")
                        {
                            if (woman_route_code == target_woman.input)
                            {
                                TcpIpServer.SendCmdToWoman("MOVE", "STOP");
                                tmr_woman_seq.Enabled = false;
                                tmr_woman_seq.Stop();
                                Program.g_frmMain.AddConsoleOutput("작업 완료/입고 완료");

                                Program.data.insertValue(woman_product_code, target_woman.Dest);
                                Program.g_frmMain.AddConsoleOutput("입고기록 삽입");
                            }
                        }
                        else if (woman_INPUT_OUTPUT == "OUTPUT")
                        {
                            if (woman_route_code == target_woman.output)
                            {
                                TcpIpServer.SendCmdToWoman("MOVE", "STOP");
                                woman_seq_step = 100;
                            }
                        }
                    }
                    break;
                case 100:
                    {
                        TcpIpServer.SendCmdToWoman("MOVE", "DOWN");

                        woman_tickcount_ms = Environment.TickCount;
                        woman_seq_step = 110;
                    }
                    break;
                case 110:
                    {
                        int now_tickcount = Environment.TickCount;
                        if (now_tickcount > woman_tickcount_ms + 3000)
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "FORWARD");
                            woman_seq_step = 120;
                        }
                    }
                    break;
                case 120:
                    {
                        if (woman_route_code == target_woman.input)
                        {
                            TcpIpServer.SendCmdToWoman("MOVE", "STOP");
                            tmr_woman_seq.Enabled = false;
                            tmr_woman_seq.Stop();
                            Program.g_frmMain.AddConsoleOutput("작업 완료/출고 완료");

                            Program.data.RowDelete();
                            Program.g_frmMain.AddConsoleOutput("주문 테이블 삭제");

                            Program.data.insertValue(woman_product_code, target_woman.Dest);
                            Program.g_frmMain.AddConsoleOutput("출고기록 삽입");
                        }
                    }
                    break;
            }
        }
	}
}
