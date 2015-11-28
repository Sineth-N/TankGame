﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TankGame.util;

namespace TankGame.Client
{
    class ClientConnectionInit
    {
        static System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        static NetworkStream stream;

        public static void Connect()
        {
            //connecting to server socket with port 6000
           clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 6000);
           stream = clientSocket.GetStream();

            //joining message to server
           byte[] ba = Encoding.ASCII.GetBytes(Constant.C2S_INITIALREQUEST);

           for (int x = 0; x < ba.Length;x++ ) {
               Console.WriteLine(ba[x]);
           }
           stream.Write(ba,0,ba.Length);
           stream.Flush();
           while(true){}
     

        }

    }
}
