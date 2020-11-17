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
                string out_prod_pos = "";
                string strProductCode = Program.data.OrderSelectResult();

                if (strProductCode == MAN2001) out_prod_pos = MSTG01;
                else if (strProductCode == MAN2002) out_prod_pos = MSTG02;
                else if (strProductCode == MAN2003) out_prod_pos = MSTG03;

                SendCmdToRobot(ref stream, cmd_out_order, out_prod_pos);
                Man_Order_Rev(ref stream);

                Program.data.insertValue(strProductCode, out_prod_pos);
                Program.g_frmMain.AddConsoleOutput("출고기록 삽입");
            }
        }

        static void Man_InOrder(NetworkStream stream)
        {
            int length = 0;
            string data = "";
            byte[] bytes = new byte[256];
            string cmd_in_order = "IN_ORDER";
            string productNo = "";
            string in_prod_pos = "";

            if (stream.CanRead != true)
                return;

            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.Default.GetString(bytes, 0, length);
                // Program.g_frmMain.AddConsoleOutput(string.Format("수신 : {0}", data));
                string[] sRcvMessage = data.Split(new string[] { "{{$", "=", "[!]", "$}}", "MSGID", "CMD", "NUMBER" }, StringSplitOptions.RemoveEmptyEntries);

                productNo = sRcvMessage[2];

                if (sRcvMessage[2] == MAN2001) in_prod_pos = MSTG01;
                else if (sRcvMessage[2] == MAN2001) in_prod_pos = MSTG02;
                else if (sRcvMessage[2] == MAN2001) in_prod_pos = MSTG03;

                SendCmdToRobot(ref stream, cmd_in_order, in_prod_pos);
                Man_Order_Rev(ref stream);

                Program.data.insertValue(productNo,in_prod_pos);
                Program.g_frmMain.AddConsoleOutput("입고기록 삽입");
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

                foreach( var k in dicManLog.Keys)
				{
                    if( data.Contains( k ))
					{
                        Program.g_frmMain.AddConsoleOutput(dicManLog[k]);
                    }
				}

                //foreach (var p in dicManPos)
                //{
                //    if (data.Contains(p))
                //    {
                //        sPosition = p;
                //    }
                //}
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
