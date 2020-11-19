using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dalgucci_ManagerPage
{
	partial class TcpIpServer
	{
        static void Woman_OutOrder(NetworkStream stream)
        {
            string cmd_out_order = "OUT_ORDER";
            int nOrderCnt = Program.data.OrdersCountResult();
            if (nOrderCnt > 0)
            {
                string out_prod_pos = "";
                string strProductCode = Program.data.OrderSelectResult();

                if (strProductCode == WOMAN1001) out_prod_pos = WSTG01;
                else if (strProductCode == WOMAN1002) out_prod_pos = WSTG02;
                else if (strProductCode == WOMAN1003) out_prod_pos = WSTG03;

                SendCmdToRobot(ref stream, cmd_out_order, out_prod_pos);
                Woman_Order_Rev(ref stream);

                Program.data.insertValue(strProductCode, out_prod_pos);
                Program.g_frmMain.AddConsoleOutput("출고기록 삽입");

            }
        }

        static void Woman_InOrder(NetworkStream stream)
        {
            int length = 0;
            string data = "";
            byte[] bytes = new byte[256];
            string cmd_in_order = "IN_ORDER";
            string productNo = "";
            string in_prod_pos = "";

            if (stream.DataAvailable != true)
                return;

            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.Default.GetString(bytes, 0, length);
                Program.g_frmMain.AddConsoleOutput(String.Format("수신 : {0}", data));
                //string[] sRcvMessage = data.Split(new string[] { "{{$", "=", "[!]", "$}}", "MSGID", "CMD", "NUMBER" }, StringSplitOptions.RemoveEmptyEntries);

                //productNo = sRcvMessage[2];

                //if (sRcvMessage[2] == WOMAN1001) in_prod_pos = WSTG01;
                //else if (sRcvMessage[2] == WOMAN1002) in_prod_pos = WSTG02;
                //else if (sRcvMessage[2] == WOMAN1003) in_prod_pos = WSTG03;
                
                //SendCmdToRobot(ref stream, cmd_in_order, in_prod_pos);
                //Woman_Order_Rev(ref stream);

                //Program.data.insertValue(productNo,in_prod_pos);
                //Program.g_frmMain.AddConsoleOutput("입고기록 삽입");

                if(data.Contains("COMPLETE_INPUT"))
				{
					Program.g_frmMain.AddConsoleOutput("작업 완료/입고 완료");

					Program.data.insertValue(WOMAN1001, in_prod_pos);
					Program.g_frmMain.AddConsoleOutput("입고기록 삽입");
				}
            }
		}

        public static void Woman_Order_Rev(ref NetworkStream stream)
        {
            int length = 0;
            string data = "";
            byte[] bytes = new byte[256];


            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.Default.GetString(bytes, 0, length);
                // string[] sRcvMessage = data.Split(new string[] { "{{$", "=", "[!]", "$}}", "MSGID", "CMD", "POS", "STATE"}, StringSplitOptions.RemoveEmptyEntries);

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

                foreach (var k in dicWomanLog.Keys)
                {
                    if (data.Contains(k))
                    {
                        Program.g_frmMain.AddConsoleOutput(dicWomanLog[k]);
                    }
                }

                //foreach (var p in dicWomanPos)
                //{
                //	if (data.Contains(p))
                //	{
                //		sPosition = p;
                //	}
                //}

			}
        }

        private static void RobotComProc_Woman()
        {
            TcpClient client = TcpIpServer.GetWomanClient();
            Program.g_frmMain.AddConsoleOutput(string.Format("Woman 로봇 :{0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString()));
            NetworkStream stream = client.GetStream();

            while (true)
            {
                Thread.Sleep(1);

                Woman_OutOrder(stream);

                Woman_InOrder(stream);
            }
            //stream.Close();
            //client.Close();
        }
    }
}