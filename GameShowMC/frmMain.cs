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
using System.Threading;

namespace GameShowMC
{
    public partial class frmMain : Form
    {
        Socket socket;
        List<Question> questions;
        int currentIndex = 0;
        IWebCam webCam = null;
        private volatile bool connected;
        private volatile bool live;
        private volatile bool sent = false;
        MicrosoftAdpcmChatCodec codec = new MicrosoftAdpcmChatCodec();
        private NetworkAudioSender audioSender;
        User user;

        frmEnterName enterName;

        public frmMain()
        {
            InitializeComponent();
            init();
            btnNext.Enabled = false;
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
                connected = true;
            });

            socket.On("login", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                lblNumber.Text = Convert.ToInt32(map["numUsers"]).ToString() + " players";
                var message = map["message"].ToString();
                if (message == "success")
                {
                    btnConnect.Text = "Disconnect";
                    btnLiveStreaming.Enabled = true;
                    btnLoadFile.Enabled = true;
                    enterName.Close();
                    lbNotifications.Items.Add("You are MC, =))");
                }
                else
                {
                    lbNotifications.Items.Add(message);
                }
            });

            socket.On("added question", (data) =>
            {
                lbNotifications.Items.Add("broadcast question success");
                // Do some thing
                // var map = Utils.GetMapFromData(data);
                // MessageBox.Show("Start question: " + map["question"].ToString());
                // Question question = Question.FromJson(map["question"].ToString());
            });

            socket.On("user joined", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                lblNumber.Text = Convert.ToInt32(map["numUsers"]).ToString() + " players";
                var user = User.FromJson(map["user"].ToString());
                lbNotifications.Items.Add(user.Name + " Joined");
            });

            socket.On("user left", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                lblNumber.Text = Convert.ToInt32(map["numUsers"]).ToString() + " players";
                var user = User.FromJson(map["user"].ToString());
                lbNotifications.Items.Add(user.Name + " left");
            });

            socket.On("user answer", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var user = User.FromJson(map["user"].ToString());
                var answer = Answer.FromJson(map["answer"].ToString());
                lbNotifications.Items.Add(user.Name + ": choiced " + answer.Id);
            });

            socket.On("tops", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var tops = JsonConvert.DeserializeObject<List<User>>(map["tops"].ToString());
                var question = Question.FromJson(map["question"].ToString());
                int i = 1;
                tops.ForEach((value) => {
                    var str = String.Format("Top {0}: {1} Correct {2}", i, value.Name, value.NumberCorrect);
                    lbNotifications.Items.Add(str);
                    i++;
                });

                nextQuestions();
                btnNext.Enabled = true;
            });
        }


        private void button1_Click(object sender, EventArgs e)
        {
            socket.Disconnect();
        }

        private void readFile(string path)
        {
            // Read a text file line by line.  
            string data = File.ReadAllText(path);
            // Parse data
            questions = JsonConvert.DeserializeObject<List<Question>>(data.ToString());
            MessageBox.Show(questions.Count.ToString());
            btnNext.Enabled = true;
            btnNext.Text = "Send";
            currentIndex = 0;
            sent = false;
            nextQuestions();
        }

        private void nextQuestions()
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
            lblQuestionNumber.Text = String.Format("Question {0}/{1}", currentIndex + 1, questions.Count);
            currentIndex++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = false;
            socket.Emit("new question", questions[currentIndex - 1].ToJson());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (webCam == null || live == false)
            {
                webCam = new IWebCam(this.Handle);
                live = true;
                timer1.Start();
                btnLiveStreaming.Text = "Stop";
                connectLiveAudio(0, codec);
            }
            else
            {
                disconnectLiveAudio();
                disconnectVideo();
            }
        }

        private void disconnectVideo()
        {
            btnLiveStreaming.Text = "Live";
            live = false;
            timer1.Stop();
        }

        ImageLive imageLive = new ImageLive();
        private void timer1_Tick(object sender, EventArgs e)
        {
            Image img = webCam.iWebCam_Image;
            if (img != null && live)
            {
                pictureBox1.Image = img;
                img = IImage.ScaleByPercent(img, 50);
                imageLive.Img1D = IImage.StreamFromImage(img);
                socket.Emit("live video", imageLive.ToJson());
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void connect()
        {
            if (!connected)
            {
                //socket = IO.Socket("http://ahihigameshow.herokuapp.com");
                socket = IO.Socket("http://10.248.62.133:3000");
                listenEvents();

                if (user == null)
                {
                    enterName = new frmEnterName((yourName, amount) =>
                    {
                        //MessageBox.Show(amount.ToString());
                        //MessageBox.Show(yourName);
                        user = new User();
                        user.Name = yourName;
                        user.Type = "mc";
                        socket.Emit("add mc", user.ToJson());
                    });
                    enterName.ShowDialog();
                } else
                {
                    socket.Emit("add mc", user.ToJson());
                }
            }
            else
            {
                disconnect();
                disconnectLiveAudio();
                disconnectVideo();
            }
        }

        private void disconnect()
        {
            btnLiveStreaming.Enabled = false;
            btnLoadFile.Enabled = false;
            connected = false;
            btnConnect.Text = "Connect";
            socket.Disconnect();
        }

        private void connectLiveAudio(int inputDeviceNumber, INetworkChatCodec codec)
        {
            var sender = new SocketIoAudioSender(socket);
            audioSender = new NetworkAudioSender(codec, inputDeviceNumber, sender);
            connected = true;
        }

        private void disconnectLiveAudio()
        {
            if (connected)
            {
                audioSender.Dispose();
                codec.Dispose();
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "d:\\";
            openFileDialog1.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                readFile(selectedFileName);
            }
        }
    }
}