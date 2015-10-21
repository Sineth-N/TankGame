using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TankGame.util;

namespace TankGame.ServerConn
{
    class InitConnectionFromServer
    {
        bool errorOcurred = false;
        Socket connection = null; //The socket that is listened to     
        TcpListener listener = null;

        public InitConnectionFromServer()
        {

        }

        public void waitForConnection()
        {
            try
            {
                //Creating listening Socket
                this.listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7000);

                Console.WriteLine("waiting for server response");

                //Starts listening
                this.listener.Start();
                //Establish connection upon server request
                while (true)
                {

                    connection = listener.AcceptSocket();   //connection is connected socket

                    //Console.WriteLine("Connetion is established");

                    //Fetch the messages from the server
                    int asw = 0;
                    //create a network stream using connection
                    NetworkStream serverStream = new NetworkStream(connection);
                    List<Byte> inputStr = new List<byte>();

                    //fetch messages from  server
                    while (asw != -1)
                    {
                        asw = serverStream.ReadByte();
                        inputStr.Add((Byte)asw);
                    }

                    String messageFromServer = Encoding.UTF8.GetString(inputStr.ToArray());

                    Main torkenizer = new Main();
                    //Console.Write("Response from server to join "+torkenizer.serverJoinReply(messageFromServer));
                    Console.WriteLine(messageFromServer);
                    if (messageFromServer.StartsWith("I") && messageFromServer.EndsWith("#"))
                    {
                        torkenizer.initiation(messageFromServer);
                    }
                    else if(messageFromServer.StartsWith("S") && messageFromServer.EndsWith("#"))
                    {
                        torkenizer.acceptance(messageFromServer);
                    }
                    else if (messageFromServer.StartsWith("G") && messageFromServer.EndsWith("#"))
                    {
                        
                    }

                    serverStream.Close();       //close the netork stream
                    
                   

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Communication (RECEIVING) Failed! \n " + e.StackTrace);
                errorOcurred = true;
            }
            finally
            {
                if (connection != null)
                    if (connection.Connected)
                        connection.Close();
                if (errorOcurred)
                   this.waitForConnection();
            }
        }

    }
}
