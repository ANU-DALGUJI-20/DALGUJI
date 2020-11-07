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
    public partial class TcpIpServer
    {
        static TcpListener server = null;

        static Thread WomanProdThread = new Thread(new ThreadStart(RobotComProc_Woman));    // 여자 한복 송수신 스레드
        static Thread ManProdThread = new Thread(new ThreadStart(RobotComProc_Man));        // 남자 한복 송수신 스레드
        Thread connThread = new Thread(new ThreadStart(ConnectProc));  // 연결 처리 스레드

        public static TcpClient woman_client;  // 여자 한복 로봇
        public static TcpClient man_client;    // 남자 한복 로봇

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

        private static TcpClient GetWomanClient()
        {
            return woman_client;
        }
        private static TcpClient GetManClient()
        {
            return man_client;
        }

        private static void ConnectProc()
        {
            while (true)
            {
                Thread.Sleep(1);

                tcpClientConnected.Reset();
                server.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), server);
                tcpClientConnected.WaitOne();
            }
        }


        private static void DoAcceptTcpClientCallback(IAsyncResult ar)
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            if (woman_client == null)
            {
                woman_client = listener.EndAcceptTcpClient(ar);
                string ip = ((IPEndPoint)woman_client.Client.RemoteEndPoint).Address.ToString();
                Console.WriteLine("Woman 접속 :{0}", ip);
                WomanProdThread.Start();

                tcpClientConnected.Reset();
                listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
                tcpClientConnected.WaitOne();
            }

            if (man_client == null)
            {
                man_client = listener.EndAcceptTcpClient(ar);
                string ip = ((IPEndPoint)man_client.Client.RemoteEndPoint).Address.ToString();
                Console.WriteLine("Man 접속 :{0}", ip);
                ManProdThread.Start();

                tcpClientConnected.Reset();
                listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
                tcpClientConnected.WaitOne();
            }
        }

        private static bool ServStart()
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

        private static int SendCmdProdOut(ref NetworkStream stream, string sCMD, string sPosition)
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
