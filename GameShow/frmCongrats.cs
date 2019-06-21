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
    public partial class frmCongrats : Form
    {
        public frmCongrats(String name, int numberCorrect, double bonus)
        {
            InitializeComponent();

            lbName.Text = String.Format("Name: {0}", name);
            lbNumberCorrect.Text = String.Format("Correct: {0}", numberCorrect);
            lbBonus.Text = String.Format("Bonus: {0}", bonus);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
