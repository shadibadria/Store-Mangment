namespace Store_Mangment.view.products
{
    partial class Sold_productslist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sold_productslist));
            this.product_list = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.searchbyname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.productcount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchbycode = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.soldp_btn = new System.Windows.Forms.Button();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.soldproducts_edate = new System.Windows.Forms.DateTimePicker();
            this.soldproducts_sdate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.product_list)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // product_list
            // 
            this.product_list.AllowUserToAddRows = false;
            this.product_list.AllowUserToDeleteRows = false;
            this.product_list.AllowUserToResizeColumns = false;
            this.product_list.AllowUserToResizeRows = false;
            this.product_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.product_list.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.product_list.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.product_list.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.product_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.product_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.Column5,
            this.Column4,
            this.Column1});
            this.product_list.Location = new System.Drawing.Point(20, 146);
            this.product_list.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.product_list.MultiSelect = false;
            this.product_list.Name = "product_list";
            this.product_list.ReadOnly = true;
            this.product_list.RowHeadersVisible = false;
            this.product_list.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.product_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.product_list.ShowCellErrors = false;
            this.product_list.ShowCellToolTips = false;
            this.product_list.ShowEditingIcon = false;
            this.product_list.ShowRowErrors = false;
            this.product_list.Size = new System.Drawing.Size(1102, 487);
            this.product_list.TabIndex = 61;
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
            this.dataGridViewTextBoxColumn3.HeaderText = "מחיר מוצר(₪)";
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
            // Column1
            // 
            this.Column1.HeaderText = "תאריך שנמכר";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(300, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 63;
            this.label3.Text = "שם מוצר:";
            // 
            // searchbyname
            // 
            this.searchbyname.Location = new System.Drawing.Point(303, 115);
            this.searchbyname.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.searchbyname.Name = "searchbyname";
            this.searchbyname.Size = new System.Drawing.Size(263, 23);
            this.searchbyname.TabIndex = 62;
            this.searchbyname.TextChanged += new System.EventHandler(this.searchbyname_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(243)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.productcount);
            this.panel1.Location = new System.Drawing.Point(994, 640);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 34);
            this.panel1.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "כמות:";
            // 
            // productcount
            // 
            this.productcount.AutoSize = true;
            this.productcount.Location = new System.Drawing.Point(3, 8);
            this.productcount.Name = "productcount";
            this.productcount.Size = new System.Drawing.Size(47, 16);
            this.productcount.TabIndex = 13;
            this.productcount.Text = "label5";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 74;
            this.label1.Text = "קוד מוצר:";
            // 
            // searchbycode
            // 
            this.searchbycode.Location = new System.Drawing.Point(20, 115);
            this.searchbycode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.searchbycode.Name = "searchbycode";
            this.searchbycode.Size = new System.Drawing.Size(263, 23);
            this.searchbycode.TabIndex = 73;
            this.searchbycode.TextChanged += new System.EventHandler(this.searchbycode_TextChanged);
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(805, 9);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(127, 12);
            this.label71.TabIndex = 81;
            this.label71.Text = "דוח מוצרים שאוזלו:";
            // 
            // soldp_btn
            // 
            this.soldp_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.soldp_btn.Location = new System.Drawing.Point(781, 97);
            this.soldp_btn.Name = "soldp_btn";
            this.soldp_btn.Size = new System.Drawing.Size(168, 35);
            this.soldp_btn.TabIndex = 77;
            this.soldp_btn.Text = "הוצאה דוח";
            this.soldp_btn.UseVisualStyleBackColor = false;
            this.soldp_btn.Click += new System.EventHandler(this.soldp_btn_Click);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(684, 75);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(73, 16);
            this.label72.TabIndex = 78;
            this.label72.Text = "עד תאריך:";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(695, 44);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(62, 16);
            this.label73.TabIndex = 82;
            this.label73.Text = "מתאריך:";
            // 
            // soldproducts_edate
            // 
            this.soldproducts_edate.Location = new System.Drawing.Point(763, 68);
            this.soldproducts_edate.Name = "soldproducts_edate";
            this.soldproducts_edate.Size = new System.Drawing.Size(217, 23);
            this.soldproducts_edate.TabIndex = 79;
            // 
            // soldproducts_sdate
            // 
            this.soldproducts_sdate.Location = new System.Drawing.Point(763, 39);
            this.soldproducts_sdate.Name = "soldproducts_sdate";
            this.soldproducts_sdate.Size = new System.Drawing.Size(217, 23);
            this.soldproducts_sdate.TabIndex = 80;
            // 
            // Sold_productslist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(1142, 681);
            this.Controls.Add(this.label71);
            this.Controls.Add(this.soldp_btn);
            this.Controls.Add(this.label72);
            this.Controls.Add(this.label73);
            this.Controls.Add(this.soldproducts_edate);
            this.Controls.Add(this.soldproducts_sdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchbycode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchbyname);
            this.Controls.Add(this.product_list);
            this.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1158, 720);
            this.MinimumSize = new System.Drawing.Size(1158, 720);
            this.Name = "Sold_productslist";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Sold_productslist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.product_list)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView product_list;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchbyname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label productcount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchbycode;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button soldp_btn;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.DateTimePicker soldproducts_edate;
        private System.Windows.Forms.DateTimePicker soldproducts_sdate;
    }
}