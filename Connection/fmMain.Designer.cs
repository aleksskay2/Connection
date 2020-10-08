namespace Connection
{
    partial class fmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.lbSentenceSelUser = new System.Windows.Forms.Label();
            this.laUserMessage = new System.Windows.Forms.Label();
            this.tmRefresh = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btMyProfil = new System.Windows.Forms.Button();
            this.lbUser = new System.Windows.Forms.ListBox();
            this.cmsListUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.скрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btFrend = new System.Windows.Forms.Button();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSend = new System.Windows.Forms.Button();
            this.pbPhotoRemoteUser = new System.Windows.Forms.PictureBox();
            this.btInternet = new System.Windows.Forms.Button();
            this.lbOnline = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSettings = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rtbCommonMessage = new System.Windows.Forms.RichTextBox();
            this.paForMessages = new System.Windows.Forms.Panel();
            this.cmsListUsers.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoRemoteUser)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMessage
            // 
            this.rtbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbMessage.Location = new System.Drawing.Point(28, 17);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(334, 67);
            this.rtbMessage.TabIndex = 1;
            this.rtbMessage.Text = "";
            this.rtbMessage.TextChanged += new System.EventHandler(this.rtbMessage_TextChanged);
            // 
            // lbSentenceSelUser
            // 
            this.lbSentenceSelUser.AutoSize = true;
            this.lbSentenceSelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSentenceSelUser.ForeColor = System.Drawing.Color.Black;
            this.lbSentenceSelUser.Location = new System.Drawing.Point(9, 19);
            this.lbSentenceSelUser.Name = "lbSentenceSelUser";
            this.lbSentenceSelUser.Size = new System.Drawing.Size(152, 15);
            this.lbSentenceSelUser.TabIndex = 4;
            this.lbSentenceSelUser.Text = "Выберите пользователя";
            // 
            // laUserMessage
            // 
            this.laUserMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.laUserMessage.AutoSize = true;
            this.laUserMessage.BackColor = System.Drawing.Color.White;
            this.laUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laUserMessage.ForeColor = System.Drawing.Color.Black;
            this.laUserMessage.Location = new System.Drawing.Point(315, 12);
            this.laUserMessage.Name = "laUserMessage";
            this.laUserMessage.Size = new System.Drawing.Size(263, 25);
            this.laUserMessage.TabIndex = 5;
            this.laUserMessage.Text = "Пользователь не выбран";
            // 
            // tmRefresh
            // 
            this.tmRefresh.Interval = 5000;
            this.tmRefresh.Tick += new System.EventHandler(this.tmRefresh_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Connection";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btMyProfil
            // 
            this.btMyProfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btMyProfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btMyProfil.ForeColor = System.Drawing.Color.Maroon;
            this.btMyProfil.Location = new System.Drawing.Point(12, 572);
            this.btMyProfil.Name = "btMyProfil";
            this.btMyProfil.Size = new System.Drawing.Size(135, 23);
            this.btMyProfil.TabIndex = 8;
            this.btMyProfil.Text = "Мой профиль...";
            this.btMyProfil.UseVisualStyleBackColor = true;
            this.btMyProfil.Click += new System.EventHandler(this.btMyProfil_Click);
            // 
            // lbUser
            // 
            this.lbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbUser.BackColor = System.Drawing.Color.GhostWhite;
            this.lbUser.ContextMenuStrip = this.cmsListUsers;
            this.lbUser.Font = new System.Drawing.Font("Garamond", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.Color.Black;
            this.lbUser.FormattingEnabled = true;
            this.lbUser.ItemHeight = 21;
            this.lbUser.Location = new System.Drawing.Point(12, 44);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(135, 508);
            this.lbUser.TabIndex = 9;
            this.lbUser.SelectedIndexChanged += new System.EventHandler(this.lbUser_SelectedIndexChanged_1);
            this.lbUser.Resize += new System.EventHandler(this.lbUser_Resize);
            // 
            // cmsListUsers
            // 
            this.cmsListUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmsListUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скрытьToolStripMenuItem});
            this.cmsListUsers.Name = "cmsListUsers";
            this.cmsListUsers.ShowImageMargin = false;
            this.cmsListUsers.Size = new System.Drawing.Size(109, 30);
            // 
            // скрытьToolStripMenuItem
            // 
            this.скрытьToolStripMenuItem.Name = "скрытьToolStripMenuItem";
            this.скрытьToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.скрытьToolStripMenuItem.Text = "Скрыть";
            this.скрытьToolStripMenuItem.Click += new System.EventHandler(this.скрытьToolStripMenuItem_Click);
            // 
            // btFrend
            // 
            this.btFrend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFrend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btFrend.ForeColor = System.Drawing.Color.Maroon;
            this.btFrend.Location = new System.Drawing.Point(14, 203);
            this.btFrend.Name = "btFrend";
            this.btFrend.Size = new System.Drawing.Size(170, 25);
            this.btFrend.TabIndex = 10;
            this.btFrend.Text = "Ваш друг";
            this.btFrend.UseVisualStyleBackColor = true;
            // 
            // tbStatus
            // 
            this.tbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStatus.BackColor = System.Drawing.Color.Khaki;
            this.tbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbStatus.ForeColor = System.Drawing.Color.Black;
            this.tbStatus.Location = new System.Drawing.Point(642, 325);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(199, 38);
            this.tbStatus.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.rtbMessage);
            this.panel1.Controls.Add(this.btSend);
            this.panel1.Location = new System.Drawing.Point(172, 481);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 105);
            this.panel1.TabIndex = 12;
            // 
            // btSend
            // 
            this.btSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSend.BackgroundImage = global::Connection.Properties.Resources.PhotoStrelka1;
            this.btSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSend.ForeColor = System.Drawing.Color.Maroon;
            this.btSend.Location = new System.Drawing.Point(373, 17);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(53, 66);
            this.btSend.TabIndex = 2;
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // pbPhotoRemoteUser
            // 
            this.pbPhotoRemoteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPhotoRemoteUser.BackgroundImage = global::Connection.Properties.Resources.BackPhoto1;
            this.pbPhotoRemoteUser.Location = new System.Drawing.Point(14, 37);
            this.pbPhotoRemoteUser.Name = "pbPhotoRemoteUser";
            this.pbPhotoRemoteUser.Size = new System.Drawing.Size(170, 158);
            this.pbPhotoRemoteUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPhotoRemoteUser.TabIndex = 6;
            this.pbPhotoRemoteUser.TabStop = false;
            // 
            // btInternet
            // 
            this.btInternet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInternet.BackColor = System.Drawing.Color.FloralWhite;
            this.btInternet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btInternet.ForeColor = System.Drawing.Color.Black;
            this.btInternet.Location = new System.Drawing.Point(687, 452);
            this.btInternet.Name = "btInternet";
            this.btInternet.Size = new System.Drawing.Size(119, 26);
            this.btInternet.TabIndex = 13;
            this.btInternet.Text = "Интернет";
            this.btInternet.UseVisualStyleBackColor = false;
            this.btInternet.Click += new System.EventHandler(this.btInternet_Click);
            // 
            // lbOnline
            // 
            this.lbOnline.AutoSize = true;
            this.lbOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOnline.Location = new System.Drawing.Point(342, 36);
            this.lbOnline.Name = "lbOnline";
            this.lbOnline.Size = new System.Drawing.Size(0, 16);
            this.lbOnline.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.BackgroundImage = global::Connection.Properties.Resources.BackPhoto;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btFrend);
            this.panel2.Controls.Add(this.pbPhotoRemoteUser);
            this.panel2.Location = new System.Drawing.Point(642, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 409);
            this.panel2.TabIndex = 15;
            // 
            // btSettings
            // 
            this.btSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSettings.ForeColor = System.Drawing.Color.Maroon;
            this.btSettings.Location = new System.Drawing.Point(12, 601);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(135, 23);
            this.btSettings.TabIndex = 17;
            this.btSettings.Text = "Настройка...";
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.PeachPuff;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(166, 629);
            this.panel3.TabIndex = 18;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.ForestGreen;
            this.panel4.Controls.Add(this.rtbCommonMessage);
            this.panel4.Controls.Add(this.paForMessages);
            this.panel4.Location = new System.Drawing.Point(181, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(450, 392);
            this.panel4.TabIndex = 19;
            // 
            // rtbCommonMessage
            // 
            this.rtbCommonMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCommonMessage.BackColor = System.Drawing.Color.FloralWhite;
            this.rtbCommonMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbCommonMessage.Font = new System.Drawing.Font("Garamond", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbCommonMessage.Location = new System.Drawing.Point(32, 63);
            this.rtbCommonMessage.Name = "rtbCommonMessage";
            this.rtbCommonMessage.ReadOnly = true;
            this.rtbCommonMessage.Size = new System.Drawing.Size(375, 263);
            this.rtbCommonMessage.TabIndex = 17;
            this.rtbCommonMessage.Text = "";
            // 
            // paForMessages
            // 
            this.paForMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paForMessages.BackColor = System.Drawing.Color.FloralWhite;
            this.paForMessages.Location = new System.Drawing.Point(19, 39);
            this.paForMessages.Name = "paForMessages";
            this.paForMessages.Size = new System.Drawing.Size(409, 314);
            this.paForMessages.TabIndex = 18;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.MintCream;
            this.BackgroundImage = global::Connection.Properties.Resources.Back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(897, 629);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.lbOnline);
            this.Controls.Add(this.btInternet);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.btMyProfil);
            this.Controls.Add(this.laUserMessage);
            this.Controls.Add(this.lbSentenceSelUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMain_FormClosed);
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.cmsListUsers.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhotoRemoteUser)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label lbSentenceSelUser;
        private System.Windows.Forms.Label laUserMessage;
        private System.Windows.Forms.PictureBox pbPhotoRemoteUser;
        private System.Windows.Forms.Timer tmRefresh;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btMyProfil;
        private System.Windows.Forms.ListBox lbUser;
        private System.Windows.Forms.Button btFrend;
        public System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btInternet;
        private System.Windows.Forms.Label lbOnline;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip cmsListUsers;
        private System.Windows.Forms.ToolStripMenuItem скрытьToolStripMenuItem;
        private System.Windows.Forms.Button btSettings;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox rtbCommonMessage;
        private System.Windows.Forms.Panel paForMessages;
    }
}

