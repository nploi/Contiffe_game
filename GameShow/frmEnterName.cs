using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShow
{
    public partial class frmEnterName : Form
    {
        Action<string> OnRegister;

        public frmEnterName(Action<string> OnRegister)
        {
            InitializeComponent();
            this.OnRegister = OnRegister;
        }


        private void btnStart_Click_1(object sender, EventArgs e)
        {
            var yourName = txtName.Text;
            if (yourName.Count() <= 0)
            {
                MessageBox.Show("Enter your name !");
                return;
            }

            OnRegister(yourName);
        }
    }
}
