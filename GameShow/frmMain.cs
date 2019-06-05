using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;
using Models;
using Audio.MyAudio;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using MyNetwork;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace GameShow
{
    public partial class frmMain : Form
    {
        private Socket socket;
        private ImageLive imageLive = new ImageLive();
        private Thread timerCountDown;
        private NetworkAudioPlayer player;
        private bool connected = false;
        private  MicrosoftAdpcmChatCodec codec = new MicrosoftAdpcmChatCodec();
        private User user;
        private frmEnterName enterName;
        private Answer answer = new Answer();
        private Game game;
        private int seconds = 10;

        public frmMain()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            Label.CheckForIllegalCrossThreadCalls = false;
            var pos = this.PointToScreen(lbCountDown.Location);
            pos = pLive.PointToClient(pos);
            lblNumber.Text = "0 players";
            lbCountDown.Parent = pLive;
            lbCountDown.Location = pos;
            lbCountDown.BackColor = Color.Transparent;

            pos = this.PointToScreen(lblQuestion.Location);
            pos = pLive.PointToClient(pos);
            lblQuestion.Parent = pLive;
            lblQuestion.Location = pos;
            lblQuestion.BackColor = Color.Transparent;

            pos = this.PointToScreen(lblCorrect.Location);
            pos = pLive.PointToClient(pos);
            lblCorrect.Parent = pLive;
            lblCorrect.Location = pos;
            lblCorrect.BackColor = Color.Transparent;
            lblCorrect.Text = "Correct: 0";

            pos = this.PointToScreen(lblAward.Location);
            pos = pLive.PointToClient(pos);
            lblAward.Parent = pLive;
            lblAward.Location = pos;
            lblAward.BackColor = Color.Transparent;
            lblAward.Text = "";

            lblQuestion.MaximumSize = new Size(400, 0);
            lblQuestion.AutoSize = true;
            btnChat.Enabled = false;

            hideQuestion();
        }

        private void listenEvents()
        {
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                //var user = new User();
                //user.Name = RandomString(10);
                //user.Type = "user";
                //socket.Emit("add user", user.ToJson());
                connected = true;
            });

            socket.On(Socket.EVENT_DISCONNECT, () =>
            {
                connect();
            });

            socket.On("login", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                lblNumber.Text = Convert.ToInt32(map["numUsers"]).ToString() + " players";
                var message = map["message"].ToString();
                if (message == "success")
                {
                    lbNotifications.Items.Add("You joined <3");
                    var reciever = new SocketIoAudioReceiver(socket);
                    player = new NetworkAudioPlayer(codec, reciever);
                    btnConnect.Text = "Disconnect";
                    enterName.Close();
                    btnChat.Enabled = true;
                    lblName.Text = "Player: " + user.Name;
                }
                else
                {
                    lbNotifications.Items.Add(message);
                }
            });

            socket.On("mc connected", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                game = Game.FromJson(map["game"].ToString());
                lbNotifications.Items.Add(String.Format("MC {0} joined", game.User.Name));
                lblAward.Text = String.Format("{0} $", game.Award);
            });

            socket.On("mc disconnected", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var mc = User.FromJson(map["user"].ToString());
                lbNotifications.Items.Add(String.Format("MC {0} left", mc.Name));
            });

            socket.On("next question", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                Question question = Question.FromJson(map["question"].ToString());
               // speakQuestion(question);
                loadQuestions(question);
                int.TryParse(map["countDown"].ToString(), out seconds);
                timerCountDown = new Thread(countDowner);
                timerCountDown.Start();
                showQuestion();
                resetColorButtons();
                enableButtons();
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

            socket.On("correct answer", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var correctAnswer = map["answer"].ToString();
                lbNotifications.Items.Add(correctAnswer + " is correct !!");
                disableButtons();
                showCorrectAnswer(correctAnswer);
            });


            socket.On("new message", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var message = MyMessage.FromJson(map["message"].ToString());
                lbNotifications.Items.Add(message.UserName + ": " + message.Content);
            });

            socket.On("live video", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                imageLive = ImageLive.FromJson(map["image"].ToString());

                if (imageLive != null && imageLive.Img1D != null)
                {
                    pLive.Refresh();
                    pLive.Image = IImage.ImageFromStream(imageLive.Img1D);
                }
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
                    if (value.Name == user.Name)
                    {
                        user = value;
                        lblCorrect.Text = String.Format("Correct: {0}", user.NumberCorrect);
                    }
                });
            });

            socket.On("congratulations", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                int i = 1;
                int bonus = 0;
                int.TryParse(map["bonus"].ToString(), out bonus);

                lbNotifications.Items.Add(String.Format("Admin: Congratulations {0}", user.Name));
                lbNotifications.Items.Add(String.Format("Bonus {0} for you", bonus));
            });
        }

        private void loadQuestions(Question question)
        {
            if (question == null)
            {
                return;
            }
            lblQuestion.Text = question.Content;
            btnA.Text = question.ListAnswers[0].Content;
            btnB.Text = question.ListAnswers[1].Content;
            btnC.Text = question.ListAnswers[2].Content;
            btnD.Text = question.ListAnswers[3].Content;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (connected == false)
            {
                connect();
            }
            else
            {
                btnConnect.Text = "Connect";
                player.Dispose();
                codec.Dispose();
                socket.Disconnect();
                connected = false;
            }
        }

        private void connect()
        {
            socket = IO.Socket("http://localhost:3000");
            //socket = IO.Socket("http://ahihigameshow.herokuapp.com");
            listenEvents();
            if (user == null)
            {
                enterName = new frmEnterName((yourName) =>
                {
                    user = new User();
                    user.Name = yourName;
                    user.Type = "user";
                    socket.Emit("add user", user.ToJson());
                });
                enterName.ShowDialog();
            }
            else
            {
                socket.Emit("add user", user.ToJson());
            }
        }


        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    pictureBox1.ImageLocation = "http://www.gravatar.com/avatar/6810d91caff032b202c50701dd3af745?d=identicon&r=PG";
        //}

        private void hideQuestion()
        {
            btnA.SendToBack();
            btnB.SendToBack();
            btnC.SendToBack();
            btnD.SendToBack();
        }

        private void disableButtons()
        {
            btnA.Enabled = false;
            btnB.Enabled = false;
            btnC.Enabled = false;
            btnD.Enabled = false;
        }

        private void showYourAnswer(string YourAnswerId)
        {
            switch (YourAnswerId)
            {
                case "a":
                    btnA.BackColor = Color.Red;
                    break;
                case "b":
                    btnB.BackColor = Color.Red;
                    break;
                case "c":
                    btnC.BackColor = Color.Red;
                    break;
                case "d":
                    btnD.BackColor = Color.Red;
                    break;
            }
        }

        private void showCorrectAnswer(string CorrectAnswer)
        {
            switch (CorrectAnswer)
            {
                case "a":
                    btnA.BackColor = Color.Green;
                    break;
                case "b":
                    btnB.BackColor = Color.Green;
                    break;
                case "c":
                    btnC.BackColor = Color.Green;
                    break;
                case "d":
                    btnD.BackColor = Color.Green;
                    break;
            }
        }

        private void resetColorButtons()
        {
            btnA.BackColor = Color.White;
            btnB.BackColor = Color.White;
            btnC.BackColor = Color.White;
            btnD.BackColor = Color.White;
        }

        private void enableButtons()
        {
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
        }

        private void showQuestion()
        {
            btnA.BringToFront();
            btnB.BringToFront();
            btnC.BringToFront();
            btnD.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reader = new SpeechSynthesizer();

            reader.SpeakAsync(lblQuestion.Text);
        }

        void speakQuestion(Question question)
        {
            var reader = new SpeechSynthesizer();

            if (question == null)
            {
                return;
            }
            reader.SpeakAsync(question.Content
                + "A. " + question.ListAnswers[0].Content
                + "B. " + question.ListAnswers[1].Content
                + "C. " + question.ListAnswers[2].Content
                + "D. " + question.ListAnswers[3].Content);
        }

        void countDowner()
        {
            for (int i = seconds; i >= 0; i--)
            {
                lbCountDown.Invoke((MethodInvoker)(()
                    => lbCountDown.Text = i.ToString()));
                Thread.Sleep(1000);
            }
            timerCountDown.Join();
            seconds = 10;
        }


        private void btnA_Click(object sender, EventArgs e)
        {
            answer.Id = "a";
            socket.Emit("answer", answer.ToJson());
            showYourAnswer(answer.Id);
            disableButtons();
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            answer.Id = "b";
            socket.Emit("answer", answer.ToJson());
            showYourAnswer(answer.Id);
            disableButtons();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            answer.Id = "c";
            socket.Emit("answer", answer.ToJson());
            showYourAnswer(answer.Id);
            disableButtons();
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            answer.Id = "d";
            socket.Emit("answer", answer.ToJson());
            showYourAnswer(answer.Id);
            disableButtons();
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            if (txtChat.Text.Trim().Length <= 0 || user == null)
            {
                return;
            }
            MyMessage message = new MyMessage();
            message.Content = txtChat.Text.Trim();
            message.UserName = user.Name;
            socket.Emit("new message", message.ToJson());
            txtChat.Text = "";
            lbNotifications.Items.Add(message.UserName + ": " + message.Content);
        }
    }
}
