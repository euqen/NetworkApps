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
            Socket TCPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint Node = new IPEndPoint(IPAddress.Any, SERVER_PORT);
            TCPSocket.Bind(Node);

            try
            {
                TCPSocket.Listen(10);
                while (true)
                {
                   Socket handler = TCPSocket.Accept();
                   Console.WriteLine(handler.LocalEndPoint.ToString() + " =>. Send date...");
                   
                   DateTime date = DateTime.Now;
                   data = Encoding.ASCII.GetBytes(date.ToString());

                   handler.Send(data);
                   Thread.Sleep(1000);           
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ooops! Something wrong! " + e.ToString());
                Console.ReadLine();
            }
            finally
            {
                TCPSocket.Shutdown(SocketShutdown.Both);
                TCPSocket.Close();
            }
        }
        
    }
}
