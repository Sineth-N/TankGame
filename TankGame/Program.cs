using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TankGame.Client;


namespace TankGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //init client connection to server
            ClientConnectionInit.Connect();
            
            //init a socket for call back from the server to fetch messages
            new ServerConn.InitConnectionFromServer().waitForConnection();
            while (true) { }
        }
       
    }
}
