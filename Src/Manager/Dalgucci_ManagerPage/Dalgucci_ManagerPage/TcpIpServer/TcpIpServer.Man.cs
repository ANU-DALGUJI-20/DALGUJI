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
            string cmd__out_order = "OUT_ORDER";
            int nOrderCnt = Program.data.OrdersCountResult();
            if (nOrderCnt > 0)
            {
                string strProductCode = Program.data.OrderSelectResult();
                if (strProductCode == "2001")
                {
                    string out_prod_pos = "MSTG01";
                    SendCmdProdOut(ref stream, cmd__out_order, out_prod_pos);
                    Program.data.RowDelete();
                }
                else if (strProductCode == "2002")
                {
                    string out_prod_pos = "MSTG02";
                    SendCmdProdOut(ref stream, cmd__out_order, out_prod_pos);
                    Program.data.RowDelete();
                }
                else if (strProductCode == "2003")
                {
                    string out_prod_pos = "MSTG03";
                    SendCmdProdOut(ref stream, cmd__out_order, out_prod_pos);
                    Program.data.RowDelete();
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
                Console.WriteLine(String.Format("수신 : {0}", data));

                if (data.Contains("COMPLETE"))
                {
                    Console.WriteLine("작업 완료");
                }

                if (data.Contains("2001"))
                {
                    string in_prod_pos = "MSTG01";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                }
                else if (data.Contains("2002"))
                {
                    string in_prod_pos = "MSTG02";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                }
                else if (data.Contains("2003"))
                {
                    string in_prod_pos = "MSTG03";
                    SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                }
            }
        }

        private static void RobotComProc_Man()
        {
            TcpClient client = TcpIpServer.GetManClient();
            Console.WriteLine("Man 로봇 :{0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            NetworkStream stream = client.GetStream();

            while (true)
            {
                Thread.Sleep(1);

                Man_OutOrder(stream);

                Man_InOrder(stream);
            }
            stream.Close();
            client.Close();
        }
    }
}
