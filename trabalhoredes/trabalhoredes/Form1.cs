using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace trabalhoredes
{
    public partial class Form1 : Form
    {
        private BinaryWriter escreve;
        private BinaryWriter escrever2;
        private BinaryReader ler;
        private BinaryReader ler2;
        private NetworkStream saida;
        private NetworkStream socketStream;
        private Random random = new Random();
        private int i;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TcpClient cliente = new TcpClient();



            cliente.Connect(GetLocalIPAddress(), 5155);
      
            saida = cliente.GetStream();


            escreve = new BinaryWriter(saida);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          


            ler = new BinaryReader(saida);
            label2.Text = ler.ReadString();
        }
        public  IPAddress[] GetLocalIPAddress()//retorna o ip 
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] ips=new IPAddress[100];
       
            int i = 0;
            foreach (var ip in host.AddressList)
            {
                //if (ip.AddressFamily == AddressFamily.InterNetwork)
                //{
                //    return ip.ToString();
                //}
                ips[i] = ip;
                i++;

            }
       
            return ips;
        }

        //var host = Dns.GetHostEntry(Dns.GetHostName());
    
        //    foreach (var ip in host.AddressList)
        //    {
        //        //if (ip.AddressFamily == AddressFamily.InterNetwork)
        //        //{
        //        //    return ip.ToString();
        //        //}
        //    

        //    }
        //    throw new Exception("");
}
}
