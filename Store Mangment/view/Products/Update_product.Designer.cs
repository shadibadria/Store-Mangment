namespace Store_Mangment.view.products
{
    partial class Update_product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Update_product));
            this.label4 = new System.Windows.Forms.Label();
            this.product_count = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.barcodepictrue = new System.Windows.Forms.PictureBox();
            this.print_barcode = new System.Windows.Forms.Button();
            this.product_code = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.newsupplier = new System.Windows.Forms.Button();
            this.donebtn = new System.Windows.Forms.Button();
            this.displaysupplier = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.product_price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.product_name = new System.Windows.Forms.TextBox();
            this.display_category = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.newcategory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.barcodepictrue)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 85;
            this.label4.Text = "מחיר (₪):";
            // 
            // product_count
            // 
            this.product_count.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.product_count.Location = new System.Drawing.Point(89, 273);
            this.product_count.MaxLength = 5;
            this.product_count.Name = "product_count";
            this.product_count.Size = new System.Drawing.Size(220, 23);
            this.product_count.TabIndex = 84;
            this.product_count.TextChanged += new System.EventHandler(this.product_count_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(12, 320);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 16);
            this.label12.TabIndex = 82;
            this.label12.Text = "באר_קוד";
            // 
            // barcodepictrue
            // 
            this.barcodepictrue.Location = new System.Drawing.Point(88, 311);
            this.barcodepictrue.Name = "barcodepictrue";
            this.barcodepictrue.Size = new System.Drawing.Size(219, 35);
            this.barcodepictrue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.barcodepictrue.TabIndex = 81;
            this.barcodepictrue.TabStop = false;
            // 
            // print_barcode
            // 
            this.print_barcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.print_barcode.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.print_barcode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.print_barcode.Location = new System.Drawing.Point(309, 311);
            this.print_barcode.Name = "print_barcode";
            this.print_barcode.Size = new System.Drawing.Size(61, 35);
            this.print_barcode.TabIndex = 80;
            this.print_barcode.Text = "הדפס";
            this.print_barcode.UseVisualStyleBackColor = false;
            this.print_barcode.Click += new System.EventHandler(this.print_barcode_Click);
            // 
            // product_code
            // 
            this.product_code.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.product_code.Location = new System.Drawing.Point(88, 38);
            this.product_code.MaxLength = 12;
            this.product_code.Name = "product_code";
            this.product_code.ReadOnly = true;
            this.product_code.Size = new System.Drawing.Size(220, 23);
            this.product_code.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(24, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 77;
            this.label5.Text = "קוד:";
            // 
            // newsupplier
            // 
            this.newsupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.newsupplier.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.newsupplier.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newsupplier.Location = new System.Drawing.Point(314, 133);
            this.newsupplier.Name = "newsupplier";
            this.newsupplier.Size = new System.Drawing.Size(61, 25);
            this.newsupplier.TabIndex = 75;
            this.newsupplier.Text = "חדש";
            this.newsupplier.UseVisualStyleBackColor = false;
            this.newsupplier.Click += new System.EventHandler(this.newsupplier_Click);
            // 
            // donebtn
            // 
            this.donebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.donebtn.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.donebtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.donebtn.Location = new System.Drawing.Point(46, 366);
            this.donebtn.Name = "donebtn";
            this.donebtn.Size = new System.Drawing.Size(296, 44);
            this.donebtn.TabIndex = 76;
            this.donebtn.Text = "עדכן מוצר";
            this.donebtn.UseVisualStyleBackColor = false;
            this.donebtn.Click += new System.EventHandler(this.donebtn_Click);
            // 
            // displaysupplier
            // 
            this.displaysupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displaysupplier.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.displaysupplier.FormattingEnabled = true;
            this.displaysupplier.Location = new System.Drawing.Point(88, 133);
            this.displaysupplier.Name = "displaysupplier";
            this.displaysupplier.Size = new System.Drawing.Size(220, 24);
            this.displaysupplier.TabIndex = 74;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(21, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 72;
            this.label10.Text = "ספק:";
            // 
            // product_price
            // 
            this.product_price.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.product_price.Location = new System.Drawing.Point(89, 225);
            this.product_price.MaxLength = 10;
            this.product_price.Name = "product_price";
            this.product_price.Size = new System.Drawing.Size(220, 23);
            this.product_price.TabIndex = 65;
            this.product_price.TextChanged += new System.EventHandler(this.product_price_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(27, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 64;
            this.label2.Text = "שם:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(24, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "סוג :";
            // 
            // product_name
            // 
            this.product_name.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.product_name.Location = new System.Drawing.Point(88, 181);
            this.product_name.MaxLength = 20;
            this.product_name.Name = "product_name";
            this.product_name.Size = new System.Drawing.Size(220, 23);
            this.product_name.TabIndex = 62;
            this.product_name.TextChanged += new System.EventHandler(this.product_name_TextChanged);
            // 
            // display_category
            // 
            this.display_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.display_category.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.display_category.FormattingEnabled = true;
            this.display_category.Location = new System.Drawing.Point(88, 87);
            this.display_category.Name = "display_category";
            this.display_category.Size = new System.Drawing.Size(220, 24);
            this.display_category.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(18, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 68;
            this.label3.Text = "כמות:";
            // 
            // newcategory
            // 
            this.newcategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.newcategory.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.newcategory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newcategory.Location = new System.Drawing.Point(315, 87);
            this.newcategory.Name = "newcategory";
            this.newcategory.Size = new System.Drawing.Size(61, 25);
            this.newcategory.TabIndex = 66;
            this.newcategory.Text = "חדש";
            this.newcategory.UseVisualStyleBackColor = false;
            this.newcategory.Click += new System.EventHandler(this.newcategory_Click);
            // 
            // Update_product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(382, 422);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.product_count);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.barcodepictrue);
            this.Controls.Add(this.print_barcode);
            this.Controls.Add(this.product_code);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.newsupplier);
            this.Controls.Add(this.donebtn);
            this.Controls.Add(this.displaysupplier);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.product_price);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.product_name);
            this.Controls.Add(this.display_category);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newcategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(398, 461);
            this.MinimumSize = new System.Drawing.Size(398, 461);
            this.Name = "Update_product";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Update_product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barcodepictrue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox product_count;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox barcodepictrue;
        private System.Windows.Forms.Button print_barcode;
        private System.Windows.Forms.TextBox product_code;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button newsupplier;
        private System.Windows.Forms.Button donebtn;
        private System.Windows.Forms.ComboBox displaysupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox product_price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox product_name;
        private System.Windows.Forms.ComboBox display_category;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button newcategory;
    }
}