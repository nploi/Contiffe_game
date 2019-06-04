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

namespace GameShow
{
    public partial class Form1 : Form
    {
        Socket socket;
        ImageLive imageLive = new ImageLive();
        private Thread timerCountDown;
        private NetworkAudioPlayer player;
        bool connected = false;
        MicrosoftAdpcmChatCodec codec = new MicrosoftAdpcmChatCodec();
        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            Label.CheckForIllegalCrossThreadCalls = false;
            //var pos = this.PointToScreen(lbCountDown.Location);
            //pos = pictureBox1.PointToClient(pos);
            lblNumber.Text = "0 players";
            //lbCountDown.Parent = pictureBox1;
            //lbCountDown.Location = pos;
            //lbCountDown.BackColor = Color.Transparent;
            //var pos1 = this.PointToScreen(lblQuestion.Location);
            //pos1 = pictureBox1.PointToClient(pos1);
            //lblQuestion.Parent = pictureBox1;
            //lblQuestion.Location = pos1;
            // lblQuestion.BackColor = Color.Transparent;
        }

        private void listenEvents()
        {
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                var user = new User();
                user.Name = RandomString(10);
                user.Type = "user";
                socket.Emit("add user", user.ToJson());
                connected = true;
            });

            socket.On("login", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                lblNumber.Text = Convert.ToInt32(map["numUsers"]).ToString() + " players";
                var message = map["message"].ToString();
                if (message != "success")
                {
                    MessageBox.Show(message);
                }
            });

            socket.On("next question", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                Question question = Question.FromJson(map["question"].ToString());
               // speakQuestion(question);
                loadQuestions(question);
                int.TryParse(map["countDown"].ToString(), out seconds);
                timerCountDown = new Thread(lap);
                timerCountDown.Start();
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

            socket.On("correct answer", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                var correctAnswer = map["answer"].ToString();
                listBox1.Items.Add(correctAnswer + " is correct !!");
            });

            socket.On("live video", (data) =>
            {
                var map = Utils.GetMapFromData(data);
                imageLive = ImageLive.FromJson(map["image"].ToString());

                if (imageLive != null && imageLive.Img1D != null)
                {
                    pictureBox3.Refresh();
                    pictureBox3.Image = IImage.ImageFromStream(imageLive.Img1D);
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
                    listBox1.Items.Add(str);
                });
            });
        }



        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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
                socket = IO.Socket("http://localhost:3000");
                //socket = IO.Socket("http://ahihigameshow.herokuapp.com");
                listenEvents();
                var reciever = new SocketIoAudioReceiver(socket);
                player = new NetworkAudioPlayer(codec, reciever);
                btnConnect.Text = "Disconnect";
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


        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "http://www.gravatar.com/avatar/6810d91caff032b202c50701dd3af745?d=identicon&r=PG";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {

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
        private int counter = 10;

        int seconds = 10;
        void lap()
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

        Answer answer = new Answer();
        private void btnA_Click(object sender, EventArgs e)
        {
            answer.Id = "a";
            socket.Emit("answer", answer.ToJson());
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            answer.Id = "b";
            socket.Emit("answer", answer.ToJson());
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            answer.Id = "c";
            socket.Emit("answer", answer.ToJson());
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            answer.Id = "d";
            socket.Emit("answer", answer.ToJson());
        }

    }
}
