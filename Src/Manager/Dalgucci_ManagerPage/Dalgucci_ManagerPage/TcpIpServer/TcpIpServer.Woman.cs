using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dalgucci_ManagerPage
{
	partial class TcpIpServer
	{
        static void Woman_OutOrder(NetworkStream stream)
        {
            string cmd__out_order = "OUT_ORDER";
            int nOrderCnt = Program.data.OrdersCountResult();
            if (nOrderCnt > 0)
            {
                string strProductCode = Program.data.SqlOrderResult();
                if (strProductCode == "1001")
                {
                    string out_prod_pos = "WSTG01";
                    SendCmdProdOut(ref stream, cmd__out_order, out_prod_pos);
                    Program.data.SqlDeleteResult();
                }
                else if (strProductCode == "1002")
                {
                    string out_prod_pos = "WSTG02";
                    SendCmdProdOut(ref stream, cmd__out_order, out_prod_pos);
                    Program.data.SqlDeleteResult();
                }
                else if (strProductCode == "1003")
                {
                    string out_prod_pos = "WSTG03";
                    SendCmdProdOut(ref stream, cmd__out_order, out_prod_pos);
                    Program.data.SqlDeleteResult();
                }
            }
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
                }
                else if (data.Contains("1002"))
                {
                    string in_prod_pos = "WSTG02";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                }
                else if (data.Contains("1003"))
                {
                    string in_prod_pos = "WSTG03";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                }
                // string[] sRcvMessage = data.Split(new string[] { "{{$", "=", "[!]", "$}}", "MSGID", "CMD", "POS" }, StringSplitOptions.RemoveEmptyEntries);

                //for (int i = 0; i < sRcvMessage.Length; i++)
                //{
                //    Console.WriteLine(String.Format("수신 : {0}", sRcvMessage[i]));
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
