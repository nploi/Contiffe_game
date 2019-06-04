using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Models;
using Audio.MyAudio;
using MyNetwork;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;

namespace GameShowMC
{
    public partial class Form1 : Form
    {
        Socket socket;
        List<Question> questions;
        int currentIndex = 0;
        IWebCam webCam = null;
        private volatile bool connected;
        private volatile bool live;
        MicrosoftAdpcmChatCodec codec = new MicrosoftAdpcmChatCodec();
        private NetworkAudioSender audioSender;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            Label.CheckForIllegalCrossThreadCalls = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            var pos = this.PointToScreen(lblNumber.Location);
            pos = pictureBox1.PointToClient(pos);
            lblNumber.Text = "0 players";
            lblNumber.Parent = pictureBox1;
            lblNumber.Location = pos;
            lblNumber.BackColor = Color.Transparent;

        }

        private void listenEvents()
        {
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                var user = new User();
                user.Name = "Loi Haiii";
                user.Type = "mc";
                socket.Emit("add mc", user.ToJson());
                connected = true;
            });

            socket.On("login", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                lblNumber.Text = Convert.ToInt32(map["numUsers"]).ToString() + " players";
                var message = map["message"].ToString();
                if (message == "success")
                {
                    readFile();
                    loadQuestions();
                } else
                {
                    MessageBox.Show(message);
                }
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
                var user = User.FromJson(map["user"].ToString());
                listBox1.Items.Add(user.Name + " left");
            });

            socket.On("user answer", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var user = User.FromJson(map["user"].ToString());
                var answer = Answer.FromJson(map["answer"].ToString());
                listBox1.Items.Add(user.Name + ": choiced " + answer.Id);
            });

            socket.On("tops", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var tops = JsonConvert.DeserializeObject<List<User>>(map["tops"].ToString());
                var question = Question.FromJson(map["question"].ToString());
                int i = 1;
                tops.ForEach((value) => {
                    var str = String.Format("Top {0}: {1} Correct {2}", i, value.Name, value.NumberCorrect);
                    listBox1.Items.Add(str);
                });
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
        }

        private void readFile()
        {
            // Read a text file line by line.  
            string path = "D:\\DA_LTW\\GameShowMC\\data.json";
            string data = File.ReadAllText(path);
            // Parse data
            questions = JsonConvert.DeserializeObject<List<Question>>(data.ToString());

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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (webCam == null || live == false)
            {
                webCam = new IWebCam(this.Handle);
                timer1.Start();
                button2.Text = "Stop";
                live = true;
                ConnectLiveAudio(0, codec);
            }
            else
            {
                DisconnectLiveAudio();
                button2.Text = "Live";
                timer1.Stop();
                live = false;
            }
        }
        ImageLive imageLive = new ImageLive();
        private void timer1_Tick(object sender, EventArgs e)
        {
            Image img = webCam.iWebCam_Image;
            if (img != null)
            {
                pictureBox1.Image = img;
                img = IImage.ScaleByPercent(img, 50);
                imageLive.Img1D = IImage.StreamFromImage(img);
                socket.Emit("live video", imageLive.ToJson());
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                //socket = IO.Socket("http://ahihigameshow.herokuapp.com");
                socket = IO.Socket("http://localhost:3000");
                btnConnect.Text = "Disconnect";
                listenEvents();
            } else
            {
                connected = false;
                btnConnect.Text = "Connect";
                socket.Disconnect();
            }
        }

        private void ConnectLiveAudio(int inputDeviceNumber, INetworkChatCodec codec)
        {
            var sender = new SocketIoAudioSender(socket);
            audioSender = new NetworkAudioSender(codec, inputDeviceNumber, sender);
            connected = true;
        }

        private void DisconnectLiveAudio()
        {
            if (connected)
            {
                connected = false;
                audioSender.Dispose();
                codec.Dispose();
            }
        }
    }
}