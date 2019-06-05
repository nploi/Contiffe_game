using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShowMC
{
    public partial class frmEnterName : Form
    {
        Action<string, int> OnRegister;

        public frmEnterName(Action<string, int> OnRegister)
        {
            InitializeComponent();
            this.OnRegister = OnRegister;
        }


        private void btnStart_Click_1(object sender, EventArgs e)
        {
            var yourName = txtName.Text;
            int amount;

            if (yourName.Count() <= 0 || !int.TryParse(txtReward.Text, out amount))
            {
                MessageBox.Show("Invalid input");
                return;
            }

          OnRegister(yourName, amount);
        }
    }
}
