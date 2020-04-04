namespace Store_Mangment.view.Categorys
{
    partial class Add_category
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_category));
            this.category_info = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.category_name = new System.Windows.Forms.TextBox();
            this.addproductbtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // category_info
            // 
            this.category_info.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.category_info.Location = new System.Drawing.Point(42, 221);
            this.category_info.MaxLength = 200;
            this.category_info.Multiline = true;
            this.category_info.Name = "category_info";
            this.category_info.Size = new System.Drawing.Size(436, 106);
            this.category_info.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(39, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "קטגוריה:";
            // 
            // category_name
            // 
            this.category_name.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.category_name.Location = new System.Drawing.Point(42, 123);
            this.category_name.MaxLength = 20;
            this.category_name.Name = "category_name";
            this.category_name.Size = new System.Drawing.Size(436, 23);
            this.category_name.TabIndex = 45;
            this.category_name.TextChanged += new System.EventHandler(this.category_name_TextChanged);
            // 
            // addproductbtn
            // 
            this.addproductbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(141)))), ((int)(((byte)(135)))));
            this.addproductbtn.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.addproductbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addproductbtn.Location = new System.Drawing.Point(42, 333);
            this.addproductbtn.Name = "addproductbtn";
            this.addproductbtn.Size = new System.Drawing.Size(436, 49);
            this.addproductbtn.TabIndex = 44;
            this.addproductbtn.Text = "סיום";
            this.addproductbtn.UseVisualStyleBackColor = false;
            this.addproductbtn.Click += new System.EventHandler(this.addproductbtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(39, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "שם :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("David", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(39, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 42;
            this.label10.Text = "הסבר:";
            // 
            // Add_category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(210)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(516, 447);
            this.Controls.Add(this.category_info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.category_name);
            this.Controls.Add(this.addproductbtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(532, 486);
            this.MinimumSize = new System.Drawing.Size(532, 486);
            this.Name = "Add_category";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Add_category_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox category_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox category_name;
        private System.Windows.Forms.Button addproductbtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
    }
}