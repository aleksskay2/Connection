using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connection
{
    public partial class fmStatus : Form
    {
        public fmStatus()
        {
            InitializeComponent();
        }

        private void fmStatus_Load(object sender, EventArgs e)
        {
            tbChangeStatus.Text = fmLogin.conData.RetStatus(fmMain.iUser);          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmLogin.conData.ChangeStatus(fmMain.iUser, tbChangeStatus.Text);
            this.Close();
        }
    }
}
