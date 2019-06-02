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
using Quobject.SocketIoClientDotNet.Client;

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

        }


        void ConnectServer()
        {

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

        int seconds = 10;
        void lap()
        {
            for (int i = 0; i < 11; i++)
            {
                lbCountDown.Invoke((MethodInvoker)(()
                    => lbCountDown.Text = seconds.ToString()));
                seconds--;
                Thread.Sleep(1000);
            }
            seconds = 10;

        }

        /*private void timer1_Tick(object sender, EventArgs e)
        {


            //lbCountDown.Text = seconds.ToString();
            //Invoke(new Action(() => { lbCountDown.Text = seconds.ToString(); }));

            lbCountDown.Invoke((MethodInvoker)(()
            => lbCountDown.Text = seconds.ToString()));
           
            seconds--;
            if (seconds < 0)
            {
                seconds = 10;
                timer1.Enabled = false;
                
            }
            //MessageBox.Show(timer1.Enabled.ToString()+seconds);
        }*/

    }
}
