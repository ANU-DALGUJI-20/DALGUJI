using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        static string dbStr = "Server=192.168.0.30;Database=SF1team;User Id=sa;Password=0924;";

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

        public static string SqlResult1()
        {
            SqlConnection conn = new SqlConnection(dbStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "select ip_address from robot where robot_number = 0";
            cmd.ExecuteNonQuery();

            string db1 = cmd.ExecuteScalar().ToString();

            conn.Close();

            return db1;
        }

        public static string SqlResult2()
        {
            SqlConnection conn = new SqlConnection(dbStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            conn.Open();
            cmd.CommandText = "select ip_address from robot where robot_number = 1";
            cmd.ExecuteNonQuery();

            string db2 = cmd.ExecuteScalar().ToString();

            conn.Close();

            return db2;
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

        public static void DoAcceptTcpClientCallback(IAsyncResult ar)
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener)ar.AsyncState;

            string db_ip1 = SqlResult1();
            string db_ip2 = SqlResult2();

            if (in_client == null)
            {
                in_client = listener.EndAcceptTcpClient(ar);
                string ip = ((IPEndPoint)in_client.Client.RemoteEndPoint).Address.ToString();
                Console.WriteLine("접속 (1) :{0}", ip);

                if (db_ip1 == ip)
                {
                    Console.WriteLine($"데이터베이스 IP : {db_ip1}");
                    InProdThread.Start();
                }
                else if (db_ip2 == ip)
                {
                    Console.WriteLine($"데이터베이스 IP : {db_ip2}");
                    OutProdTread.Start();
                }
            }
            else if (out_client == null)
            {
                out_client = listener.EndAcceptTcpClient(ar);
                string ip = ((IPEndPoint)out_client.Client.RemoteEndPoint).Address.ToString();
                Console.WriteLine("접속 (2) :{0}", ip);
                if (out_client != null)
                {
                    in_client = out_client;
                }
                if (db_ip1 == ip)
                {
                    Console.WriteLine($"데이터베이스 IP : {db_ip1}");
                    InProdThread.Start();
                }
                else if (db_ip2 == ip)
                {
                    Console.WriteLine($"데이터베이스 IP : {db_ip2}");
                    OutProdTread.Start();
                }
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
                string bindIp = "192.168.0.49";
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