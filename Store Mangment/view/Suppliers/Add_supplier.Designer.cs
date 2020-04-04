namespace Store_Mangment.view.Suppliers
{
    partial class Add_supplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_supplier));
            this.title = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.supplier_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.supplier_phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.supplier_adress = new System.Windows.Forms.TextBox();
            this.donebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.supplier_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.title.Location = new System.Drawing.Point(127, 54);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(76, 16);
            this.title.TabIndex = 61;
            this.title.Text = "הוסף ספק:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(44, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "מייל:";
            // 
            // supplier_email
            // 
            this.supplier_email.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.supplier_email.Location = new System.Drawing.Point(47, 269);
            this.supplier_email.MaxLength = 40;
            this.supplier_email.Name = "supplier_email";
            this.supplier_email.Size = new System.Drawing.Size(260, 23);
            this.supplier_email.TabIndex = 59;
            this.supplier_email.TextChanged += new System.EventHandler(this.supplier_email_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(44, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "טלפון:";
            // 
            // supplier_phone
            // 
            this.supplier_phone.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.supplier_phone.Location = new System.Drawing.Point(47, 214);
            this.supplier_phone.MaxLength = 12;
            this.supplier_phone.Name = "supplier_phone";
            this.supplier_phone.Size = new System.Drawing.Size(260, 23);
            this.supplier_phone.TabIndex = 57;
            this.supplier_phone.TextChanged += new System.EventHandler(this.supplier_phone_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(44, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "כתובת:";
            // 
            // supplier_adress
            // 
            this.supplier_adress.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.supplier_adress.Location = new System.Drawing.Point(47, 158);
            this.supplier_adress.MaxLength = 30;
            this.supplier_adress.Name = "supplier_adress";
            this.supplier_adress.Size = new System.Drawing.Size(260, 23);
            this.supplier_adress.TabIndex = 55;
            this.supplier_adress.TextChanged += new System.EventHandler(this.supplier_adress_TextChanged);
            // 
            // donebtn
            // 
            this.donebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.donebtn.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.donebtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.donebtn.Location = new System.Drawing.Point(47, 312);
            this.donebtn.Name = "donebtn";
            this.donebtn.Size = new System.Drawing.Size(260, 37);
            this.donebtn.TabIndex = 54;
            this.donebtn.Text = "סיום";
            this.donebtn.UseVisualStyleBackColor = false;
            this.donebtn.Click += new System.EventHandler(this.donebtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(44, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "שם ספק:";
            // 
            // supplier_name
            // 
            this.supplier_name.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.supplier_name.Location = new System.Drawing.Point(47, 104);
            this.supplier_name.MaxLength = 20;
            this.supplier_name.Name = "supplier_name";
            this.supplier_name.Size = new System.Drawing.Size(260, 23);
            this.supplier_name.TabIndex = 52;
            this.supplier_name.TextChanged += new System.EventHandler(this.supplier_name_TextChanged);
            // 
            // Add_supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(351, 380);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.supplier_email);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.supplier_phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.supplier_adress);
            this.Controls.Add(this.donebtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supplier_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(367, 419);
            this.MinimumSize = new System.Drawing.Size(367, 419);
            this.Name = "Add_supplier";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Add_supplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox supplier_email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox supplier_phone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox supplier_adress;
        private System.Windows.Forms.Button donebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox supplier_name;
    }
}