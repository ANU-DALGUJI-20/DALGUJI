using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dalgucci_ManagerPage
{
	partial class TcpIpServer
	{
        static void Man_OutOrder(NetworkStream stream)
        {
            string cmd_out_order = "OUT_ORDER";
            int nOrderCnt = Program.data.OrdersCountResult();
            if (nOrderCnt > 0)
            {
                string strProductCode = Program.data.OrderSelectResult();
                if (strProductCode == "2001")
                {
                    string out_prod_pos = "MSTG01";
                    SendCmdProdOut(ref stream, cmd_out_order, out_prod_pos);
                    Man_Order_Rev(ref stream);
                }
                else if (strProductCode == "2002")
                {
                    string out_prod_pos = "MSTG02";
                    SendCmdProdOut(ref stream, cmd_out_order, out_prod_pos);
                    Man_Order_Rev(ref stream);
                }
                else if (strProductCode == "2003")
                {
                    string out_prod_pos = "MSTG03";
                    SendCmdProdOut(ref stream, cmd_out_order, out_prod_pos);
                    Man_Order_Rev(ref stream);
                }
            }
        }

        static void Man_InOrder(NetworkStream stream)
        {
            int length = 0;
            string data = "";
            byte[] bytes = new byte[256];
            string cmd_in_order = "IN_ORDER";

            if (stream.CanRead != true)
                return;

            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.Default.GetString(bytes, 0, length);
                //Console.WriteLine(String.Format("수신 : {0}", data));
                Program.g_frmMain.AddConsoleOutput(string.Format("수신 : {0}", data));

                if (data.Contains("2001"))
                {
                    string in_prod_pos = "MSTG01";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                    Man_Order_Rev(ref stream);
                }
                else if (data.Contains("2002"))
                {
                    string in_prod_pos = "MSTG02";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                    Man_Order_Rev(ref stream);
                }
                else if (data.Contains("2003"))
                {
                    string in_prod_pos = "MSTG03";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                    Man_Order_Rev(ref stream);
                }
            }
        }

        public static void Man_Order_Rev(ref NetworkStream stream)
        {
            int length = 0;
            string data = "";
            byte[] bytes = new byte[256];

            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.Default.GetString(bytes, 0, length);
                // Console.WriteLine(String.Format("수신 : {0}", data));
                string[] sRcvMessage = data.Split(new string[] { "{{$", "=", "[!]", "$}}", "MSGID", "CMD", "POS", "STATE", }, StringSplitOptions.RemoveEmptyEntries);

                if (data.Contains("COMPLETE_OUTPUT"))
                {
                    Program.g_frmMain.AddConsoleOutput("작업 완료/출고 완료");
                    Program.data.RowDelete();
                    Program.g_frmMain.AddConsoleOutput("주문 테이블 삭제");
                    break;
                }
                if (data.Contains("COMPLETE_INPUT"))
                {
                    Program.g_frmMain.AddConsoleOutput("작업 완료/입고 완료");
                    break;
                }

                if (data.Contains("OK"))
                    Program.g_frmMain.AddConsoleOutput("명령을 전달받음");
                if (data.Contains("START"))
                    Program.g_frmMain.AddConsoleOutput("작동 시작");

                if (data.Contains("Going Pick-Up"))
                    Program.g_frmMain.AddConsoleOutput("출고 작업/이동중 ...");
                if (data.Contains("Pick End"))
                    Program.g_frmMain.AddConsoleOutput("제품 내려놓음");
                if (data.Contains("Going Place"))
                    Program.g_frmMain.AddConsoleOutput("장소로 이동중...");
                if (data.Contains("Place End"))
                    Program.g_frmMain.AddConsoleOutput("도착 및 작업수행");

                // 남자 한복 창고
                if (data.Contains("MMS01"))
                {
                    Program.g_frmMain.AddConsoleOutput("남자 한복 1번 창고 앞");
                    bPosition = sRcvMessage[2];
                }

                if (sRcvMessage[2] == "MMS02")
                {
                    Program.g_frmMain.AddConsoleOutput("남자 한복 2번 창고 앞");
                    bPosition = sRcvMessage[2];
                }

                if (data.Contains("MMS03"))
                {
                    Program.g_frmMain.AddConsoleOutput("남자 한복 3번 창고 앞");
                    bPosition = sRcvMessage[2];
                }
                if (data.Contains("MSTG01"))
                {
                    Program.g_frmMain.AddConsoleOutput("남자 한복 1번 창고");
                    bPosition = sRcvMessage[2];
                }
                if (data.Contains("MSTG02"))
                {
                    Program.g_frmMain.AddConsoleOutput("남자 한복 2번 창고");
                    bPosition = sRcvMessage[2];
                }
                if (data.Contains("MSTG03"))
                {
                    Program.g_frmMain.AddConsoleOutput("남자 한복 3번 창고");
                    bPosition = sRcvMessage[2];
                }
                if (data.Contains("MIN01"))
                {
                    Program.g_frmMain.AddConsoleOutput("남자 한복 입고 시작 위치");
                    bPosition = sRcvMessage[2];
                }
                if (data.Contains("MOUT01"))
                {
                    Program.g_frmMain.AddConsoleOutput("남자 한복 출고 위치");
                    bPosition = sRcvMessage[2];
                }
            }
        }

        private static void RobotComProc_Man()
        {
            TcpClient client = TcpIpServer.GetManClient();
            // Console.WriteLine("Man 로봇 :{0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            Program.g_frmMain.AddConsoleOutput(string.Format("Man 로봇 :{0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()));
            NetworkStream stream = client.GetStream();

            while (true)
            {
                Thread.Sleep(1);

                Man_OutOrder(stream);

                Man_InOrder(stream);
            }
            //stream.Close();
            //client.Close();
        }
    }
}
