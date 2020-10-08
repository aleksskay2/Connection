using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.IO;

namespace Connection
{
    public partial class fmMyPicture : Form
    {
        public fmMyPicture()
        {
            InitializeComponent();
        }

        private void btChangePhoto_Click(object sender, EventArgs e)
        {
            // Выбор фотографии для себя 
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.FileName = "";
            openFile.Filter = "Image files(*.jpg)|*.jpg";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //string name = Path.GetFileName(openFile.FileName);
                string name = openFile.FileName;

                byte[] data = File.ReadAllBytes(name);
                fmLogin.conData.AddPhoto(fmLogin.FirstTable, data);               
            }
            //fmMyPicture fmMyPicture = new fmMyPicture();
           // fmLogin.conData.ShowPhoto(fmMyPicture.pbMyPhoto, fmLogin.FirstTable,
             //   out fmMain.status);        
        }

        
    }
}
