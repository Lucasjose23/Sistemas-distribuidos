using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "";

            UdpClient cliente = new UdpClient(8008);


            IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 8008);


            Console.WriteLine(" Cliente ");
            Console.WriteLine("espere...");
            while (data != "q")
            {
                byte[] receivedBytes=null;
                for (int i = 0; i < 3; i++)
                {

                
                
                    receivedBytes = cliente.Receive(ref remoteIPEndPoint);
                    data = Encoding.ASCII.GetString(receivedBytes);
                    Console.WriteLine("do servidor " + remoteIPEndPoint + " - ");
                    Console.WriteLine("Mensagem" + data.TrimEnd());
                    System.Threading.Thread.Sleep(1000);
                }

                   
                
            }

            Console.WriteLine("enter");
            Console.ReadLine(); //delay end of program
            cliente.Close();  //close the connection
        }

    }

 
}
