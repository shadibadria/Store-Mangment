namespace Store_Mangment.view
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.clock = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.extbtn = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.enterybtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.email_addr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // clock
            // 
            this.clock.AutoSize = true;
            this.clock.BackColor = System.Drawing.Color.Transparent;
            this.clock.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.clock.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clock.Location = new System.Drawing.Point(453, 194);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(36, 16);
            this.clock.TabIndex = 24;
            this.clock.Text = "שעה";
            this.clock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.BackColor = System.Drawing.Color.Transparent;
            this.date.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.date.Location = new System.Drawing.Point(368, 216);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(47, 16);
            this.date.TabIndex = 23;
            this.date.Text = "תאריך";
            // 
            // extbtn
            // 
            this.extbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.extbtn.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.extbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.extbtn.Location = new System.Drawing.Point(132, 147);
            this.extbtn.Name = "extbtn";
            this.extbtn.Size = new System.Drawing.Size(83, 38);
            this.extbtn.TabIndex = 22;
            this.extbtn.Text = "יציאה";
            this.extbtn.UseVisualStyleBackColor = false;
            this.extbtn.Click += new System.EventHandler(this.extbtn_Click);
            // 
            // username
            // 
            this.username.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.username.Location = new System.Drawing.Point(132, 80);
            this.username.MaxLength = 9;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(227, 23);
            this.username.TabIndex = 18;
            // 
            // enterybtn
            // 
            this.enterybtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.enterybtn.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.enterybtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.enterybtn.Location = new System.Drawing.Point(276, 147);
            this.enterybtn.Name = "enterybtn";
            this.enterybtn.Size = new System.Drawing.Size(83, 38);
            this.enterybtn.TabIndex = 16;
            this.enterybtn.Text = "כניסה";
            this.enterybtn.UseVisualStyleBackColor = false;
            this.enterybtn.Click += new System.EventHandler(this.enterybtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(365, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "הזן סיסמה:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(365, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "הזן תז:";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.password.Location = new System.Drawing.Point(132, 118);
            this.password.MaxLength = 12;
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(227, 23);
            this.password.TabIndex = 20;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-7, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(540, 267);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.clock);
            this.tabPage1.Controls.Add(this.username);
            this.tabPage1.Controls.Add(this.date);
            this.tabPage1.Controls.Add(this.password);
            this.tabPage1.Controls.Add(this.extbtn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.enterybtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(532, 241);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "כניסה";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Store_Mangment.Properties.Resources.login;
            this.pictureBox2.Location = new System.Drawing.Point(231, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.email_addr);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(532, 241);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "איפוס סיסמה";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Store_Mangment.Properties.Resources.password;
            this.pictureBox1.Location = new System.Drawing.Point(237, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // email_addr
            // 
            this.email_addr.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.email_addr.Location = new System.Drawing.Point(147, 102);
            this.email_addr.MaxLength = 30;
            this.email_addr.Name = "email_addr";
            this.email_addr.Size = new System.Drawing.Size(227, 23);
            this.email_addr.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(327, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "הזן תז:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.button1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(221, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 38);
            this.button1.TabIndex = 19;
            this.button1.Text = "שלח";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(214)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(530, 264);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(546, 303);
            this.MinimumSize = new System.Drawing.Size(546, 303);
            this.Name = "Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label clock;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Button extbtn;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button enterybtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox email_addr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}