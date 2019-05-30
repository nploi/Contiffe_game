using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShow
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //ConnectServer();
            Thread thread = new Thread(ConnectServer);
            thread.Start();
        }

        TcpClient _client = null;
        Thread _thread = null;
        NetworkStream _ns = null;
        void ConnectServer()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 5000;
            _client = new TcpClient();
            _client.Connect(ip, port);

            Console.WriteLine("client connected!!");
            _ns = _client.GetStream();
            _thread = new Thread(o => ReceiveData((TcpClient)o));
            _thread.Start(_client);

            //string s;
            //while (!string.IsNullOrEmpty((s = Console.ReadLine())))
            //{
            //    byte[] buffer = Encoding.ASCII.GetBytes(s);
            //    ns.Write(buffer, 0, buffer.Length);
            //}

            
        }

        void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                string data = Encoding.ASCII.GetString(receivedBytes, 0, byte_count);

                string[] M = data.Split(new string[] { "@@" }
                , StringSplitOptions.RemoveEmptyEntries);

                if (M.Length > 0)
                {
                    timer1.Enabled = true;
                    lblQuestion.Invoke((MethodInvoker)(() 
                        => lblQuestion.Text = M[0]));

                    btnA.Invoke((MethodInvoker)(()
                        => btnA.Text = M[1]));
                    btnA.Invoke((MethodInvoker)(()
                       => btnB.Text = M[1]));
                    btnC.Invoke((MethodInvoker)(()
                       => btnC.Text = M[1]));
                    btnD.Invoke((MethodInvoker)(()
                       => btnD.Text = M[1]));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "http://www.gravatar.com/avatar/6810d91caff032b202c50701dd3af745?d=identicon&r=PG";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _client.Client.Shutdown(SocketShutdown.Send);
            _thread.Join();
            _ns.Close();
            _client.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reader = new SpeechSynthesizer();
            reader.SpeakAsync("Hello");
        }

        int seconds = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds <= 0) timer1.Enabled = false;
            lbCountDown.Text = seconds.ToString();
            seconds--;
        }
    }
}
