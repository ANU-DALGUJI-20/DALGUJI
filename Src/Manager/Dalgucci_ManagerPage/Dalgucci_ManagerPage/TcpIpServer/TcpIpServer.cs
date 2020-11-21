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

        // 남자
        private static string MIN01 = "MIN01";
        private static string MOUT01 = "MOUT01";

        private static string MMS01 = "MMS01";
        private static string MMS02 = "MMS02";
        private static string MMS03 = "MMS03";

        private static string MSTG01 = "MSTG01";
        private static string MSTG02 = "MSTG02";
        private static string MSTG03 = "MSTG03";

        private static string MAN2001 = "2001";
        private static string MAN2002 = "2002";
        private static string MAN2003 = "2003";
        
        // 여자
        private static string WIN01 = "WIN01";
        private static string WOUT01 = "WOUT01";

        private static string WMS01 = "WMS01";
        private static string WMS02 = "WMS02";
        private static string WMS03 = "WMS03";

        private static string WSTG01 = "WSTG01";
        private static string WSTG02 = "WSTG02";
        private static string WSTG03 = "WSTG03";

        private static string WOMAN1001 = "1001";
        private static string WOMAN1002 = "1002";
        private static string WOMAN1003 = "1003";

        private static Dictionary<string, string> dicManLog = new Dictionary<string, string>();
        //private static List<string> dicManPos = new List<string>();

        private static Dictionary<string, string> dicWomanLog = new Dictionary<string, string>();
        //private static List<string> dicWomanPos = new List<string>();

        private static bool ServStart()
        {
            try
            {
                string bindIp = "192.168.0.156";
                const int bindPort = 5425;
                IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
                server = new TcpListener(localAddress);
                server.Start();
                Program.g_frmMain.AddConsoleOutput("서버 시작...");

                return true;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public TcpIpServer()
        {
            bool bServerStart = ServStart();
            if (bServerStart)
            {
                // 서버 시작
                connThread.Start();
            }

            // 남자
            dicManLog.Add("2001", "입고 시작 2001");
            dicManLog.Add("2002", "입고 시작 2002");
            dicManLog.Add("2003", "입고 시작 2003");

            dicManLog.Add("OK", "명령을 전달받음");
            dicManLog.Add("START", "작동 시작");
            dicManLog.Add("Going Pick-Up", "출고 작업/이동중 ...");
            dicManLog.Add("Pick End", "제품 내려놓음");
            dicManLog.Add("Going Place", "장소로 이동중...");
            dicManLog.Add("Place End", "도착 및 작업수행");

            dicManLog.Add(MIN01, "남자 한복 입고 시작 위치");
            dicManLog.Add(MOUT01, "남자 한복 출고 위치");
            dicManLog.Add(MMS01, "남자 한복 1번 창고 앞");
            dicManLog.Add(MMS02, "남자 한복 2번 창고 앞");
            dicManLog.Add(MMS03, "남자 한복 3번 창고 앞");
            dicManLog.Add(MSTG01, "남자 한복 1번 창고");
            dicManLog.Add(MSTG02, "남자 한복 2번 창고");
            dicManLog.Add(MSTG03, "남자 한복 3번 창고");


            //dicManPos.Add(MIN01);
            //dicManPos.Add(MOUT01);
            //dicManPos.Add(MMS01);
            //dicManPos.Add(MMS02);
            //dicManPos.Add(MMS03);
            //dicManPos.Add(MSTG01);
            //dicManPos.Add(MSTG02);
            //dicManPos.Add(MSTG03);

            // 여자
            dicWomanLog.Add("1001", "입고 시작 1001");
            dicWomanLog.Add("1002", "입고 시작 1002");
            dicWomanLog.Add("1003", "입고 시작 1003");

            dicWomanLog.Add("OK", "명령을 전달받음");
            dicWomanLog.Add("START", "작동 시작");
            dicWomanLog.Add("Going Pick-Up", "출고 작업/이동중 ...");
            dicWomanLog.Add("Pick End", "제품 내려놓음");
            dicWomanLog.Add("Going Place", "장소로 이동중...");
            dicWomanLog.Add("Place End", "도착 및 작업수행");

            dicWomanLog.Add(WIN01, "여자 한복 입고 시작 위치");
            dicWomanLog.Add(WOUT01, "여자 한복 출고 위치");
            dicWomanLog.Add(WMS01, "여자 한복 1번 창고 앞");
            dicWomanLog.Add(WMS02, "여자 한복 2번 창고 앞");
            dicWomanLog.Add(WMS03, "여자 한복 3번 창고 앞");
            dicWomanLog.Add(WSTG01, "여자 한복 1번 창고");
            dicWomanLog.Add(WSTG02, "여자 한복 2번 창고");
            dicWomanLog.Add(WSTG03, "여자 한복 3번 창고");


            //dicWomanPos.Add(WIN01);
            //dicWomanPos.Add(WOUT01);
            //dicWomanPos.Add(WMS01);
            //dicWomanPos.Add(WMS02);
            //dicWomanPos.Add(WMS03);
            //dicWomanPos.Add(WSTG01);
            //dicWomanPos.Add(WSTG02);
            //dicWomanPos.Add(WSTG03);
        }

        //private static string sPosition = "";
        //public static string Position_Value()
        //{
        //    return sPosition;
        //}
        //public static string Position_End()
        //{
        //    sPosition = "";
        //    return sPosition;
        //}

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
                Program.g_frmMain.AddConsoleOutput(string.Format("Woman 접속 :{0}", ip));
                WomanProdThread.Start();

                tcpClientConnected.Reset();
                listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
                tcpClientConnected.WaitOne();
            }

            if (man_client == null)
            {
                man_client = listener.EndAcceptTcpClient(ar);
                string ip = ((IPEndPoint)man_client.Client.RemoteEndPoint).Address.ToString();
                Program.g_frmMain.AddConsoleOutput(string.Format("Man 접속 :{0}", ip));
                ManProdThread.Start();

                tcpClientConnected.Reset();
                listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
                tcpClientConnected.WaitOne();
            }
        }

        //static int nMsgId = 1;
        private static int SendCmdToRobot(ref NetworkStream stream, string sCMD, string sPosition)
        {
            try
            {
                string Token_Start = "{{$";
                string Token_End = "$}}";
                string my_splitor = "[!]";

                int nMsgId = 1;
                string sMsgId = nMsgId.ToString().PadLeft(4, '0');

                string sPacket = String.Format($"{Token_Start}MSGID={sMsgId}{my_splitor}CMD={sCMD}{my_splitor}POS={sPosition}{Token_End}");
                byte[] msg = Encoding.Default.GetBytes(sPacket);
                stream.Write(msg, 0, msg.Length);
                Program.g_frmMain.AddConsoleOutput(String.Format("송신: {0}", sPacket));
            }
            catch( Exception ex )
            {

            }
            
            //return nMsgId++;
            return 0;
        }

        public static int SendInputQRNumToWoman(string sCMD, string number)
        {
            NetworkStream s = GetWomanClient().GetStream();
            int nMsgId = 1;
            string sMsgId = nMsgId.ToString().PadLeft(4, '0');

            string sPacket = String.Format($"{{$MSGID={sMsgId}[!]CMD={sCMD}[!]NUMBER={number}$}}");
            byte[] msg = Encoding.Default.GetBytes(sPacket);
            s.Write(msg, 0, msg.Length);
            Program.g_frmMain.AddConsoleOutput(String.Format("송신: {0}", sPacket));

            //return nMsgId++;
            return 0;
        }
        
        public static int SendInputQRNumToMan(string sCMD, string number)
        {
            NetworkStream s = GetManClient().GetStream();
            int nMsgId = 1;
            string sMsgId = nMsgId.ToString().PadLeft(4, '0');

            string sPacket = String.Format($"{{$MSGID={sMsgId}[!]CMD={sCMD}[!]NUMBER={number}$}}");
            byte[] msg = Encoding.Default.GetBytes(sPacket);
            s.Write(msg, 0, msg.Length);
            Program.g_frmMain.AddConsoleOutput(String.Format("송신: {0}", sPacket));

            //return nMsgId++;
            return 0;
        }

		public static int SendCmdToMan(string sCMD, string sPosition)
		{
			NetworkStream s = GetManClient().GetStream();
			SendCmdToRobot(ref s, sCMD, sPosition);
			return 0;
		}

		public static int SendCmdToWoman(string sCMD, string sPosition)
		{
			NetworkStream s = GetWomanClient().GetStream();
			SendCmdToRobot(ref s, sCMD, sPosition);
			return 0;
		}
	}
}