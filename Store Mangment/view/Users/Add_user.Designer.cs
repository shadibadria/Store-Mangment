namespace Store_Mangment.view.Users
{
    partial class Add_user
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_user));
            this.datepicker = new System.Windows.Forms.DateTimePicker();
            this.done = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.header = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // datepicker
            // 
            this.datepicker.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.datepicker.Location = new System.Drawing.Point(109, 238);
            this.datepicker.Name = "datepicker";
            this.datepicker.Size = new System.Drawing.Size(210, 23);
            this.datepicker.TabIndex = 81;
            // 
            // done
            // 
            this.done.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.done.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.done.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.done.Location = new System.Drawing.Point(92, 371);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(257, 49);
            this.done.TabIndex = 80;
            this.done.Text = "סיום";
            this.done.UseVisualStyleBackColor = false;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(106, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 79;
            this.label1.Text = "סיסמה:";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.password.Location = new System.Drawing.Point(109, 328);
            this.password.MaxLength = 12;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(210, 23);
            this.password.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(106, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 77;
            this.label2.Text = "מייל:";
            // 
            // mail
            // 
            this.mail.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.mail.Location = new System.Drawing.Point(109, 283);
            this.mail.MaxLength = 30;
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(210, 23);
            this.mail.TabIndex = 76;
            this.mail.TextChanged += new System.EventHandler(this.mail_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(106, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 75;
            this.label3.Text = "תאריך לידה:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(106, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "מספר טלפון:";
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.phone.Location = new System.Drawing.Point(109, 193);
            this.phone.MaxLength = 12;
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(210, 23);
            this.phone.TabIndex = 73;
            this.phone.TextChanged += new System.EventHandler(this.phone_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(106, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 16);
            this.label5.TabIndex = 72;
            this.label5.Text = "תז:";
            // 
            // id
            // 
            this.id.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.id.Location = new System.Drawing.Point(109, 148);
            this.id.MaxLength = 9;
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(210, 23);
            this.id.TabIndex = 71;
            this.id.TextChanged += new System.EventHandler(this.id_TextChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(106, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 70;
            this.label6.Text = "שם עובד:";
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.name.Location = new System.Drawing.Point(109, 103);
            this.name.MaxLength = 20;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(210, 23);
            this.name.TabIndex = 69;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.header.Location = new System.Drawing.Point(63, 28);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(71, 16);
            this.header.TabIndex = 68;
            this.header.Text = "הוסף עובד";
            // 
            // Add_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.datepicker);
            this.Controls.Add(this.done);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.name);
            this.Controls.Add(this.header);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 489);
            this.MinimumSize = new System.Drawing.Size(416, 489);
            this.Name = "Add_user";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Add_user_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datepicker;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label header;
    }
}