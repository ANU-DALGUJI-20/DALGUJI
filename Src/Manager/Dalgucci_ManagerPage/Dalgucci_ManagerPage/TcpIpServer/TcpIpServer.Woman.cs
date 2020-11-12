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
        /*frmMain frmmain = null;

        public TcpIpServer(frmMain fm)
        {
            frmmain = fm;
        }*/
        static void Woman_OutOrder(NetworkStream stream)
        {
            string cmd_out_order = "OUT_ORDER";
            int nOrderCnt = Program.data.OrdersCountResult();
            if (nOrderCnt > 0)
            {
                string strProductCode = Program.data.OrderSelectResult();
                if (strProductCode == "1001")
                {
                    string out_prod_pos = "WSTG01";
                    SendCmdProdOut(ref stream, cmd_out_order, out_prod_pos);
                    Woman_OutOrder_Rev(ref stream);
                }
                else if (strProductCode == "1002")
                {
                    string out_prod_pos = "WSTG02";
                    SendCmdProdOut(ref stream, cmd_out_order, out_prod_pos);
                    Woman_OutOrder_Rev(ref stream);
                }
                else if (strProductCode == "1003")
                {
                    string out_prod_pos = "WSTG03";
                    SendCmdProdOut(ref stream, cmd_out_order, out_prod_pos);
                    Woman_OutOrder_Rev(ref stream);
                }
            }
        }

        private static string bPosition = "";
        public static string Position_Value()
        {
            return bPosition;
        }
        public static string Position_End()
        {
            bPosition = "";
            return bPosition;
        }

        static void Woman_InOrder(NetworkStream stream)
        {
            int length = 0;
            string data = "";
            byte[] bytes = new byte[256];
            string cmd_in_order = "IN_ORDER";

            if (stream.DataAvailable != true)
                return;

            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.Default.GetString(bytes, 0, length);
                Console.WriteLine(String.Format("수신 : {0}", data));

                if (data.Contains("COMPLETE"))
                {
                    Console.WriteLine("작업 완료");
                }

                if (data.Contains("1001"))
                {
                    string in_prod_pos = "WSTG01";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                    Woman_OutOrder_Rev(ref stream);
                }
                else if (data.Contains("1002"))
                {
                    string in_prod_pos = "WSTG02";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                    Woman_OutOrder_Rev(ref stream);
                }
                else if (data.Contains("1003"))
                {
                    string in_prod_pos = "WSTG03";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                    Woman_OutOrder_Rev(ref stream);
                }
				//string[] sRcvMessage = data.Split(new string[] { "{{$", "=", "[!]", "$}}", "MSGID", "CMD", "POS" }, StringSplitOptions.RemoveEmptyEntries);

				//for (int i = 0; i < sRcvMessage.Length; i++)
				//{
				//	Console.WriteLine(String.Format("수신 : {0}", sRcvMessage[i]));
				//}

				// 출고 시나리오 시작 검사
				//if (구매내역테이블.신규구매요청() > 0)
				//{
				//    제품정보 = 구매내역테이블.신규구매요청(0);
				//    string out_prod_pos = "WSTG01"; // 제품정보.창고에 제품이 있는 위치 정보;
				//    string out_order = "OUT_ORDER";
				//    SendCmdProdOut(ref stream, out_order, out_prod_pos);
				//    string ack_code = wait_robot_ack_code();
				//}


				// 입고 시나리오 시작 검사

			}
		}

        private static void Woman_OutOrder_Rev(ref NetworkStream stream)
        {
            int length = 0;
            string data = "";
            byte[] bytes = new byte[256];

            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.Default.GetString(bytes, 0, length);
                // Console.WriteLine(String.Format("수신 : {0}", data));
                string[] sRcvMessage = data.Split(new string[] { "{{$", "=", "[!]", "$}}", "MSGID", "CMD", "POS" }, StringSplitOptions.RemoveEmptyEntries);

                if (data.Contains("COMPLETE_OUTPUT"))
                {
                    Console.WriteLine("작업 완료");
                    Program.data.RowDelete();
                    Console.WriteLine("주문 테이블 삭제");
                    break;
                }
                if (data.Contains("COMPLETE_INPUT"))
                {
                    Console.WriteLine("작업 완료/입고 완료");
                    break;
                }

                if (data.Contains("OK"))
                    Console.WriteLine("명령을 전달받음");
                if (data.Contains("START"))
                    Console.WriteLine("작동 시작");

                if (data.Contains("Going Pick-Up"))
                    Console.WriteLine("출고 작업/이동중 ...");
                if (data.Contains("Pick End"))
                    Console.WriteLine("제품 내려놓음");
                if (data.Contains("Going Place"))
                    Console.WriteLine("장소로 이동중...");
                if (data.Contains("Place End"))
                    Console.WriteLine("도착 및 작업수행");

                if (data.Contains("WMS01"))
                {
                    Console.WriteLine("1번 창고 앞");
                    bPosition = sRcvMessage[2];
                }

                if (sRcvMessage[2] == "WMS02")
                {
                    Console.WriteLine("2번 창고 앞");
                    bPosition = sRcvMessage[2];
                }

                if (data.Contains("WMS03"))
                {
                    Console.WriteLine("3번 창고 앞");
                    bPosition = sRcvMessage[2];
                }
                if (data.Contains("WSTG01"))
                {
                    Console.WriteLine("1번 창고");
                    bPosition = sRcvMessage[2];
                }
                if (data.Contains("WSTG02"))
                {
                    Console.WriteLine("2번 창고");
                    bPosition = sRcvMessage[2];
                }
                if (data.Contains("WSTG03"))
                {
                    Console.WriteLine("3번 창고");
                    bPosition = sRcvMessage[2];
                }
                if (sRcvMessage[2] == "WIN01")
                {
                    Console.WriteLine("입고 시작 위치");
                    bPosition = sRcvMessage[2];
                }
                if (data.Contains("WOUT01"))
                {
                    Console.WriteLine("출고 위치");
                    bPosition = sRcvMessage[2];
                }
            }
        }

        private static void RobotComProc_Woman()
        {
            TcpClient client = TcpIpServer.GetWomanClient();
            Console.WriteLine("Woman 로봇 :{0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            NetworkStream stream = client.GetStream();

            while (true)
            {
                Thread.Sleep(1);

                Woman_OutOrder(stream);

                Woman_InOrder(stream);
            }
            stream.Close();
            client.Close();
        }
    }
}