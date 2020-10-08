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
    public partial class fmMyProfil : Form
    {
        public fmMyProfil()
        {
            InitializeComponent();
        }

        private void btMyPhoto_Click(object sender, EventArgs e)
        {
            fmMyPicture fmMyPicture = new fmMyPicture();                      
            Image image =  fmLogin.conData.ShowPhotoAndStatus ( fmLogin.FirstTable, out fmMain.status);
            fmMyPicture.pbMyPhoto.Image = image;
            fmMyPicture.pbMyPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            fmMyPicture.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmStatus fm = new fmStatus();
            fm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fmHelp fm = new fmHelp();
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fmAbout fmAbout = new fmAbout();
            fmAbout.ShowDialog();
        }
    }
}
