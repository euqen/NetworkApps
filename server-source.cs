using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        const int SERVER_PORT = 8085;
        const int CLIENT_PORT = 8086;
        static void Main(string[] args)
        {
            Broadcaster();

        }

        public static void Broadcaster()
        {
            byte[] data;
            Console.WriteLine("Starting server...");
            Socket Broadcast = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Broadcast.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            IPEndPoint Node = new IPEndPoint(IPAddress.Any, SERVER_PORT);
            Broadcast.Bind(Node);

            IPEndPoint ClientNode = new IPEndPoint(IPAddress.Broadcast, CLIENT_PORT);
            EndPoint RemoteNode = (EndPoint)ClientNode;
            Console.WriteLine("Begin sending current date...");
             while (true) {

                DateTime date = DateTime.Now;
                data = Encoding.ASCII.GetBytes(date.ToString());
             
                Broadcast.SendTo(data, data.Length, SocketFlags.None, RemoteNode);
                Thread.Sleep(1000);
            }
            
        }
        
    }
}
