namespace Store_Mangment.view.Mails
{
    partial class Mail_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mail_form));
            this.label7 = new System.Windows.Forms.Label();
            this.from = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.TextBox();
            this.to = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.send = new System.Windows.Forms.Button();
            this.body = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(329, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 109;
            this.label7.Text = "פרטי חיבור:";
            // 
            // from
            // 
            this.from.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.from.Location = new System.Drawing.Point(220, 87);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(307, 23);
            this.from.TabIndex = 90;
            this.from.TextChanged += new System.EventHandler(this.from_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(133, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 88;
            this.label5.Text = "הכנס מייל:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(114, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 89;
            this.label6.Text = "הכנס סיסמה:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pass
            // 
            this.pass.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.pass.Location = new System.Drawing.Point(220, 121);
            this.pass.Name = "pass";
            this.pass.PasswordChar = '*';
            this.pass.Size = new System.Drawing.Size(307, 23);
            this.pass.TabIndex = 91;
            this.pass.TextChanged += new System.EventHandler(this.pass_TextChanged);
            // 
            // to
            // 
            this.to.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.to.Location = new System.Drawing.Point(220, 188);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(307, 23);
            this.to.TabIndex = 105;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(164, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 102;
            this.label2.Text = "נושא:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(133, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 101;
            this.label1.Text = "אל/כתובת:";
            // 
            // subject
            // 
            this.subject.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.subject.Location = new System.Drawing.Point(220, 221);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(307, 23);
            this.subject.TabIndex = 100;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label58.Location = new System.Drawing.Point(329, 9);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(65, 16);
            this.label58.TabIndex = 99;
            this.label58.Text = "שלח מייל";
            // 
            // send
            // 
            this.send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.send.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.send.Location = new System.Drawing.Point(275, 492);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(137, 50);
            this.send.TabIndex = 98;
            this.send.Text = "שלח";
            this.send.UseVisualStyleBackColor = false;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // body
            // 
            this.body.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.body.Location = new System.Drawing.Point(141, 285);
            this.body.MaxLength = 200;
            this.body.Multiline = true;
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(436, 191);
            this.body.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(138, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 104;
            this.label4.Text = "תוכן:";
            // 
            // Mail_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(729, 567);
            this.Controls.Add(this.from);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.body);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.to);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.send);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(745, 606);
            this.MinimumSize = new System.Drawing.Size(745, 606);
            this.Name = "Mail_form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Mail_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox from;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.TextBox to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox body;
        private System.Windows.Forms.Label label4;
    }
}