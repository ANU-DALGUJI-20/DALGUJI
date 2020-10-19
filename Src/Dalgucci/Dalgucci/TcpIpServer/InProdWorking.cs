﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Dalgucci
{
    public class InProdWorking
    {
        public void ProcMessage()
        {
            TcpClient client = TcpIpServer.GetInClientClient();
            Console.WriteLine("클라이언트 접속 :{0}", ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            NetworkStream stream = client.GetStream();

            int length;
            string data = null;
            byte[] bytes = new byte[256];

            while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                data = Encoding.Default.GetString(bytes, 0, length);
                Console.WriteLine(String.Format("수신 : {0}", data));

                byte[] msg = Encoding.Default.GetBytes(data);
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine(String.Format("송신: {0}", data));
            }
            stream.Close();
            client.Close();
        }
    }
}
