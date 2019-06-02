using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;

namespace GameShowMC
{
    public partial class Form1 : Form
    {
        Socket socket;
        List<Question> questions;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            socket = IO.Socket("http://localhost:3000");


            socket.On(Socket.EVENT_CONNECT, () =>
            {
                // MessageBox.Show("CONNECTED");
                socket.Emit("add user", "MC");
            });

            socket.On("login", (data) =>
            {
                MessageBox.Show("Welcome to Socket.IO Chat – " + data.ToString());
            });

            socket.On("added question", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                MessageBox.Show("Start question: " + map["question"].ToString());
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            socket.Disconnect();
        }

        List<Question> _lstQuestions;
        private void button2_Click(object sender, EventArgs e)
        {
            // Read a text file line by line.  
            string path = "D:\\DA_LTW\\GameShowMC\\data.json";
            string data = File.ReadAllText(path);
            // Parse data
            questions = JsonConvert.DeserializeObject<List<Question>>(data.ToString());
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            Question question = new Question();
            question.Content = "aaaaaaaaaaaaaaaaaaaaa";
            question.CorrectAnswerId = "a";
            question.ListAnswers = new List<Answer>();
            var an1 = new Answer();
            an1.Content = "a";
            an1.Id = "a";
            question.ListAnswers.Add(an1);
            question.ListAnswers.Add(an1);
            question.ListAnswers.Add(an1);
            question.ListAnswers.Add(an1);
            socket.Emit("new question", question.ToJson());
        }
    }
}