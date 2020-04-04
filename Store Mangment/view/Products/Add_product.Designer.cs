namespace Store_Mangment.view
{
    partial class Add_product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_product));
            this.cancelallproduct = new System.Windows.Forms.Button();
            this.add_productlist = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productcount = new System.Windows.Forms.TextBox();
            this.productcode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.newsupplier = new System.Windows.Forms.Button();
            this.displaysupplier = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.add_newcategory = new System.Windows.Forms.Button();
            this.display_category = new System.Windows.Forms.ComboBox();
            this.product_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.product_price = new System.Windows.Forms.TextBox();
            this.removefromlist = new System.Windows.Forms.Button();
            this.addtolistbtn = new System.Windows.Forms.Button();
            this.addproductbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.add_productlist)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelallproduct
            // 
            this.cancelallproduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.cancelallproduct.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.cancelallproduct.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelallproduct.Location = new System.Drawing.Point(1017, 422);
            this.cancelallproduct.Name = "cancelallproduct";
            this.cancelallproduct.Size = new System.Drawing.Size(135, 43);
            this.cancelallproduct.TabIndex = 21;
            this.cancelallproduct.Text = "לבטל הכל";
            this.cancelallproduct.UseVisualStyleBackColor = false;
            this.cancelallproduct.Click += new System.EventHandler(this.cancelallproduct_Click_1);
            // 
            // add_productlist
            // 
            this.add_productlist.AllowUserToAddRows = false;
            this.add_productlist.AllowUserToDeleteRows = false;
            this.add_productlist.AllowUserToResizeColumns = false;
            this.add_productlist.AllowUserToResizeRows = false;
            this.add_productlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.add_productlist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.add_productlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.add_productlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.Column5,
            this.Column4});
            this.add_productlist.Location = new System.Drawing.Point(494, 34);
            this.add_productlist.MultiSelect = false;
            this.add_productlist.Name = "add_productlist";
            this.add_productlist.ReadOnly = true;
            this.add_productlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.add_productlist.Size = new System.Drawing.Size(658, 382);
            this.add_productlist.TabIndex = 20;
            this.add_productlist.DoubleClick += new System.EventHandler(this.add_productlist_DoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "קוד מוצר";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "שם מוצר";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "מחיר מוצר ליחידה";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "כמות מוצר";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "שם ספק";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.productcount);
            this.panel1.Controls.Add(this.productcode);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.newsupplier);
            this.panel1.Controls.Add(this.displaysupplier);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.add_newcategory);
            this.panel1.Controls.Add(this.display_category);
            this.panel1.Controls.Add(this.product_name);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.product_price);
            this.panel1.Location = new System.Drawing.Point(27, 34);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(350, 382);
            this.panel1.TabIndex = 19;
            // 
            // productcount
            // 
            this.productcount.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.productcount.Location = new System.Drawing.Point(81, 277);
            this.productcount.MaxLength = 5;
            this.productcount.Name = "productcount";
            this.productcount.Size = new System.Drawing.Size(180, 23);
            this.productcount.TabIndex = 28;
            this.productcount.TextChanged += new System.EventHandler(this.productcount_TextChanged_1);
            // 
            // productcode
            // 
            this.productcode.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.productcode.Location = new System.Drawing.Point(80, 131);
            this.productcode.MaxLength = 12;
            this.productcode.Name = "productcode";
            this.productcode.Size = new System.Drawing.Size(180, 23);
            this.productcode.TabIndex = 25;
            this.productcode.TextChanged += new System.EventHandler(this.productcode_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(272, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "קוד :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(128, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "הוספת מוצר:";
            // 
            // newsupplier
            // 
            this.newsupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.newsupplier.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.newsupplier.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newsupplier.Location = new System.Drawing.Point(13, 85);
            this.newsupplier.Name = "newsupplier";
            this.newsupplier.Size = new System.Drawing.Size(61, 26);
            this.newsupplier.TabIndex = 24;
            this.newsupplier.Text = "חדש";
            this.newsupplier.UseVisualStyleBackColor = false;
            this.newsupplier.Click += new System.EventHandler(this.newsupplier_Click_1);
            // 
            // displaysupplier
            // 
            this.displaysupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.displaysupplier.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.displaysupplier.FormattingEnabled = true;
            this.displaysupplier.Location = new System.Drawing.Point(80, 85);
            this.displaysupplier.Name = "displaysupplier";
            this.displaysupplier.Size = new System.Drawing.Size(180, 24);
            this.displaysupplier.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(270, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "ספק:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(272, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "כמות:";
            // 
            // add_newcategory
            // 
            this.add_newcategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.add_newcategory.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.add_newcategory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.add_newcategory.Location = new System.Drawing.Point(13, 39);
            this.add_newcategory.Name = "add_newcategory";
            this.add_newcategory.Size = new System.Drawing.Size(61, 24);
            this.add_newcategory.TabIndex = 14;
            this.add_newcategory.Text = "חדש";
            this.add_newcategory.UseVisualStyleBackColor = false;
            this.add_newcategory.Click += new System.EventHandler(this.add_newcategory_Click_1);
            // 
            // display_category
            // 
            this.display_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.display_category.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.display_category.FormattingEnabled = true;
            this.display_category.Location = new System.Drawing.Point(80, 39);
            this.display_category.Name = "display_category";
            this.display_category.Size = new System.Drawing.Size(180, 24);
            this.display_category.TabIndex = 0;
            // 
            // product_name
            // 
            this.product_name.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.product_name.Location = new System.Drawing.Point(80, 180);
            this.product_name.MaxLength = 20;
            this.product_name.Name = "product_name";
            this.product_name.Size = new System.Drawing.Size(180, 23);
            this.product_name.TabIndex = 2;
            this.product_name.TextChanged += new System.EventHandler(this.product_name_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(270, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "סוג :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(279, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "שם:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(267, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "מחיר(₪):";
            // 
            // product_price
            // 
            this.product_price.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.product_price.Location = new System.Drawing.Point(81, 229);
            this.product_price.MaxLength = 10;
            this.product_price.Name = "product_price";
            this.product_price.Size = new System.Drawing.Size(180, 23);
            this.product_price.TabIndex = 7;
            this.product_price.TextChanged += new System.EventHandler(this.product_price_TextChanged);
            // 
            // removefromlist
            // 
            this.removefromlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.removefromlist.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.removefromlist.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removefromlist.Location = new System.Drawing.Point(383, 228);
            this.removefromlist.Name = "removefromlist";
            this.removefromlist.Size = new System.Drawing.Size(105, 40);
            this.removefromlist.TabIndex = 18;
            this.removefromlist.Text = "לבטל";
            this.removefromlist.UseVisualStyleBackColor = false;
            this.removefromlist.Click += new System.EventHandler(this.removefromlist_Click_1);
            // 
            // addtolistbtn
            // 
            this.addtolistbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.addtolistbtn.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.addtolistbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addtolistbtn.Location = new System.Drawing.Point(383, 135);
            this.addtolistbtn.Name = "addtolistbtn";
            this.addtolistbtn.Size = new System.Drawing.Size(105, 40);
            this.addtolistbtn.TabIndex = 17;
            this.addtolistbtn.Text = "הוסף";
            this.addtolistbtn.UseVisualStyleBackColor = false;
            this.addtolistbtn.Click += new System.EventHandler(this.addtolistbtn_Click_1);
            // 
            // addproductbtn
            // 
            this.addproductbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.addproductbtn.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.addproductbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addproductbtn.Location = new System.Drawing.Point(494, 422);
            this.addproductbtn.Name = "addproductbtn";
            this.addproductbtn.Size = new System.Drawing.Size(137, 49);
            this.addproductbtn.TabIndex = 16;
            this.addproductbtn.Text = "סיום";
            this.addproductbtn.UseVisualStyleBackColor = false;
            this.addproductbtn.Click += new System.EventHandler(this.addproductbtn_Click_1);
            // 
            // Add_product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(1168, 565);
            this.Controls.Add(this.cancelallproduct);
            this.Controls.Add(this.add_productlist);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.removefromlist);
            this.Controls.Add(this.addtolistbtn);
            this.Controls.Add(this.addproductbtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1184, 604);
            this.MinimumSize = new System.Drawing.Size(1184, 604);
            this.Name = "Add_product";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.add_productlist)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelallproduct;
        private System.Windows.Forms.DataGridView add_productlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox productcount;
        private System.Windows.Forms.TextBox productcode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button newsupplier;
        private System.Windows.Forms.ComboBox displaysupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button add_newcategory;
        private System.Windows.Forms.ComboBox display_category;
        private System.Windows.Forms.TextBox product_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox product_price;
        private System.Windows.Forms.Button removefromlist;
        private System.Windows.Forms.Button addtolistbtn;
        private System.Windows.Forms.Button addproductbtn;
    }
}