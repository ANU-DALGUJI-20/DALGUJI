using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dalgucci_ManagerPage
{
    public class TcpIpServer
    {
        static string dbStr = "Server=192.168.0.30;Database=SF1team;User Id=sa;Password=0924;";

        static TcpListener server = null;

        static Thread InProdThread = new Thread(new ThreadStart(RobotComProc_Woman));    // 여자 송수신 스레드
        static Thread OutProdTread = new Thread(new ThreadStart(RobotComProc_Man));      // 남자 송수신 스레드
        Thread connThread = new Thread(new ThreadStart(ConnectProc));  // 연결 처리 스레드

        public static TcpClient in_client;  // 입고 로봇
        public static TcpClient out_client; // 출고 로봇

        public static ManualResetEvent tcpClientConnected = new ManualResetEvent(false);

        public TcpIpServer()
        {
            bool bServerStart = ServStart();
            if (bServerStart)
            {
                // 서버 시작
                connThread.Start();
            }
        }

        public static TcpClient GetInClient()
        {
            return in_client;
        }
        public static TcpClient GetOutClient()
        {
            return out_client;
        }

        public static void ConnectProc()
        {
            while (true)
            {
                Thread.Sleep(1);

                tcpClientConnected.Reset();
                server.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), server);
                tcpClientConnected.WaitOne();
            }
        }
        public static string SqCountResult()
        {

            SqlConnection conn = new SqlConnection(dbStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "select count(*) from Orders;";
            cmd.ExecuteNonQuery();

            string result = cmd.ExecuteScalar().ToString();
            conn.Close();

            return result;
        }

        public static string SqlOrderResult()
        {
            string result;

            SqlConnection conn = new SqlConnection(dbStr);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "select Product_Code from Orders where Order_No = (select min(Order_No) from Orders);";
            cmd.ExecuteNonQuery();

            if (Convert.ToInt32(SqCountResult()) == 0)
                return null;
            else
                result = cmd.ExecuteScalar().ToString();

            conn.Close();

            return result;
        }

        public static void SqlDeleteResult()
        {
            SqlConnection conn = new SqlConnection(dbStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "delete from Orders where Order_No = (select min(Order_No) from Orders);";
            cmd.ExecuteNonQuery();

            conn.Close();

        }

        public static void DoAcceptTcpClientCallback(IAsyncResult ar)
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            //if (in_client == null)
            //{
            //    in_client = listener.EndAcceptTcpClient(ar);
            //    string ip = ((IPEndPoint)in_client.Client.RemoteEndPoint).Address.ToString();
            //    Console.WriteLine("접속 :{0}", ip);
            //}

            if (out_client == null)
            {
                out_client = listener.EndAcceptTcpClient(ar);
                string ip = ((IPEndPoint)out_client.Client.RemoteEndPoint).Address.ToString();
                Console.WriteLine("접속 :{0}", ip);
                OutProdTread.Start();
            }

            tcpClientConnected.Reset();
            listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
            tcpClientConnected.WaitOne();
        }

        public static void RobotComProc_Woman()
        {
            //while (true)
            //{
            //    Thread.Sleep(1);

            //    TcpClient client = TcpIpServer.GetInClient();

            //    Console.WriteLine("입고 로봇 :{0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            //    Console.WriteLine();

            //    NetworkStream stream = client.GetStream();

            //    int length;
            //    string data = null;
            //    byte[] bytes = new byte[256];

            //    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            //    {
            //        data = Encoding.Default.GetString(bytes, 0, length);
            //        Console.WriteLine(String.Format("수신 : {0}", data));

            //        byte[] msg = Encoding.Default.GetBytes(data);
            //        stream.Write(msg, 0, msg.Length);
            //        Console.WriteLine(String.Format("송신: {0}", data));
            //    }
            //    stream.Close();
            //    client.Close();
            //}
        }
        public static void RobotComProc_Man()
        {
            TcpClient client = TcpIpServer.GetOutClient();
            Console.WriteLine("로봇 :{0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            NetworkStream stream = client.GetStream();
            /*SendTread.Start();
            ReceiveTread.Start();*/

            int length;
            string data = null;
            byte[] bytes = new byte[256];
            string cmd__out_order = "OUT_ORDER";
            string cmd_in_order = "IN_ORDER";
            string out_prod_pos;
            string in_prod_pos;

            while (true)
            {
                Thread.Sleep(1);


                if (Convert.ToInt32(SqCountResult()) > 0)
                {
                    if (SqlOrderResult() == "1001")
                    {
                        out_prod_pos = "WSTG01";
                        SendCmdProdOut(ref stream, cmd__out_order, out_prod_pos);
                        SqlDeleteResult();
                        continue;
                    }
                    else if (SqlOrderResult() == "1002")
                    {
                        out_prod_pos = "WSTG02";
                        SendCmdProdOut(ref stream, cmd__out_order, out_prod_pos);
                        SqlDeleteResult();
                        continue;
                    }
                    else if (SqlOrderResult() == "1003")
                    {
                        out_prod_pos = "WSTG03";
                        SendCmdProdOut(ref stream, cmd__out_order, out_prod_pos);
                        SqlDeleteResult();
                        continue;
                    }
                }

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
                        in_prod_pos = "WSTG01";
                        SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                    }
                    else if (data.Contains("1002"))
                    {
                        in_prod_pos = "WSTG02";
                        SendCmdProdOut(ref stream, cmd_in_order, in_prod_pos);
                    }
                    else if (data.Contains("1003"))
                    {
                        in_prod_pos = "WSTG03";
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
                stream.Close();
                client.Close();
            }
        }

        public static bool ServStart()
        {
            try
            {
                string bindIp = "127.0.0.1";
                const int bindPort = 5425;
                IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
                server = new TcpListener(localAddress);
                server.Start();
                Console.WriteLine("서버 시작...");

                return true;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static int SendCmdProdOut(ref NetworkStream stream, string sCMD, string sPosition)
        {
            string Token_Start = "{{$";
            string Token_End = "$}}";
            string my_splitor = "[!]";

            int nMsgId = 1;

            string sPacket = String.Format($"{Token_Start}MSGID={nMsgId.ToString().PadLeft(4, '0')}{my_splitor}CMD={sCMD}{my_splitor}POS={sPosition}{Token_End}");
            byte[] msg = Encoding.Default.GetBytes(sPacket);
            stream.Write(msg, 0, msg.Length);
            Console.WriteLine(String.Format("송신: {0}", sPacket));

            return 0;
        }
    }
}
