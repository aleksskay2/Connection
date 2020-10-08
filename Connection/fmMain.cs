using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

//Добавленные 

namespace Connection
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
           
            delBox = new delAddrichBox(WriteBox);
            delLabel = new delLabelOnline(WriteLabel);

            delPicture = new delPictureBox(RemotePhoto);
            deltbStatus = new DeltbStatus(ShowStatus);
            btYandex.Click += new EventHandler(btYandex_Click);
            btYoutube.Click += new EventHandler(btYoutube_Click);
            btNews.Click += new EventHandler(btNews_Click);
            btMail.Click += new EventHandler(btMail_Click);
            btSoccer.Click += new EventHandler(btSoccer_Click);
            Paint += new PaintEventHandler(Form1_Paint);//перерисовываем

        }
        Button btNews = new Button();
        Button btMail = new Button();
        Button btYandex = new Button();
        Button btSoccer = new Button();
        Button btYoutube = new Button();

        // переменные
        #region
        public static string iUser; // я как пишущий сообщения
        string remoteUser; // тот, кто мне пишет.
        string iUserRemoteUser; // название таблицы
        OpenFileDialog openFile = new OpenFileDialog();
        public static string status = ""; // для хранения статуса
        bool stopRefresh = false; // переменная для определения обновления сообщений
        public delegate void DelTimer(RichTextBox richTextBox);      
        DataSet dataSet;
        delAddrichBox delBox;
        delegate void delLabelOnline(string userOnline);
        delLabelOnline delLabel;
        delegate void delAddrichBox(DataSet dataSet); // 
        delegate void delPictureBox(Image image);
        delegate void DeltbStatus(string status);
        DeltbStatus deltbStatus;
        delPictureBox delPicture;
        Thread thread;
        bool OffEvent = false;
        List<string> listMessage = new List<string>(); //  Сообщения обеих пользователей.
        List<string> listAllMessageUsers = new List<string>();//Сообщения всех пользователей.
        List<string> listAllUsers = new List<string>(); // список всех, человек которые видны у usera
        bool sameMessage = false;
        bool WillAdd = false;// указывает, что нужно добавить сообщения.
        #endregion

        private void fmMain_Load(object sender, EventArgs e)
        {    
        //    ConnectionData con = new ConnectionData();            
            iUser = fmLogin.FirstTable;
            tmRefresh.Enabled = true;
            pbPhotoRemoteUser.SizeMode = PictureBoxSizeMode.Zoom;
            InputLanguage.CurrentInputLanguage =
            InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-Ru"));
            int leftPanelWidth = this.ClientRectangle.Width / 8;
            panel3.Width = leftPanelWidth+leftPanelWidth/8;
            lbUser.Width = leftPanelWidth;
            btMyProfil.Width = leftPanelWidth;
            btSettings.Width = leftPanelWidth;
            paForMessages.Left = leftPanelWidth/4;
            rtbCommonMessage.Left = leftPanelWidth/3;
            panel4.Left = leftPanelWidth + leftPanelWidth / 4;
            panel4.Width = leftPanelWidth * 5;
            paForMessages.Width = leftPanelWidth * 4+leftPanelWidth/2;
            rtbCommonMessage.Width = leftPanelWidth * 4+leftPanelWidth/3;
            rtbMessage.Width = leftPanelWidth * 2+
                (leftPanelWidth/2)+(leftPanelWidth/2)+(leftPanelWidth/3)+300  ;
            panel1.Width = panel4.Width;
            
            panel1.Left = leftPanelWidth+leftPanelWidth/3-leftPanelWidth/10;
            rtbMessage.Left = leftPanelWidth/10 ;
            lbUser.DataSource = fmLogin.conData.DisplayNames;


            
            lbUser.DisplayMember = "DisplayName";
            lbUser.ValueMember = "UserLogin";
            OffEvent = true;
            
            laUserMessage.Text = "Пользователь не выбран";
            laUserMessage.Left = leftPanelWidth * 3+leftPanelWidth/2;
            lbOnline.Left = laUserMessage.Left +20;                     
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            //Pen pen = new Pen(Brushes.Violet, 4);
            //pen.LineJoin = LineJoin.Bevel;//задаем скошенные углы
            //pen.MiterLimit = 50;//задаем ограничение толщины скошенных углов
            //g.DrawRectangle(pen, new Rectangle(rtbCommonMessage.Location.X - 1,
            //    rtbCommonMessage.Location.Y - 1, rtbCommonMessage.Width + 3,
            //    rtbCommonMessage.Height + 3));
            ////рисуем прямоугольник с параметрами испоьзуемыми выше            
            //// ex Hermein
            //if (lbUser.Visible)
            //g.DrawRectangle(pen, new Rectangle(lbUser.Location.X - 1,
            //   lbUser.Location.Y - 1, lbUser.Width + 3,
            //   lbUser.Height + 3));

        }


        // запрос сообщений через новый поток
        // чтобы не блокировать работу с интерфейсами
        private void ForThreadMessages()
        {
            thread = new Thread(new ThreadStart(RetData));
            thread.Start();
        }
         
        // Меняем цвет текста в rtbCommonMessage
        public void AppendText(RichTextBox richTextBox, string text, Color color)
        {
            int line = 0;
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.SelectionLength = 0;
            richTextBox.SelectionColor = color;
            //if (sameMessage == true)
            //{
            //    if (!listMessage.Contains(text))
            //    {
            //        richTextBox.SelectionAlignment = HorizontalAlignment.Center;
            //        richTextBox.AppendText(
            //       "---------------------Новое сообщение----------------" + "\r\n"
            //            );
            //    }
            //}
            richTextBox.AppendText(text);
            listMessage.Add(text);
            richTextBox.ForeColor = richTextBox.ForeColor;
        }

        private void ShowStatus(string status)
        {
            tbStatus.Text = status;
        }

        Thread threadPhoto;

        // Здесть создаем отдельный поток для того,
        // чтобы показать статус и фото.
        private void threadShowPhoto()
        {
            threadPhoto = new Thread(new ThreadStart(ShowPhotoAndStatus));
            threadPhoto.Start();
        }

        private void RemotePhoto(Image image)
        {
            pbPhotoRemoteUser.Image = image;
        }

        // Для передачи в поток
        // threadPhoto
        private void ShowPhotoAndStatus ()
        {
           
            Image image = fmLogin.conData.ShowPhotoAndStatus(remoteUser, out status);
            if (status == "") return;
            pbPhotoRemoteUser.Invoke(delPicture, new object[] { image });
            tbStatus.Invoke(deltbStatus, new object[] { status });
        }

        string online = "";

        public void RetData()
        {
            try
            {

                dataSet = new DataSet();
                dataSet = fmLogin.conData.SelData("SELECT * FROM (SELECT TOP(9) * FROM  " +
                                                   iUserRemoteUser +               
                                                   " ORDER BY  timeOfRecord DESC ) " +
                                                   iUserRemoteUser + " ORDER BY timeOfRecord ");
                //foreach(string user in lbUser.Items)
                //{
                     
                //    dataSet = fmLogin.conData.SelData("SELECT * FROM (SELECT TOP(10) * FROM  " +
                //                                                   iUserRemoteUser +
                //                                                   " ORDER BY  timeOfRecord DESC ) " +
                //                                                   iUserRemoteUser + " ORDER BY timeOfRecord ");

                //}


                rtbCommonMessage.Invoke(delBox, new object[] { dataSet });
                online = fmLogin.conData.RetValueOnline(remoteUser);
                // показываем онлан или не онлайн у пользователя.
                lbOnline.Invoke(delLabel, new object[] { online });
            }
            catch(IndexOutOfRangeException )
            {
               // MessageBox.Show("Выполнение запроса");
            }                  
        }

        private bool refreshMessages = false;
        DateTime date = new DateTime();
        DateTime date2 = new DateTime();

        private void WriteLabel(string userOnline)
        {            
            if ( userOnline == "True")
                lbOnline.Text = "Онлайн";
            else if (userOnline == "False")
                lbOnline.Text = "Вне сети";
        }

        // Добавляем сообщение в rtbCommonMessage через поток.
        public void WriteBox(DataSet dataset)
        {
            DataRow rowSel = null;
            if ( dataSet.Tables[0].Rows.Count > 0)
            {
                rowSel = dataset.Tables[0].Rows[dataset.Tables[0].Rows.Count - 1];
                if (!refreshMessages)
                {
                    date = (DateTime)rowSel["timeOfRecord"];
                    date2 = (DateTime)rowSel["timeOfRecord"];
                    rtbCommonMessage.Clear();
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        if (row["Users"].ToString() == iUser)
                        {
                            rtbCommonMessage.SelectionAlignment = HorizontalAlignment.Right;
                            AppendText(rtbCommonMessage,
                                    row["UserText"].ToString() + "\r\n" + "\r\n", Color.Black);
                            //  rtbCommonMessage.AppendText(row["UserText"].ToString() + "\r\n" + "\r\n");
                        }
                        if (row["Users"].ToString() == remoteUser)
                        {
                            rtbCommonMessage.SelectionAlignment = HorizontalAlignment.Left;
                            AppendText(rtbCommonMessage,
                                row["UserText"].ToString() + "\r\n" + "\r\n", Color.Blue);
                        }
                    }

                }

                if (refreshMessages)
                {
                    date = (DateTime)rowSel["timeOfRecord"];
                }

                if (date != date2)
                {
                    rtbCommonMessage.Clear();
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        if (row["Users"].ToString() == iUser)
                        {
                            rtbCommonMessage.SelectionAlignment = HorizontalAlignment.Right;
                            AppendText(rtbCommonMessage,
                                    row["UserText"].ToString() + "\r\n" + "\r\n", Color.Black);
                            //  rtbCommonMessage.AppendText(row["UserText"].ToString() + "\r\n" + "\r\n");
                        }
                        if (row["Users"].ToString() == remoteUser)
                        {
                            rtbCommonMessage.SelectionAlignment = HorizontalAlignment.Left;
                            AppendText(rtbCommonMessage,
                                row["UserText"].ToString() + "\r\n" + "\r\n", Color.Blue);
                        }
                    }
                }
                refreshMessages = true;
                sameMessage = true; //Это говорит, что один раз добавлены сообщения.
            }

             
        }
    
        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if ((thread != null) && (threadPhoto != null))
                {
                    thread.Abort();
                    threadPhoto.Abort();
                }

                fmLogin.conData.ChangeOnline(iUser, 0);
            }
            catch(Exception exp)
            {
                ;
            }
           
            Application.Exit();
        }
        
        public void SelectTable(string tableMessages)
        {
          //Выбрать таблицу
            fmLogin.conData.SelData("SELECT * FROM (SELECT TOP(10) * FROM  " + tableMessages +
                " ORDER BY timeOfRecord DESC ) " + tableMessages+ " ORDER BY timeOfRecord "); 
            if (fmLogin.FirstTable == iUser)
            fmLogin.conData.GetMessages(rtbCommonMessage, iUser, remoteUser);            
        }
       

        // метод, который выбирает удаленнного пользователя
        //listNames - перечень всех таблиц из базы данных
        //
        //
       private void SelectedRemoteUser(List<string> listTableNames)
       {
           string tableSelect ="";
           remoteUser = fmLogin.conData.ModifyName(lbUser.Text);
           iUserRemoteUser = iUser + remoteUser;
           foreach(string table in listTableNames)
           {
               if (table == iUserRemoteUser  || table == remoteUser + iUser)
               {
                   tableSelect = table;
                   break;
               }
                               
           }
           iUserRemoteUser = tableSelect;
           ForThreadMessages();
           threadShowPhoto();    
       }
        // Отправка сообщения удаленному пользователю
        private void btSend_Click(object sender, EventArgs e)
        {
            if (rtbMessage.Text != "")
            {
                fmLogin.conData.SendMessage(iUserRemoteUser, rtbMessage.Text,
               iUser);
                rtbMessage.Clear();
                lbUser_SelectedIndexChanged_1(null, null); // Обновление окна сообщения
            }
           
        }



        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            if ((laUserMessage.Text != "Пользователь не выбран") && (stopRefresh == false))
            {
                ForThreadMessages();
            }     
        }
                              
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
               // this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Maximized;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (WindowState == FormWindowState.Minimized)
            {
                stopRefresh = true;
                this.ShowInTaskbar = false;
                this.Visible = false;                
            }

            if (WindowState == FormWindowState.Maximized)
            {                
                stopRefresh = false;
            }
        }

        private void btMyProfil_Click(object sender, EventArgs e)
        {
            fmMyProfil fmMyProfil = new fmMyProfil();
            fmMyProfil.ShowDialog();
        }

        private void lbUser_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            refreshMessages = false;
            rtbCommonMessage.Clear();
            //lbUser.SelectedIndex = 0;
            remoteUser = this.lbUser.Text;
            // Над сообщениями указываем имя человека с которым общаемся
            laUserMessage.Text = lbUser.Text;
           // laUserMessage.Left = rtbCommonMessage.Left +
               // rtbCommonMessage.Width - rtbCommonMessage.Width / 2 - laUserMessage.Width / 2;
          
            if (OffEvent)   
            SelectedRemoteUser(fmLogin.conData.TableNames);    
            
        }
        

        private void btInternet_Click(object sender, EventArgs e)
        {
            
            if (btInternet.Text == "Интернет")
            {               
                btYandex.BackColor = Color.White;
                btYandex.Font = new System.Drawing.Font("Microsft Sans Serif", 10);
                btYandex.Text = "Яндекс";
                btYandex.Anchor = btInternet.Anchor;
                btYandex.Width = btInternet.Width;
                btYandex.Height = btInternet.Height;
                btYandex.Location = new Point(btInternet.Left, btInternet.Top + 30);
                this.Controls.Add(btYandex);
  
                btNews.BackColor = Color.White;
                btNews.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
                btNews.Text = "Новости";
                btNews.Anchor = btInternet.Anchor;
                btNews.Width = btInternet.Width;
                btNews.Height = btInternet.Height;
                btNews.Location = new Point(btInternet.Left, btInternet.Top + 60);
                this.Controls.Add(btNews);

                btMail.BackColor = Color.White;
                btMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
                btMail.Text = "Почта";
                btMail.Anchor = btInternet.Anchor;
                btMail.Width = btInternet.Width;
                btMail.Height = btInternet.Height;
                btMail.Location = new Point(btInternet.Left, btInternet.Top + 90);
                this.Controls.Add(btMail);

                btYoutube.BackColor = Color.White;
                btYoutube.Font = new Font("Microsoft Sans Serif", 10);
                btYoutube.Text = "Youtube";
                btYoutube.Anchor = btInternet.Anchor;
                btYoutube.Width = btInternet.Width;
                btYoutube.Height = btInternet.Height;
                btYoutube.Location = new Point(btInternet.Left, btInternet.Top + 120);
                this.Controls.Add(btYoutube);

                btSoccer.BackColor = Color.White;
                btSoccer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
                btSoccer.Text = "Футбол";
                btSoccer.Anchor = btInternet.Anchor;
                btSoccer.Width = btInternet.Width;
                btSoccer.Height = btInternet.Height;
                btSoccer.Location = new Point(btInternet.Left, btInternet.Top + 150);
                this.Controls.Add(btSoccer);

                btYandex.Show();
                btNews.Show();
                btMail.Show();
                btSoccer.Show();
                btYoutube.Show();
                btInternet.Text = "Скрыть";
            }
            else
            {               
                btYandex.Hide();
                btNews.Hide();
                btMail.Hide();
                btSoccer.Hide();
                btYoutube.Hide();
                btInternet.Text = "Интернет";
            }           
        }


        private void btYandex_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome.exe", "http:\\www.yandex.ru");
        }
        private void btYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome.exe", "http:\\www.youtube.com");
        }

        private void btNews_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome.exe", "http:\\news.yandex.ru/");
        }

        private void btMail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome.exe", "http:\\www.mail.ru");
        }

        private void btSoccer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome.exe", "http:\\www.soccer.ru");
        }

        private void lbUser_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void rtbCommonMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void скрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // скрываем список друзей.
            lbUser.Visible = !lbUser.Visible;
            this.Invalidate();
            lbSentenceSelUser.Visible = !lbSentenceSelUser.Visible;
           
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            fmSettings form = new fmSettings();
            form.Show();
        }

        private void rtbMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
