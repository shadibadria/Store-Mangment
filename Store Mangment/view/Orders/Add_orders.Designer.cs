namespace Store_Mangment.view.Orders
{
    partial class Add_orders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_orders));
            this.newsupplier = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.order_name = new System.Windows.Forms.TextBox();
            this.add_orderbtn = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Label();
            this.order_info = new System.Windows.Forms.TextBox();
            this.displaysupplier = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newsupplier
            // 
            this.newsupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.newsupplier.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.newsupplier.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newsupplier.Location = new System.Drawing.Point(499, 100);
            this.newsupplier.Name = "newsupplier";
            this.newsupplier.Size = new System.Drawing.Size(46, 23);
            this.newsupplier.TabIndex = 57;
            this.newsupplier.Text = "חדש";
            this.newsupplier.UseVisualStyleBackColor = false;
            this.newsupplier.Click += new System.EventHandler(this.newsupplier_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(71, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "תוכן הזמנה:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(88, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "שם הזמנה:";
            // 
            // order_name
            // 
            this.order_name.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.order_name.Location = new System.Drawing.Point(91, 100);
            this.order_name.MaxLength = 20;
            this.order_name.Name = "order_name";
            this.order_name.Size = new System.Drawing.Size(180, 23);
            this.order_name.TabIndex = 54;
            this.order_name.TextChanged += new System.EventHandler(this.order_name_TextChanged);
            // 
            // add_orderbtn
            // 
            this.add_orderbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.add_orderbtn.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.add_orderbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.add_orderbtn.Location = new System.Drawing.Point(188, 404);
            this.add_orderbtn.Name = "add_orderbtn";
            this.add_orderbtn.Size = new System.Drawing.Size(257, 49);
            this.add_orderbtn.TabIndex = 53;
            this.add_orderbtn.Text = "סיום";
            this.add_orderbtn.UseVisualStyleBackColor = false;
            this.add_orderbtn.Click += new System.EventHandler(this.add_orderbtn_Click);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.header.Location = new System.Drawing.Point(41, 23);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(127, 16);
            this.header.TabIndex = 52;
            this.header.Text = "הוסף הזמנה חדשה:";
            // 
            // order_info
            // 
            this.order_info.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.order_info.Location = new System.Drawing.Point(74, 181);
            this.order_info.MaxLength = 500;
            this.order_info.Multiline = true;
            this.order_info.Name = "order_info";
            this.order_info.Size = new System.Drawing.Size(442, 198);
            this.order_info.TabIndex = 51;
            this.order_info.TextChanged += new System.EventHandler(this.order_info_TextChanged);
            // 
            // displaysupplier
            // 
            this.displaysupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displaysupplier.FormattingEnabled = true;
            this.displaysupplier.Location = new System.Drawing.Point(313, 102);
            this.displaysupplier.Name = "displaysupplier";
            this.displaysupplier.Size = new System.Drawing.Size(180, 21);
            this.displaysupplier.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(310, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 49;
            this.label10.Text = "ספק:";
            // 
            // Add_orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(587, 477);
            this.Controls.Add(this.newsupplier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.order_name);
            this.Controls.Add(this.add_orderbtn);
            this.Controls.Add(this.header);
            this.Controls.Add(this.order_info);
            this.Controls.Add(this.displaysupplier);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(603, 516);
            this.MinimumSize = new System.Drawing.Size(603, 516);
            this.Name = "Add_orders";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Add_orders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newsupplier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox order_name;
        private System.Windows.Forms.Button add_orderbtn;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.TextBox order_info;
        private System.Windows.Forms.ComboBox displaysupplier;
        private System.Windows.Forms.Label label10;
    }
}