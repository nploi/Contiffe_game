﻿using System;
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
        int currentIndex = 0;
        public Form1()
        {
            InitializeComponent();
            socket = IO.Socket("http://localhost:3000");
            Label.CheckForIllegalCrossThreadCalls = false;
            lblNumber.Text = "0 players";
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                var user = new User();
                user.Name = "Loi Hai";
                user.Type = "mc";
                socket.Emit("add user", user.ToJson());
                readFile();
                loadQuestions();
            });

            socket.On("login", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                lblNumber.Text = Convert.ToInt32(map["numUsers"]).ToString() + " players";
               // MessageBox.Show("Start question: " + map["user"].ToString());
            });

            socket.On("added question", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                //MessageBox.Show("Start question: " + map["question"].ToString());
                Question question = Question.FromJson(map["question"].ToString());
            });

            socket.On("user joined", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                lblNumber.Text = Convert.ToInt32(map["numUsers"]).ToString() + " players";
                var user = User.FromJson(map["user"].ToString());
                listBox1.Items.Add(user.Name + " Joined");
            });

            socket.On("user left", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                lblNumber.Text = Convert.ToInt32(map["numUsers"]).ToString() + " players";
                var user = User.FromJson(map["username"].ToString());
                listBox1.Items.Add(user.Name + " left");
            });
        }



        private void button1_Click(object sender, EventArgs e)
        {
            socket.Disconnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Read a text file line by line.  
            string path = "D:\\DA_LTW\\GameShowMC\\data.json";
            string data = File.ReadAllText(path);
            // Parse data
            questions = JsonConvert.DeserializeObject<List<Question>>(data.ToString());
            //if (questions.Count <= 0)
            //{
            //    MessageBox.Show("Failed");
            //} else
            //{
            //    MessageBox.Show("Success");
            //}
        }

        private void readFile()
        {
            // Read a text file line by line.  
            string path = "D:\\DA_LTW\\GameShowMC\\data.json";
            string data = File.ReadAllText(path);
            // Parse data
            questions = JsonConvert.DeserializeObject<List<Question>>(data.ToString());
            //if (questions.Count <= 0)
            //{
            //    MessageBox.Show("Failed");
            //}
            //else
            //{
            //    MessageBox.Show("Success");
            //}
        }

        private void loadQuestions()
        {
            if (questions == null || questions.Count <= 0 || currentIndex >= questions.Count)
            {
                return;
            }
            Question question = questions[currentIndex];
            rtbQuestion.Text = question.Content;
            txtA.Text = question.ListAnswers[0].Content;
            txtB.Text = question.ListAnswers[1].Content;
            txtC.Text = question.ListAnswers[2].Content;
            txtD.Text = question.ListAnswers[3].Content;
            socket.Emit("new question", questions[currentIndex].ToJson());
            currentIndex++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadQuestions();
        }
    }
}