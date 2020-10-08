namespace Connection
{
    partial class fmMyPicture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMyPicture));
            this.pbMyPhoto = new System.Windows.Forms.PictureBox();
            this.btChangePhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMyPhoto
            // 
            this.pbMyPhoto.Location = new System.Drawing.Point(69, 24);
            this.pbMyPhoto.Name = "pbMyPhoto";
            this.pbMyPhoto.Size = new System.Drawing.Size(170, 195);
            this.pbMyPhoto.TabIndex = 0;
            this.pbMyPhoto.TabStop = false;
            // 
            // btChangePhoto
            // 
            this.btChangePhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btChangePhoto.ForeColor = System.Drawing.Color.Maroon;
            this.btChangePhoto.Location = new System.Drawing.Point(69, 242);
            this.btChangePhoto.Name = "btChangePhoto";
            this.btChangePhoto.Size = new System.Drawing.Size(170, 27);
            this.btChangePhoto.TabIndex = 1;
            this.btChangePhoto.Text = "Выбрать фото";
            this.btChangePhoto.UseVisualStyleBackColor = true;
            this.btChangePhoto.Click += new System.EventHandler(this.btChangePhoto_Click);
            // 
            // fmMyPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(308, 302);
            this.Controls.Add(this.btChangePhoto);
            this.Controls.Add(this.pbMyPhoto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmMyPicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мое фото";
            ((System.ComponentModel.ISupportInitialize)(this.pbMyPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbMyPhoto;
        private System.Windows.Forms.Button btChangePhoto;
    }
}