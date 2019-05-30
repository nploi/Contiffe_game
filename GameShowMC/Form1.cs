using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShowMC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
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
            {
                //byte[] buffer = Encoding.ASCII.GetBytes(s);
                //ns.Write(buffer, 0, buffer.Length);
            }

            //client.Client.Shutdown(SocketShutdown.Send);
            //thread.Join();
            //ns.Close();
            //client.Close();
        }
        static void ReceiveData(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int byte_count;

            while ((byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length)) > 0)
            {
                Console.Write(Encoding.ASCII.GetString(receivedBytes, 0, byte_count));
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string question = rtbQuestion.Text;
            string a = txtA.Text;
            string b = txtB.Text;
            string c = txtC.Text;
            string d = txtD.Text;

            string data = string.Format("{0}@@{1}@@{2}@@{3}@@{4}"
                , question, a, b,c,d);
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            _ns.Write(buffer, 0, buffer.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _client.Client.Shutdown(SocketShutdown.Send);
            _thread.Join();
            _ns.Close();
            _client.Close();
        }

        List<Question> _lstQuestions;
        private void button2_Click(object sender, EventArgs e)
        {
            // Read a text file line by line.  
            string path = "C:\\hcmus/questions.txt";
            string[] lines = File.ReadAllLines(path);

            _lstQuestions = new List<Question>();
            Question question = null;
            foreach (string line in lines)
            {
                if(line.StartsWith("@@"))//Question
                {
                    question = new Question();
                    question.Content = line.Substring(2);
                }
                if(line.StartsWith("--"))//Image
                {
                    question.ImageLink = line.Substring(2);
                }
                if (line.StartsWith("$$"))//Answer
                {
                    Answer answer = new Answer();
                    string []M = line.Substring(2).Split(new char[] { '.' });
                    answer.Id = M[0];
                    answer.Content = M[1];

                    question.ListAnswers.Add(answer);
                }

                if (line.StartsWith("%%"))
                    _lstQuestions.Add(question);
            }

            int a = 1;
        }

        int index = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            Question question = _lstQuestions[index];

            rtbQuestion.Text = question.Content;
            txtA.Text = question.ListAnswers[0].Content;
            txtB.Text = question.ListAnswers[1].Content;
            txtC.Text = question.ListAnswers[2].Content;
            txtD.Text = question.ListAnswers[3].Content;

            index++;

        }
    }
}
