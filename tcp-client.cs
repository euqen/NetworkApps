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

            Console.WriteLine("=======WELCOME TO CLIENT APPLICATION=======");
            const int SERVER_PORT = 8085;
            string IP;

            Console.WriteLine("Server IP:");
            IP = Console.ReadLine();

            Socket TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint Node = new IPEndPoint(IPAddress.Parse(IP), SERVER_PORT);

            try
            {
                byte[] bytes = new byte[1024];

                while (true)
                {
                    TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    TCPSocket.Connect(Node);

                    TCPSocket.Receive(bytes);
                    string message = Encoding.ASCII.GetString(bytes);

                    Console.WriteLine(message);
                    Thread.Sleep(1000);
                    Console.Clear();

                    TCPSocket.Disconnect(false);
                    Console.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ooops! Something wrong! \n"  + e.ToString());
                Console.Read();
            }
            finally 
            {
                TCPSocket.Shutdown(SocketShutdown.Both);
                TCPSocket.Close();
            }
        }
    }
}
