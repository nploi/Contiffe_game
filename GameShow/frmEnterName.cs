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
        Action<string, string> OnRegister;

        public frmEnterName(Action<string, string> OnRegister)
        {
            InitializeComponent();
            this.OnRegister = OnRegister;
        }


        private void btnStart_Click_1(object sender, EventArgs e)
        {
            var yourName = tbName.Text;
            var uri = tbURI.Text;
            if (yourName.Count() <= 0)
            {
                MessageBox.Show("Invalid input !");
                return;
            }

            if (uri.Count() <= 0)
            {
                uri = "http://localhost:3000";
            }
            
            OnRegister(uri.ToLower(), yourName);
        }
    }
}
