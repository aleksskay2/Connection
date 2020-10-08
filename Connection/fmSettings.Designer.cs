namespace Connection
{
    partial class fmSettings
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
            this.chbVisiblelbUsers = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chbVisiblelbUsers
            // 
            this.chbVisiblelbUsers.AutoSize = true;
            this.chbVisiblelbUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbVisiblelbUsers.Location = new System.Drawing.Point(28, 25);
            this.chbVisiblelbUsers.Name = "chbVisiblelbUsers";
            this.chbVisiblelbUsers.Size = new System.Drawing.Size(189, 20);
            this.chbVisiblelbUsers.TabIndex = 0;
            this.chbVisiblelbUsers.Text = "Показать список друзей";
            this.chbVisiblelbUsers.UseVisualStyleBackColor = true;
            this.chbVisiblelbUsers.CheckedChanged += new System.EventHandler(this.chbVisiblelbUsers_CheckedChanged);
            // 
            // fmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 321);
            this.Controls.Add(this.chbVisiblelbUsers);
            this.Name = "fmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbVisiblelbUsers;
    }
}