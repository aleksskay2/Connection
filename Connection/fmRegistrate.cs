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
    public partial class fmRegistrate : Form
    {
        public fmRegistrate()
        {
            InitializeComponent();
        }

        private void btRegistrate_Click(object sender, EventArgs e)
        {
            fmLogin.Open();
            try
            {
                fmLogin.conData.AddNewUser(tbNewLogin.Text, tbNewPassword.Text); 
            }

            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            MessageBox.Show("Вы зарегистрированы в приложении Connection ! Поздравляю! ");
                       
        }

        private void tbNewLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            if ((symbol < 'А' || symbol > 'я') && symbol != '\b' && symbol != '.')
            {
                e.Handled = true;
            }
        }
    }
}
