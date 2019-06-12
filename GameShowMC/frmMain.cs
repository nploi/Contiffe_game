using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Models;
using MyNetwork;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using System.Threading;
using Audio.MyAudio;

namespace GameShowMC
{
    public partial class frmMain : Form
    {
        private Socket socket;
        private List<Question> questions;
        private int currentIndex = 0;
        private IWebCam webCam = null;
        private Thread timerCountDown;
        private volatile bool connected;
        private volatile bool live;
        private MicrosoftAdpcmChatCodec codec;
        private NetworkAudioSender audioSender;
        private Game game;
        private frmEnterName enterName;
        private ImageLive imageLive = new ImageLive();
        private int seconds = 10;
        private String uri;

        public frmMain()
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

            btnChat.Enabled = false;
            btnNext.Enabled = false;


            enterName = new frmEnterName((uri, yourName, award) =>
            {
                game = new Game();
                game.User.Name = yourName;
                game.Award = award;
                game.User.Type = "mc";
                game.Require = 10;
                game.NumberQuestion = 10;
                this.uri = uri;
                socket = IO.Socket(uri);
                listenEvents();
                socket.Emit("add mc", game.ToJson());
            });
            enterName.StartPosition = FormStartPosition.CenterParent;
        }

        private void listenEvents()
        {
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                connected = true;
            });

            socket.On(Socket.EVENT_DISCONNECT, () =>
            {
                // Reconnect
                disconnectLiveAudio();
                disconnectVideo();
                disconnect();
                //connect();
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
                    btnChat.Enabled = true;
                    lblName.Text = "MC: " + game.User.Name;
                }
                else
                {
                    lbNotifications.Items.Add(message);
                }
            });

            socket.On("added question", (data) =>
            {
                lbNotifications.Items.Add("Broadcast question !!");
                // Do some thing
                var map = Utils.GetMapFromData(data);
                int.TryParse(map["countDown"].ToString(), out seconds);
                timerCountDown = new Thread(countDowner);
                timerCountDown.Start();
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

            socket.On("new message", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var message = MyMessage.FromJson(map["message"].ToString());
                lbNotifications.Items.Add(message.UserName + ": " + message.Content);
            });

            socket.On("tops", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var tops = JsonConvert.DeserializeObject<List<User>>(map["tops"].ToString());
                var question = Question.FromJson(map["question"].ToString());
                int i = 1;
                tops.ForEach((value) =>
                {
                    var str = String.Format("Top {0}: {1} Correct {2}", i, value.Name, value.NumberCorrect);
                    lbNotifications.Items.Add(str);
                    i++;
                });

                if (currentIndex < game.NumberQuestion)
                {
                    nextQuestions();
                }

                btnNext.Enabled = true;
            });

            socket.On("congratulations", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var tops = JsonConvert.DeserializeObject<List<User>>(map["awardRecipients"].ToString());
                int i = 1;
                double bonus = 0;
                double.TryParse(map["bonus"].ToString(), out bonus);

                lbNotifications.Items.Add("*** congratulations ***");
                lbNotifications.Items.Add(String.Format("Bonus: {0} for", bonus));
                tops.ForEach((value) =>
                {
                    var str = String.Format("Top {0}: {1} Correct {2}", i, value.Name, value.NumberCorrect);
                    lbNotifications.Items.Add(str);
                    i++;
                });
                btnNext.Enabled = false;
            });
        }

        void countDowner()
        {
            for (int i = seconds; i >= 0; i--)
            {
                lblCountDowrn.Invoke((MethodInvoker)(()
                    => lblCountDowrn.Text = i.ToString()));
                Thread.Sleep(1000);
            }
            timerCountDown.Join();
            seconds = 10;
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
            nextQuestions();
        }

        private void nextQuestions()
        {
            if (questions == null || questions.Count <= 0 || currentIndex >= questions.Count)
            {
                return;
            }
            resetColorText();
            Question question = questions[currentIndex];
            rtbQuestion.Text = question.Content;
            txtA.Text = question.ListAnswers[0].Content;
            txtB.Text = question.ListAnswers[1].Content;
            txtC.Text = question.ListAnswers[2].Content;
            txtD.Text = question.ListAnswers[3].Content;
            fillColor(question.CorrectAnswerId);
            lblQuestionNumber.Text = String.Format("Question {0}/{1}", currentIndex + 1, questions.Count);
            currentIndex++;
        }

        private void fillColor(string CorrectAnswerId)
        {
            switch (CorrectAnswerId)
            {
                case "a":
                    txtA.ForeColor = Color.Red;
                    break;
                case "b":
                    txtB.ForeColor = Color.Red;
                    break;
                case "c":
                    txtC.ForeColor = Color.Red;
                    break;
                case "d":
                    txtD.ForeColor = Color.Red;
                    break;
            }
        }

        private void resetColorText()
        {
            txtA.ForeColor = Color.Black;
            txtB.ForeColor = Color.Black;
            txtC.ForeColor = Color.Black;
            txtD.ForeColor = Color.Black;
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
                codec = new MicrosoftAdpcmChatCodec();
                webCam = new IWebCam(this.Handle);
                live = true;
                timer1.Start();
                btnLiveStreaming.Text = "Stop";
                connectLiveAudio(0, codec);
                btnLive.BackColor = Color.Red;
            }
            else
            {
                socket.Emit("stop streaming", "");
                btnLive.BackColor = Color.Gray;
                disconnectLiveAudio();
                disconnectVideo();
            }
        }

        private void disconnectVideo()
        {
            btnLiveStreaming.Text = "Streaming";
            live = false;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Image img = webCam.iWebCam_Image;
            if (img != null && live)
            {
                pictureBox1.Image = img;
                img = IImage.ScaleByPercent(img, 40);
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
                if (uri != null)
                {
                    socket = IO.Socket(uri);
                    listenEvents();
                }

                if (game == null)
                {
                    enterName.ShowDialog();
                }
                else
                {
                    socket.Emit("add mc", game.ToJson());
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
                audioSender?.Dispose();
                codec?.Dispose();
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

        private void btnChat_Click(object sender, EventArgs e)
        {
            if (txtChat.Text.Trim().Length <= 0 || game == null)
            {
                return;
            }
            MyMessage message = new MyMessage();
            message.Content = txtChat.Text.Trim();
            message.UserName = game.User.Name;
            socket.Emit("new message", message.ToJson());
            txtChat.Text = "";
            lbNotifications.Items.Add(message.UserName + ": " + message.Content);
        }
    }
}