using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = "";
            byte[] sendBytes = new Byte[1024];
            byte[] rcvPacket = new Byte[1024];
            UdpClient servidor = new UdpClient();
            IPAddress address = IPAddress.Parse(IPAddress.Broadcast.ToString());
            servidor.Connect(address, 8008);
            IPEndPoint remoteIPEndPoint = new IPEndPoint(IPAddress.Any, 8008);

            Console.WriteLine("servidor");
            Console.WriteLine("..");
            string[]  s = new string[] { "Fiat Argo, você sente", "Uma vez Flamengo, sempre Flamengo", "SportTV o canal do esporte", "Trivago, pensou hotel, Trivago" };

            while (data != "q")
                {
                while (true)
                {
                    for (int i = 0; i < 3; i++)
                    {



                        data = s[i];
                        sendBytes = Encoding.ASCII.GetBytes(DateTime.Now.ToString() + " " + data);
                        servidor.Send(sendBytes, sendBytes.GetLength(0));
                        System.Threading.Thread.Sleep(1000);

                    }
                }
                }
            
            Console.WriteLine("Close Port Command Sent");  //user feedback
            Console.ReadLine();
            servidor.Close();  //close connection


        }
    }
}
