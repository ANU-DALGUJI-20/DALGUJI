using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dalgucci
{
    public class TcpIpServer
    {
        static TcpListener server = null;

        static Thread InProdThread = new Thread(new ThreadStart(InProdDataProc));    // 입고 송수신 스레드
        static Thread OutProdTread = new Thread(new ThreadStart(OutProdDataProc));   // 출고 송수신 스레드
        Thread connThread = new Thread(new ThreadStart(ConnectProc));                // 연결 처리 스레드

        public static TcpClient in_client;  // 입고 로봇
        public static TcpClient out_client; // 출고 로봇

        public static ManualResetEvent tcpClientConnected = new ManualResetEvent(false);

        public TcpIpServer()
        {
            bool bServerStart = ServStart();
            if(bServerStart)
            {
                // 서버 시작
                connThread.Start(); 
            }
        }

        public static TcpClient GetInClientClient()
        {
            return in_client;
        }

        public static TcpClient GetOutClientClient()
        {
            return out_client;
        }
        public static void ConnectProc()
        {
            while(true)
            {
                Thread.Sleep(1);

                tcpClientConnected.Reset();
                server.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), server);
                tcpClientConnected.WaitOne();                
            }
        }

        public static void DoAcceptTcpClientCallback(IAsyncResult ar)
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            if (in_client == null)
            {
                in_client = listener.EndAcceptTcpClient(ar);
                Console.WriteLine("입고 로봇 :{0}", ((IPEndPoint)in_client.Client.RemoteEndPoint).Address.ToString());
                InProdThread.Start();
            }
            else if (out_client == null)
            {
                out_client = listener.EndAcceptTcpClient(ar);
                Console.WriteLine("출고 로봇 :{0}", ((IPEndPoint)out_client.Client.RemoteEndPoint).Address.ToString());
                OutProdTread.Start();
            }

            tcpClientConnected.Reset();
            listener.BeginAcceptTcpClient(new AsyncCallback(DoAcceptTcpClientCallback), listener);
            tcpClientConnected.WaitOne();
        }

        public static void InProdDataProc()
        {
            while (true)
            {
                Thread.Sleep(1);

                InProdWorking ipw = new InProdWorking();
                ipw.ProcMessage();
            }
        }

        public static void OutProdDataProc()
        {
            while (true)
            {
                Thread.Sleep(1);

                OutProdWorking opw = new OutProdWorking();
                opw.ProcMessage();
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
    }
}
