using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace front_end
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver();
        }

        public static void Receiver() {

            byte[] data;
            Console.WriteLine("Starting server...");
            const int SERVER_PORT = 8085;
            const int CLIENT_PORT = 8086;

            Socket Receive = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint Node = new IPEndPoint(IPAddress.Any, CLIENT_PORT);
            Receive.Bind(Node);

            IPEndPoint ServerNode = new IPEndPoint(IPAddress.Any, SERVER_PORT);
            EndPoint RemoteNode = (EndPoint)ServerNode;
            Console.WriteLine("Server started successfully.");
            Console.WriteLine("Begin receiving current time....");
            Thread.Sleep(3000);

            while (true)
            {
                data = new byte[1024];
                int count;
                Console.WriteLine("Server is unavalible");
                count =  Receive.ReceiveFrom(data, ref RemoteNode);
                
                Console.WriteLine(data.ToString());
                string message = Encoding.ASCII.GetString(data);
                Console.Clear();
                Console.WriteLine(message);
                Thread.Sleep(1000);
            }
        }
    }
}
