using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(ThongBao);
            thread.Start();
        }

        void ThongBao()
        {
            MessageBox.Show("Thông báo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(DoHeavyTasks);
            thread.Start();
        }

        void DoHeavyTasks()
        {
            for (int i = 1; i < 100; i++)
            {
                Thread.Sleep(1000);
            }

            MessageBox.Show("I'm fine!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a = new
            {
                Name = "Tran Van",
                Description = "Just demo"
            };

            Thread thread = new Thread(DemoThreadWithParameters);
            thread.Start(a);
        }

        void DemoThreadWithParameters(object o)
        {
            dynamic obj = o;
            MessageBox.Show(obj.Name);
        }
    }
}
